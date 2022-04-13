namespace Lab4_hashing.DList;

public partial class DLinkedList<T>
{
    public void RemoveAt(int index)
    {
        Erase(index);
    }

    public bool Remove(T item)
    {
        var index = IndexOf(item);
        if (index != -1)
            Erase(index);

        return index != -1;
    }

    public T Shift()
    {
        return Erase(0);
    }

    public T Pop()
    {
        return Erase(Count - 1);
    }

    public T Erase(int index)
    {
        if (index >= Count)
            throw new Exception("Out of bound exception, [erase]");

        T deletedValue;
        if (Count == 1)
        {
            deletedValue = head!.Value;
            head = tail = null;
        }
        else
        {
            if (index == 0)
            {
                deletedValue = head!.Value;
                head = head!.Next;
                head!.Prev = null!;
            }
            else if (index == Count - 1)
            {
                deletedValue = tail!.Value;
                tail = tail!.Prev;
                tail!.Next = null;
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

                deletedValue = tempNode!.Next!.Value;
                tempNode!.Next = tempNode.Next!.Next;
                tempNode.Next!.Prev = tempNode;
            }
        }

        Count -= 1;
        return deletedValue;
    }
}