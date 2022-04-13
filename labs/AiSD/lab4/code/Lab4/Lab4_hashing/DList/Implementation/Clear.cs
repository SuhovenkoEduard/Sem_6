namespace Lab4_hashing.DList;

public partial class DLinkedList<T>
{
    public void Clear()
    {
        while (Count > 0) Pop();
    }
}