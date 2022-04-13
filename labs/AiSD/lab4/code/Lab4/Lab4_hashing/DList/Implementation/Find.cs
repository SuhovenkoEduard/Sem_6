namespace Lab4_hashing.DList;

public partial class DLinkedList<T>
{
    public bool Contains(T item)
    {
        return Find(x => x!.Equals(item));
    }

    public bool Find(Func<T, bool> predicate)
    {
        var tempNode = head;
        while (tempNode != null)
        {
            if (predicate(tempNode.Value))
                return true;
            tempNode = tempNode.Next;
        }

        return false;
    }
}