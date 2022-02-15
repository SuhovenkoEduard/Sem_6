using System;
using System.Windows;
using Microsoft.Office.Interop.Excel;

namespace MainApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string errorTemplateIntParse = "Ошибка при приведении коэффициента {0} к целому числу! Повторите попытку!";
        
        const string equationTemplate = "z={0}x+{1}y+{2}sin(x)cos(y)";

        private bool anyErrors = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AcceptParametersClick(object sender, RoutedEventArgs e)
        {
            int A = 0, B = 0, C = 0, Xn,Xk,Yn,Yk;
            absc.Text = "";
            ordin.Text = "";

            if (!int.TryParse(TBox_A.Text, out A))
                ErrorMsg("A");
            else
            {
                if (!int.TryParse(TBox_B.Text, out B))
                    ErrorMsg("B");
                else
                {
                    if (!int.TryParse(TBox_C.Text, out C))
                        ErrorMsg("C");
                }
                if (!anyErrors)
                {
                    equationText.Text = String.Format(equationTemplate, A,B,C);
                }
            }
            
            if(!anyErrors)
            {
                absc.Text += "{";
                int.TryParse(TBox_Xn.Text, out Xn);
                absc.Text += Xn;
                absc.Text += "; ";
                int.TryParse(TBox_Xk.Text, out Xk);
                absc.Text += Xk;
                absc.Text += "}";
                ordin.Text += "{";
                int.TryParse(TBox_Yn.Text, out Yn);
                ordin.Text += Yn;
                ordin.Text += "; ";
                int.TryParse(TBox_Yk.Text, out Yk);
                ordin.Text += Yk;
                ordin.Text += "}";
            }

            //if (!anyErrors && int.TryParse(TBox_B.Text, out buf))
            //{
            //    coeff_B.Text += buf;

            //    if (!anyErrors && int.TryParse(TBox_C.Text, out buf))
            //    {
            //        coeff_C.Text += buf

            //        if (!anyErrors && int.TryParse(TBox_Xn.Text, out buf))
            //        {
            //            absc.Text += "";

            //            if (!anyErrors && int.TryParse(TBox_Xk.Text, out buf))
            //            {
            //                absc.Text += "";
            //            }
            //            else ErrorMsg("Xk");
            //        }
            //        else ErrorMsg("Xn");
            //    }
            //    else ErrorMsg("C");
            //}
            //else ErrorMsg("B");

            MessageBox.Show("Успешно приняты!");
        }

        private void ErrorMsg(string coefficient)
        {
            MessageBox.Show(string.Format(errorTemplateIntParse, coefficient));
            anyErrors = true;
        }

        private void PythonBuild_Click(object sender, RoutedEventArgs e)
        {
            Application application = new Application();
            application.Workbooks.Add(Type.Missing);
            Worksheet sheet = (Worksheet)application.Sheets[1];

            for (int i = 1; i <= 10; i++)
            {
                sheet.Cells[i, 1] = i;
                sheet.Cells[i, 2] = Math.Sin(i);
            }

            ChartObjects xlCharts = (ChartObjects)sheet.ChartObjects(Type.Missing);
            ChartObject myChart = (ChartObject)xlCharts.Add(110, 0, 350, 250);
            Chart chart = myChart.Chart;
            SeriesCollection seriesCollection = (SeriesCollection)chart.SeriesCollection(Type.Missing);
            Series series = seriesCollection.NewSeries();
            series.XValues = sheet.get_Range("A1", "A10");
            series.Values = sheet.get_Range("B1", "B10");
            chart.ChartType = XlChartType.xlXYScatterSmooth;
            application.Visible = true;
        }
    }
}
