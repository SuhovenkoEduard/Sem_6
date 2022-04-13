namespace Lab4_hashing.DList;

public partial class DLinkedList<T>
{
    public void CopyTo(T[] array, int arrayIndex)
    {
        const string baseErrorMessage = "DLinkedList[IList::CopyTo]";
        if (array == null)
            throw new Exception($"{baseErrorMessage} Array is null.");
        if (arrayIndex < 0)
            throw new Exception($"{baseErrorMessage} ArrayIndex is less than zero.");
        if (array.Rank > 1)
            throw new Exception($"{baseErrorMessage} Array is multidimensional.");
        if (array.Length - arrayIndex < Count)
            throw new Exception($"{baseErrorMessage} Not enough elements after index in the destination array.");
        for (var i = 0; i < Count; ++i)
            array.SetValue(this[i], i + arrayIndex);
    }

    public bool IsReadOnly => false;
}