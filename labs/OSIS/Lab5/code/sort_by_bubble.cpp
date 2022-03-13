#include "functionality.h"

forward_list<int> sort_by_bubble(forward_list<int> numbers)
{
    int size = get_forwards_lst_size(numbers);
    for (int i = 0; i < size; i++)
    {
        for (int j = 0; j < size - 1; j++)
        {
            int a = get_item_by_id(numbers, j);
            int b = get_item_by_id(numbers, j + 1);
            if (a > b)
            {
                numbers = change_value_by_id(numbers, j, b);
                numbers = change_value_by_id(numbers, j + 1, a);
            }
        }
    }
    return numbers;
}