#ifndef SQUARE_H
#define SQUARE_H

#include "Rectangle.h"


class Square:public Rectangle
{
    public:
        Square();
        Square(int d1 ,int d2):Rectangle(d1,d2){}
        virtual ~Square();
        void setDim1(int);
        void setDim2(int);

    protected:

    private:
};

#endif // SQUARE_H
