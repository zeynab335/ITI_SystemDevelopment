#ifndef CIRCLE_H
#define CIRCLE_H

#include "Shape.h"

class Circle: protected Shape
{
    public:
        Circle();
        Circle(int D1 , int D2):Shape(D1,D2){}

        virtual ~Circle();

        /// create new fun to calculate area in circle
        void setDim(int);
        int  getDim();

        int CalcArea();



    protected:

    private:
};

#endif // CIRCLE_H
