#include "functionality.h"

void hoara_sort(forward_list<int> &numbers, int left, int right)
{
    int pivot;
    int l_hold = left;
    int r_hold = right;
    pivot = get_item_by_id(numbers, left);
    while (left < right)
    {
        while ((get_item_by_id(numbers, right) >= pivot) && (left < right))
            right--;
        if (left != right)
        {
            int a = get_item_by_id(numbers, left);
            int b = get_item_by_id(numbers, right);
            numbers = change_value_by_id(numbers, left, b);
            left++;
        }
        while ((get_item_by_id(numbers, left) <= pivot) && (left < right))
            left++;
        if (left != right)
        {
            int a = get_item_by_id(numbers, left);
            int b = get_item_by_id(numbers, right);
            numbers = change_value_by_id(numbers, right, a);
            right--;
        }
    }
    numbers = change_value_by_id(numbers, left, pivot);
    pivot = left;
    left = l_hold;
    right = r_hold;
    if (left < pivot)
        hoara_sort(numbers, left, pivot - 1);
    if (right > pivot)
        hoara_sort(numbers, pivot + 1, right);
}