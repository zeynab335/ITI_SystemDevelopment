#ifndef TRIANGLE_H
#define TRIANGLE_H

#include "Shape.h"

class Triangle:public Shape
{
    public:
        Triangle();
        Triangle(int d1 ,int d2):Shape(d1,d2){}

        virtual ~Triangle();
        double CalcArea() override;

    protected:

    private:
};

#endif // TRIANGLE_H
