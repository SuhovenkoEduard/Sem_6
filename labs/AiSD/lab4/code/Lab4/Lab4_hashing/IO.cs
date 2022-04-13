using Lab4_hashing.DList;

namespace Lab4_hashing;

public class IO
{
    public static string[] ReadFile(string path)
    {
        var words = new DLinkedList<string>();
        using (var reader = new StreamReader(path))
        {
            string line;
            while ((line = reader.ReadLine() ?? string.Empty) != "") words.Add(line);
        }

        return words.ToArray();
    }
}