#include "functionality.h"

forward_list<int> remove_item_by_id(forward_list<int> numbers, int id)
{
    int size = get_forwards_lst_size(numbers);
    if (id >= 0 && id < size)
    {
        auto current = numbers.begin();
        id--;
        while (id--)
            current++;
        numbers.erase_after(current);
    }
    return numbers;
}