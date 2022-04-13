using Lab4_hashing.HsTable;

namespace Lab4_hashing.HashFunctions;

public class Additive
{
    public static HashLengthFunc HashFunc = (str, length) => Math.Abs(str.Aggregate(0, (acc, x) => acc + x * 31) % length);
}