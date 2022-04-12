using Lab4_hashing.DList;

DLinkedList<int> dlist = new();

int[] arr = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

foreach (var x in arr) dlist.Push(x);

Console.WriteLine(string.Join(", ", dlist.Where(x => x >= 5).ToList()));

foreach (var x in dlist) Console.WriteLine(x);