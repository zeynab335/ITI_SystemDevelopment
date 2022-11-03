#include "Shape.h"
#include <iostream>

Shape::Shape()
{
    std::cout << "Cons Shape \n";
}


Shape::Shape(int D1 , int D2 )
{
    Dim1 = D1;
    Dim2 = D2;
}


Shape::~Shape()
{
    std::cout << "destructor of Shape \n";
}


void Shape::setDim1(int d1){Dim1 = d1;}
void Shape::setDim2(int d2){Dim2 = d2;}
int Shape::getDim1(){return Dim1;}
int Shape::getDim2(){return Dim2;}

double Shape::CalcArea(){return 0;}

