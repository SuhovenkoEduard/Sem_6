using System.Text;

namespace lab5.LabClasses;

internal class Grammar
{
    private Dictionary<char, List<char>>? leftSymbolsSet, rightSymbolsSet;
    private List<List<PrecendenceMatrixElement>>? precendenceMatrix;
    private readonly Dictionary<char, List<string>> rules = new();

    //Обнуление указателей
    private void ResetReferences()
    {
        leftSymbolsSet = null;
        rightSymbolsSet = null;
        precendenceMatrix = null;
    }

    //Добавление правила в грамматику
    public void AddRule(char symbol, string rule)
    {
        if (rules.ContainsKey(symbol))
        {
            rules[symbol].Add(rule);
        }
        else
        {
            List<string> newRulesList = new();
            newRulesList.Add(rule);
            rules.Add(symbol, newRulesList);
        }

        ResetReferences();
    }

    //Очистка правил
    public void Clear()
    {
        rules.Clear();
        ResetReferences();
    }

    //Получение множества левых или правых символов для нетерминального символа
    private void GetSymbolsSetIntrinsic(char symbol, List<char> symbols, bool getLeftSymbols)
    {
        if (rules.ContainsKey(symbol))
        {
            var symbolRules = rules[symbol];

            foreach (var symbolRule in symbolRules)
            {
                char nextSymbol;

                if (getLeftSymbols)
                    nextSymbol = symbolRule[0];
                else
                    nextSymbol = symbolRule[^1];

                if (!symbols.Contains(nextSymbol))
                {
                    symbols.Add(nextSymbol);

                    if (nextSymbol != symbol) GetSymbolsSetIntrinsic(nextSymbol, symbols, getLeftSymbols);
                }
            }
        }
    }

    //Получение всех множеств левых или правых символов для нетерминальных символов
    private void GetSymbolsSet(bool getLeftSymbols)
    {
        Dictionary<char, List<char>> symbolsSet;

        if (getLeftSymbols)
        {
            leftSymbolsSet = new Dictionary<char, List<char>>();
            symbolsSet = leftSymbolsSet;
        }
        else
        {
            rightSymbolsSet = new Dictionary<char, List<char>>();
            symbolsSet = rightSymbolsSet;
        }

        foreach (var symbol in rules.Keys)
        {
            if (symbolsSet.ContainsKey(symbol))
            {
                GetSymbolsSetIntrinsic(symbol, symbolsSet[symbol], getLeftSymbols);
            }
            else
            {
                List<char> newSymbols = new();
                GetSymbolsSetIntrinsic(symbol, newSymbols, getLeftSymbols);
                symbolsSet.Add(symbol, newSymbols);
            }
        }
    }

    //Инициализация матрицы предшествования
    private void InitPrecendenceMatrix()
    {
        precendenceMatrix = new List<List<PrecendenceMatrixElement>>();

        List<char> symbols = new();

        foreach (var ruleSymbol in rules.Keys) symbols.Add(ruleSymbol);

        foreach (var rulesList in rules.Values)
        foreach (var rule in rulesList)
        foreach (var symbol in rule)
            if (!symbols.Contains(symbol))
                symbols.Add(symbol);

        foreach (var rowSymbol in symbols)
        {
            List<PrecendenceMatrixElement> newRow = new();

            foreach (var columnSymbol in symbols)
                newRow.Add(new PrecendenceMatrixElement {Ai = rowSymbol, Aj = columnSymbol});

            precendenceMatrix.Add(newRow);
        }
    }

    //Проверка отношения типа "=" для символов
    private bool HasSamePrecendenceAs(char ai, char aj)
    {
        var isItTrue = false;
        var pair = $"{ai}{aj}";

        foreach (var rulesList in rules.Values)
        foreach (var rule in rulesList)
            if (rule.Contains(pair))
                isItTrue = true;

        return isItTrue;
    }

    //Проверка отношения типа "<" для символов
    private bool DoesYieldPrecendenceTo(char ai, char aj)
    {
        var leftSymbolsContainingAj =
            leftSymbolsSet.Where(symbolLeftSymbolsSet => symbolLeftSymbolsSet.Value.Contains(aj));

        var isItTrue = false;

        foreach (var symbolLeftSymbolsSet in leftSymbolsContainingAj)
            if (HasSamePrecendenceAs(ai, symbolLeftSymbolsSet.Key))
                isItTrue = true;

        return isItTrue;
    }

    //Проверка отношения типа ">" для символов
    private bool DoesTakePrecendenceOver(char ai, char aj)
    {
        var rightSymbolsContainingAi =
            rightSymbolsSet.Where(symbolRightSymbolsSet => symbolRightSymbolsSet.Value.Contains(ai));
        var leftSymbolsContainingAj =
            leftSymbolsSet.Where(symbolLeftSymbolsSet => symbolLeftSymbolsSet.Value.Contains(aj));

        var isItTrue = false;

        //первый случай
        foreach (var symbolRightSymbolsSet in rightSymbolsContainingAi)
            if (HasSamePrecendenceAs(symbolRightSymbolsSet.Key, aj))
                isItTrue = true;

        //второй случай
        if (!isItTrue)
            foreach (var symbolRightSymbolsSet in rightSymbolsContainingAi)
            foreach (var symbolLeftSymbolsSet in leftSymbolsContainingAj)
                if (HasSamePrecendenceAs(symbolRightSymbolsSet.Key, symbolLeftSymbolsSet.Key))
                    isItTrue = true;

        return isItTrue;
    }

    //Получение матрицы предшествования
    private void GetPrecendenceMatrix()
    {
        GetSymbolsSet(true);
        GetSymbolsSet(false);
        InitPrecendenceMatrix();

        foreach (var rowList in precendenceMatrix)
        {
            var rowSymbol = rowList[0].Ai;

            foreach (var rowListElement in rowList)
            {
                var columnSymbol = rowListElement.Aj;

                var element = rowListElement;
                element.HasSamePrecendenceAs = HasSamePrecendenceAs(rowSymbol, columnSymbol);
                element.DoesYieldPrecendenceTo = DoesYieldPrecendenceTo(rowSymbol, columnSymbol);
                element.DoesTakePrecendenceOver = DoesTakePrecendenceOver(rowSymbol, columnSymbol);
            }
        }
    }

    //Получение множеств левых и правых символов в текстовом виде
    public string GetSymbolsSetAsString(bool getLeftSymbolsSet)
    {
        GetSymbolsSet(getLeftSymbolsSet);

        var setSymbol = 'L';
        var symbolSet = leftSymbolsSet;

        if (!getLeftSymbolsSet)
        {
            setSymbol = 'R';
            symbolSet = rightSymbolsSet;
        }

        StringBuilder sb = new();

        var symbolSetList = symbolSet.ToList();
        symbolSetList.Reverse();

        foreach (var symbolSymbolsSet in symbolSetList)
            sb.Append($"{setSymbol}({symbolSymbolsSet.Key})={{{string.Join(", ", symbolSymbolsSet.Value)}}}\r\n");

        return sb.ToString();
    }

    //Получение матрицы предшествования в виде таблицы в текстовом виде
    public string GetPrecendenceMatrixAsString()
    {
        GetPrecendenceMatrix();

        StringBuilder sb = new();
        var rowLength = 6 * (precendenceMatrix.Count + 1) + 1;
        var separator = new string('-', rowLength) + "\r\n";

        sb.Append(separator);

        sb.Append("|     |");

        foreach (var element in precendenceMatrix[0]) sb.Append($"  {element.Aj}  |");

        sb.Append("\r\n");
        sb.Append(separator);

        foreach (var rowList in precendenceMatrix)
        {
            sb.Append($"|  {rowList[0].Ai}  |");

            foreach (var columnElement in rowList) sb.Append($" {columnElement} |");

            sb.Append("\r\n");
            sb.Append(separator);
        }

        return sb.ToString();
    }

    //Проверка заданной грамматики на то, является ли она ПГП
    public bool IsOperatorPrecedenceGrammar()
    {
        var isItTrue = true;

        //первое условие
        for (var i = 0; i < precendenceMatrix.Count && isItTrue; i++)
        for (var j = 0; j < precendenceMatrix[i].Count && isItTrue; j++)
        {
            var count = 0;
            var element = precendenceMatrix[i][j];

            if (element.HasSamePrecendenceAs) count++;

            if (element.DoesYieldPrecendenceTo) count++;

            if (element.DoesTakePrecendenceOver) count++;

            if (count > 1) isItTrue = false;
        }

        if (isItTrue)
            //второе условие
            foreach (var outerRulesList in rules.Values)
            foreach (var outerRulesListElement in outerRulesList)
            foreach (var innerRulesList in rules.Values)
                if (outerRulesList != innerRulesList)
                    foreach (var innerRulesListElement in innerRulesList)
                        if (outerRulesListElement == innerRulesListElement)
                            isItTrue = false;

        return isItTrue;
    }
}