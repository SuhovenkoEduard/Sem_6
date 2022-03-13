#include "sphere.h"

double Sphere::calculate_volume()
{
    return 4. / 3. * 3.14159265358979323846 * get_radius() * get_radius() * get_radius();
}