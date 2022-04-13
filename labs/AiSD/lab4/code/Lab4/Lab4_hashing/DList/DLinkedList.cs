namespace Lab4_hashing.DList;

public partial class DLinkedList<T> : IList<T>
{
    private DNode<T>? head;
    private DNode<T>? tail;

    public DLinkedList()
    {
        head = tail = null;
        Count = 0;
    }

    public int Count { get; private set; }
}