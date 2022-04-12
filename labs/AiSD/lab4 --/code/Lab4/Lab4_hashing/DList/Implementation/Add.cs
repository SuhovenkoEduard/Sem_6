namespace Lab4_hashing.DList;

public partial class DLinkedList<T>
{
    public void Add(T item)
    {
        Push(item);
    }

    public void Insert(int index, T value)
    {
        if (index > Count)
            throw new Exception("Out of bound exception, [insert]");

        var node = new DNode<T>(value);
        if (index == 0)
        {
            if (Count == 1)
            {
                node.Next = head;
                head!.Prev = node;
            }
            else if (Count > 1)
            {
                head!.Prev = node;
                node.Next = head;
            }

            head = node;
        }
        else if (index == Count)
        {
            tail!.Next = node;
            node.Prev = tail;
        }
        else
        {
            var curIndex = 0;
            var tempNode = head;
            while (curIndex < index - 1 && tempNode?.Next != null)
            {
                tempNode = tempNode.Next;
                curIndex++;
            }

            node.Next = tempNode?.Next;
            node.Prev = tempNode;
            tempNode!.Next = node;
            node.Next!.Prev = node;
        }

        if (index == Count)
            tail = node;
        Count++;
    }

    public void UnShift(T value)
    {
        Insert(0, value);
    }

    public void Push(T value)
    {
        Insert(Count, value);
    }
}