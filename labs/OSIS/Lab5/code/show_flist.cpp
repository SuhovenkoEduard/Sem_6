#include <iostream>
#include "functionality.h"

void show_flst(forward_list<int> numbers)
{
    cout << "My FORWARD LIST: " << endl;
    auto current = numbers.begin();
    auto end = numbers.end();
    while (current != end)
    {
        std::cout << *current << endl;
        current++;
    }
}