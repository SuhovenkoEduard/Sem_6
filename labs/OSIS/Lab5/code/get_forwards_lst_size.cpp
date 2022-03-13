#include "functionality.h"

int get_forwards_lst_size(forward_list<int> numbers)
{
    return distance(numbers.begin(), numbers.end());
}