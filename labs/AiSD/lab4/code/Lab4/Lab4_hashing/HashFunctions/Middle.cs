using Lab4_hashing.HsTable;

namespace Lab4_hashing.HashFunctions;

public class Middle
{
    public static HashLengthFunc HashFunc = (str, length) =>
    {
        var sum = str.Aggregate(0, (acc, x) => acc + x);
        var sq = (sum * sum).ToString();
        return int.Parse(sq[..^2]) % length;
    };
}