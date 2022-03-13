#include <iostream>
#include "math/sphere.h"
#include "math/calculate_surface_area.cpp"
#include "math/calculate_volume.cpp"
#include "math/get_radius.cpp"
#include "math/set_radius.cpp"
#include "math/sphere.cpp"

using namespace std;

int main()
{
    double R1, R2, vol1, vol2, square1, square2;
    cout << "Enter R1: " << endl;
    cin >> R1;
    cout << "Enter R2: " << endl;
    cin >> R2;
    Sphere sphere1(R1);
    Sphere sphere2(R2);
    vol1 = sphere1.calculate_volume();
    vol2 = sphere2.calculate_volume();
    square1 = sphere1.calculate_surface_area();
    square2 = sphere2.calculate_surface_area();
    cout << "-----------------------------" << endl;
    cout << "First SPHERE: " << endl;
    cout << "R = " << R1 << ";" << endl;
    cout << "Volume = " << vol1 << ";" << endl;
    cout << "Surface area = " << square1 << ";\n"
         << endl;
    cout << "-----------------------------" << endl;
    cout << "Second SPHERE: " << endl;
    cout << "R = " << R2 << ";" << endl;
    cout << "Volume = " << vol2 << ";" << endl;
    cout << "Surface area = " << square2 << ";\n"
         << endl;
    if (vol1 > vol2)
        cout << "The first spheres volume greater then the seconds one." << endl;
    else if (vol1 < vol2)
        cout << "The second spheres volume greater then the first one." << endl;
    else
        cout << "Volumes are equal!" << endl;
    if (square1 > square2)
        cout << "The first spheres surface area greater then the seconds one." << endl;
    else if (square1 < square2)
        cout << "The second spheres surface area greater then the first one." << endl;
    else
        cout << "Surface areas are equal!" << endl;
    return 0;
}