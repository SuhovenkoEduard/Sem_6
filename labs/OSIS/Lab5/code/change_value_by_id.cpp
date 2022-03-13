#include "functionality.h"

forward_list<int> change_value_by_id(forward_list<int> numbers, int id, int new_value)
{
    int size = get_forwards_lst_size(numbers);
    if (id >= 0 && id < size)
    {
        auto current = numbers.begin();
        while (id--)
            current++;
        *current = new_value;
    }
    return numbers;
}