using Lab4_hashing;
using Lab4_hashing.HashFunctions;
using Lab4_hashing.HsTable;

string[] hashTypes = { "Additive", "Middle" };
const string path = "../../../resources/words.txt";

var main = () =>
{
    do
    {
        for (var i = 0; i < hashTypes.Length; ++i)
            Console.WriteLine($"{i + 1}. {hashTypes[i]}");
        
        var choose = int.Parse(Console.ReadLine() ?? string.Empty);
        var data = IO.ReadFile(path);
        var additiveHashTable = new HashTable(Additive.HashFunc);
        var middleHashTable = new HashTable(Middle.HashFunc);
        var additiveMenu = new Menu(additiveHashTable, data, hashTypes[0]);
        var middleMenu = new Menu(middleHashTable, data, hashTypes[1]);
        switch (choose)
        {
            case 1:
                additiveMenu.Run();
                break;
            case 2:
                middleMenu.Run();
                break;
        }
    } while (true);
};

main();

// DLinkedList<string> dlist = new();
// string[] arr = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"};
// foreach (var x in arr) dlist.Add(x);
// Console.WriteLine(string.Join(", ", dlist.Where(x => x.CompareTo("8") >= 0)).ToList());
// foreach (var x in dlist) Console.WriteLine(x);
