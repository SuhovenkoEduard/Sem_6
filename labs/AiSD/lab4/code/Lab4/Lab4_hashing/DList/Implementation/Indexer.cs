namespace Lab4_hashing.DList;

public partial class DLinkedList<T>
{
    public T this[int index]
    {
        get
        {
            if (index >= Count)
                throw new Exception("Out of bound exception, [get]");

            var curIndex = 0;
            var current = head;
            while (curIndex < index)
            {
                current = current!.Next;
                curIndex += 1;
            }

            return current!.Value;
        }

        set
        {
            if (index >= Count)
                throw new Exception("Out of bound exception, [get]");

            var curIndex = 0;
            var current = head;
            while (curIndex < index)
            {
                current = current!.Next;
                curIndex += 1;
            }

            current!.Value = value;
        }
    }
}