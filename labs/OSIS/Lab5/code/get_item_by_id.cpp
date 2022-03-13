#include "functionality.h"

int get_item_by_id(forward_list<int> numbers, int id)
{
    // it is considered that id is an integer between 0 and size - 1...
    int size = get_forwards_lst_size(numbers);
    if (id >= 0 && id < size)
    {
        auto current = numbers.begin();
        while (id--)
            current++;
        return *current;
    }
    return -1;
}