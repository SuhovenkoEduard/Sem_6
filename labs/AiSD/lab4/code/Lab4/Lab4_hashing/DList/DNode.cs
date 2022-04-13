namespace Lab4_hashing.DList;

public class DNode<T>
{
    public DNode(T value)
    {
        Value = value;
        Next = Prev = null;
    }

    public DNode<T>? Next { get; set; }
    public DNode<T>? Prev { get; set; }
    public T Value { get; set; }
}