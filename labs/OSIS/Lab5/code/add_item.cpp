#include "functionality.h"

forward_list<int> add_item(forward_list<int> numbers, int new_item)
{
    numbers.push_front(new_item);
    return numbers;
}