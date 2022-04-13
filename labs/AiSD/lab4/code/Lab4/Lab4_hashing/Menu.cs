using System.Diagnostics;
using Lab4_hashing.HsTable;

namespace Lab4_hashing;

public class Menu
{
    private readonly string _hashName;
    private readonly HashTable _hashTable;
    private readonly string[] _data;

    public Menu(HashTable hashTable, string[] data,  string hashName)
    {
        _hashTable = hashTable;
        _data = data;
        _hashName = hashName;
    }

    private static int CalcTicks(Action func)
    {
        var time = new Stopwatch();
        time.Start();
        func();
        time.Stop();
        return (int) time.ElapsedTicks;
    }

    private static string ReadString() => Console.ReadLine() ?? string.Empty;

    private static void PrintTicks(string before, int time, string after = "s\n") =>
        Console.WriteLine($"{before} {(double) time / 10000} {after}");

    private static void PrintTimeOfAction(string before, Action func, string after = "s\n")
        => PrintTicks(before, CalcTicks(func), after);

    public void Run()
    {
        var time = CalcTicks(() => _hashTable.AddMany(_data));
        _hashTable.Show();
        PrintTicks($"time add to {_hashName} hashtable:", time);
        do
        {
            Console.WriteLine("1. Remove  2. Search  0. Exit\n");
            var choose = int.Parse(ReadString());
            switch (choose)
            {
                case 1:
                {
                    Console.Write("Input string to remove: ");
                    var elem = ReadString();
                    time = CalcTicks(() => _hashTable.Delete(elem));
                    _hashTable.Show();
                    PrintTicks("\ntime delete element to fnv hashtable:", time);
                    break;
                }
                case 2:
                {
                    Console.Write("Input string to search: ");
                    var elem = ReadString();
                    time = CalcTicks(() => _hashTable.Search(elem));
                    _hashTable.Show();
                    Console.WriteLine(_hashTable.Search(elem) ? "exists" : "does not exist");
                    PrintTicks("\ntime search element to fnv hashtable: ", time);
                    break;
                }
                case 0:
                    return;
            }
        } while (true);
    }
}
