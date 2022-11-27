#ifndef RECTANGLE_H
#define RECTANGLE_H
#include "Shape.h"

class Rectangle:public Shape
{
    public:
        Rectangle();
        Rectangle(int d1 ,int d2);
        virtual ~Rectangle();
        double CalcArea();

    protected:

    private:
};

#endif // RECTANGLE_H
