using Lab4_hashing.DList;

namespace Lab4_hashing.HsTable;

public delegate int HashLengthFunc(string s, int length);
public delegate int HashFunc(string s);

public class HashTable
{
    private readonly DLinkedList<string>[] _array;

    private HashFunc GetHash { get; }
    
    public HashTable(HashLengthFunc hashFunc, int length = 50)
    {
        _array = new DLinkedList<string>[length];
        for (var i = 0; i < _array.Length; i++) {
            _array[i] = new DLinkedList<string>();
        }
        GetHash = s => hashFunc(s, length);
    }

    public void AddMany(IEnumerable<string> strings) => strings.ToList().ForEach(s => _array[GetHash(s)].Add(s));
    public void Delete(string s) => _array[GetHash(s)].Remove(s);
    public bool Search(string s) => _array[GetHash(s)].Contains(s);
    
    public void Show()
    {
        for (var i = 0; i < _array.Length; i++)
            Console.Write($"{i} | {_array[i].Aggregate("", (current, s) => current + s + " ")} \n");
        Console.WriteLine();
    }
}