namespace Lab4_hashing.DList;

public partial class DLinkedList<T>
{
    public int IndexOf(T item)
    {
        return IndexOf(x => x!.Equals(item));
    }

    public int IndexOf(Func<T, bool> predicate)
    {
        var index = 0;
        var tempNode = head;
        while (tempNode != null)
        {
            if (predicate(tempNode.Value))
                return index;
            tempNode = tempNode.Next;
            index += 1;
        }

        return -1;
    }
}