namespace lab5.LabClasses;

internal class PrecendenceMatrixElement
{
    public char Ai { get; set; }

    public char Aj { get; set; }

    //<
    public bool DoesYieldPrecendenceTo { get; set; }

    //=
    public bool HasSamePrecendenceAs { get; set; }

    //>
    public bool DoesTakePrecendenceOver { get; set; }

    public override string ToString()
    {
        var chars = new char[3] {' ', ' ', ' '};
        var index = 0;

        if (DoesYieldPrecendenceTo)
        {
            chars[index] = '<'; //'⋖';
            index++;
        }

        if (HasSamePrecendenceAs)
        {
            chars[index] = '='; //'≐';
            index++;
        }

        if (DoesTakePrecendenceOver) chars[index] = '>'; //'⋗';

        return string.Join(null, chars);
    }
}