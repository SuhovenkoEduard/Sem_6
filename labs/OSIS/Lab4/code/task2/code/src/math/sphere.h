#pragma once

class Sphere
{
private:
    double m_radius;

public:
    Sphere(double radius);
    void set_radius(double radius);
    double get_radius();
    double calculate_surface_area();
    double calculate_volume();
};