#include <iostream>
#include "functionality.h"

void my_fun(forward_list<int> numbers)
{
    list<int> negative_elements;
    for (int n : numbers)
        if (n < 0)
            negative_elements.push_back(n);
    if (negative_elements.empty())
        cout << "No negative elements... " << endl;
    else
    {
        std::list<int>::const_iterator
            max_negative =
                max_element(negative_elements.begin(), negative_elements.end());
        cout << "Max negative is " << *max_negative << endl;
    }
}