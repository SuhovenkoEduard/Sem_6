using MathModule;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using Excel = Microsoft.Office.Interop.Excel;

namespace mainApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        const string errorTemplateParse = "Ошибка при приведении коэффициента {0} к числу! Повторите попытку!";
        const string errorTemplateBounds = "Ошибка! Неверно заданы коэффициенты {0}!";

        const string equationTemplate = "z={0}x+{1}y+{2}sin(x)cos(y)";
        const string resultsPathsTemplate = "Stats\\{0}threadsResult.txt";

        private List<TableViewObject> tableViewObjects { get; set; }

        private IAreaCalculator calculator;

        public MainWindow()
        {
            calculator = new SurfaceAreaCalculator();
            tableViewObjects = new List<TableViewObject>();
            InitializeComponent();
            UpdateInfo();
        }

        private void AcceptParametersClick(object sender, RoutedEventArgs e)
        {
            double A, B, C, Xn, Xk, Yn, Yk;
            if (!double.TryParse(TBox_A.Text, out A))
                ErrorMsg(errorTemplateParse, "A");
            else
                calculator.A = A;

            if (!double.TryParse(TBox_B.Text, out B))
                ErrorMsg(errorTemplateParse, "B");
            else
                calculator.B = B;

            if (!double.TryParse(TBox_C.Text, out C))
                ErrorMsg(errorTemplateParse, "C");
            else
                calculator.C = C;

            if (!double.TryParse(TBox_Xn.Text, out Xn) || !double.TryParse(TBox_Xk.Text, out Xk) )
            {
                ErrorMsg(errorTemplateParse, "Xn или Xk");
            }
            else if(Xk <= Xn)
            {
                ErrorMsg(errorTemplateBounds, "Xn и Xk");
            }
            else
            {
                calculator.Xn = Xn;
                calculator.Xk = Xk;
            }

            if (!double.TryParse(TBox_Yn.Text, out Yn) || !double.TryParse(TBox_Yk.Text, out Yk))
            {
                ErrorMsg(errorTemplateParse, "Yn или Yk");
            }
            else if (Yk <= Yn)
            {
                ErrorMsg(errorTemplateBounds, "Yn и Yk");
            }
            else
            {
                calculator.Yn = Yn;
                calculator.Yk = Yk;
            }

            UpdateInfo();
            MessageBox.Show("Успешно приняты!");
        }

        private void UpdateInfo()
        {
            absc.Text = "";
            ordin.Text = "";
            equationText.Text = String.Format(equationTemplate, calculator.A, calculator.B, calculator.C);
            absc.Text += "{";
            absc.Text += calculator.Xn;
            absc.Text += "; ";
            absc.Text += calculator.Xk;
            absc.Text += "}";
            ordin.Text += "{";
            ordin.Text += calculator.Yn;
            ordin.Text += "; ";
            ordin.Text += calculator.Yk;
            ordin.Text += "}";
        }

        private void ErrorMsg(string template, string coefficient)
        {
            MessageBox.Show(string.Format(template, coefficient));
        }

        private void PythonBuild_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("PythonSurfaceBuilder.exe"))
            {
                ProcessStartInfo process = new ProcessStartInfo("PythonSurfaceBuilder", "-A " + calculator.A
                                                                                        + "-B " + calculator.B
                                                                                        + "-C " + calculator.C
                                                                                        + "-Xn " + calculator.Xn
                                                                                        + "-Xk " + calculator.Xk
                                                                                        + "-Yn " + calculator.Yn
                                                                                        + "-Yk " + calculator.Yk);
                process.UseShellExecute = false;
                using (Process one = Process.Start(process))
                {
                    one.WaitForExit();
                }
            }
            else
                MessageBox.Show("Приложение PythonSurfaceBuilder.exe не найдено в каталоге главного приложения. Невозможно выполнить операцию!");
        }

        private void CalculateThreads_Click(object sender, RoutedEventArgs e)
        {
            if(exactValue.Text == "" || !double.TryParse(exactValue.Text, out double res))
            {
                MessageBox.Show("Точное значение площади не получено, подсчитать относительную погрешность невозможно!");
            }

            InfoGrid.ItemsSource = null;
            InfoGrid.Items.Clear();
            tableViewObjects.Clear();
            string[] buf;

            ProgressBar.Visibility = Visibility.Visible;
            ProgressBar.Value = 0;
            if (int.TryParse(ThreadsBox.Text, out int threads) && threads > 0)
            {
                calculator.CalculateSingleThread();
                int i = 1;
                using (StreamReader sr = new StreamReader(string.Format(resultsPathsTemplate, i), System.Text.Encoding.Default))
                {
                    buf = sr.ReadLine().Split('$');
                    tableViewObjects.Add(new TableViewObject { answer = buf[0], threadsAmount = i, time = buf[1], err = getErr(exactValue.Text, buf[0]) });
                }

                if (threads > 1)
                {
                    ProgressBar.Value = 100 / threads;
                    for (i = 2; i <= threads; i++)
                    {
                        MessageBox.Show($"Запущена процедура подсчёта площади для {i} потоков! Пожалуйста, подождите!", "Внимание!");
                        calculator.CalculateMultiThread(i);

                        using (var sr = new StreamReader(string.Format(resultsPathsTemplate, i), System.Text.Encoding.Default))
                        {
                            buf = sr.ReadLine().Split('$');
                            tableViewObjects.Add(new TableViewObject { answer = buf[0], threadsAmount = i, time = buf[1], err = getErr(exactValue.Text, buf[0])});
                        }
                        ProgressBar.Value = (i + 0.0) / threads * 100;
                    }
                }
                MessageBox.Show($"Завершено!");
                InfoGrid.ItemsSource = tableViewObjects;
                ExcelBtn.IsEnabled = true;
            }
            else
            {
                ExcelBtn.IsEnabled = false;
                MessageBox.Show("Задано неверное число потоков!", "Ошибка");
            }
        }

        private string getErr(string exactValue, string approximateValue)
        {
            if (exactValue == "" || !double.TryParse(exactValue, out double res))
                return "";
            else
                return (Math.Abs(res - double.Parse(approximateValue)) / double.Parse(approximateValue) * 100.0).ToString();
        }

        private void ExportExcel_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(ThreadsBox.Text, out int threads))
            {
                Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
                application.Workbooks.Add(Type.Missing);
                Worksheet sheet = (Worksheet)application.Sheets[1];

                for (int i = 2; i <= threads + 1; i++)
                {
                    sheet.Cells[i, 1] = i - 1;
                    sheet.Cells[i, 2] = tableViewObjects[i-2].time;
                }

                sheet.get_Range("E1:M1").Merge();
                sheet.Cells[1, 5] = "График зависимости времени выполнения от числа потоков";
                sheet.Cells[1, 1] = "Потоки";
                sheet.Cells[1, 2] = "Время";
                sheet.Columns[1].ColumnWidth = 10;
                sheet.Columns[2].ColumnWidth = 15;
                sheet.Columns[3].ColumnWidth = 15;

                ChartObjects xlCharts = (ChartObjects)sheet.ChartObjects(Type.Missing);
                ChartObject myChart = (ChartObject)xlCharts.Add(200, 20, 400, 300);
                Chart chart = myChart.Chart;
                SeriesCollection seriesCollection = (SeriesCollection)chart.SeriesCollection(Type.Missing);
                Series series = seriesCollection.NewSeries();
                series.Name = "График зависимости времени от числа потоков";
                series.XValues = sheet.get_Range("A2", "A"+(threads+1));
                series.Values = sheet.get_Range("B2", "B"+(threads+1));
                chart.ChartType = XlChartType.xlLineMarkers;
                application.Visible = true;
            }
            else
                MessageBox.Show("Не удалось прочитать число потоков для экспорта данных. Отмена операции!");
        }

        private void getExactValue_Click(object sender, RoutedEventArgs e)
        {
            const string resultsErrorTemplate = "Приложение было запущено, но файл value.txt с результатом в каталоге главного приложения {0}. Невозможно выполнить операцию!";
            const string filename = "DoubleIntegration.exe";

            if (File.Exists(filename))
            {
                ProcessStartInfo process = new ProcessStartInfo(filename, "-A " + calculator.A
                                                                                        + "-B " + calculator.B
                                                                                        + "-C " + calculator.C
                                                                                        + "-Xn " + calculator.Xn
                                                                                        + "-Xk " + calculator.Xk
                                                                                        + "-Yn " + calculator.Yn
                                                                                        + "-Yk " + calculator.Yk);
                process.UseShellExecute = false;
                using (Process one = Process.Start(process))
                {
                    one.WaitForExit();
                    if (File.Exists(filename))
                    {
                        using (StreamReader sr = new StreamReader(filename))
                        {
                            string res = sr.ReadLine();
                            if(double.TryParse(res, out double exactErrorValue))
                            {
                                exactValue.Text = exactErrorValue.ToString();
                                MessageBox.Show("Точное значение успешно подсчитано!");
                            }
                            else
                            {
                                MessageBox.Show(string.Format(resultsErrorTemplate, "повреждён"));
                            }
                        }
                    }
                    else
                        MessageBox.Show(string.Format(resultsErrorTemplate, "не существует"));
                }
            }
            else
                MessageBox.Show("Приложение DoubleIntegration.exe не найдено в каталоге главного приложения. Невозможно выполнить операцию!");
        }
    }
}
