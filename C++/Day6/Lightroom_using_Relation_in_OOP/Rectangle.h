#ifndef RECTANGLE_H
#define RECTANGLE_H
#include "Point.h"


class Rectangle
{
    int color;
    Point UL;
    Point LR;

    public:
        Rectangle();
        Rectangle(int , int , int , int , int);
        virtual ~Rectangle();

        //virtual void DrawRectangle();

    protected:

    private:


};





#endif // RECTANGLE_H
