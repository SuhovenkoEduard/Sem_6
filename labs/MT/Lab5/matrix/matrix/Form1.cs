using lab5.LabClasses;

namespace lab5;

public partial class Form1 : Form
{
    private readonly Grammar grammar = new();

    public Form1()
    {
        InitializeComponent();
        tbGrammar.Select(0, 0);
        tbPrecendenceMatrix.Font = new Font(FontFamily.GenericMonospace, tbPrecendenceMatrix.Font.Size);
    }

    //Считывание правил грамматики
    private void ReadRules()
    {
        var rulesStr = tbGrammar.Text.Split("\r\n");

        foreach (var ruleStr in rulesStr)
        {
            var ruleParts = ruleStr.Split('→').ToList().Select(r => r.Replace(" ", null)).ToArray();

            if (ruleParts.Length == 0 || ruleParts.Length > 2 || ruleParts[0].Length > 1 || ruleParts[1].Length == 0)
                throw new Exception("Ошибка в правиле.");

            if (ruleParts[0][0] != 'S') grammar.AddRule(ruleParts[0][0], ruleParts[1]);
        }
    }

    //Построение матрицы предшествования
    private void bBuildPrecendenceMatrix_Click(object sender, EventArgs e)
    {
        ReadRules();
        tbLeftSymbolsSet.Text = grammar.GetSymbolsSetAsString(true);
        tbRightSymbolsSet.Text = grammar.GetSymbolsSetAsString(false);
        tbPrecendenceMatrix.Text = grammar.GetPrecendenceMatrixAsString();

        if (grammar.IsOperatorPrecedenceGrammar())
            lResult.Text = "Заданная КС-грамматика является простой грамматикой предшествования.";
        else
            lResult.Text = "Заданная КС-грамматика НЕ является простой грамматикой предшествования.";
    }
}