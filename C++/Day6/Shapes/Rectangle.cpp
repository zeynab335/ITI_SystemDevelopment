#include "Rectangle.h"
#include <iostream>


Rectangle::Rectangle()
{
    std::cout << "Cons Rectangle \n" ;
}

/// chain Constractor

Rectangle::~Rectangle()
{
    std::cout << "destructor Rectangle \n";
}

double Rectangle::CalcArea(){
    double res = Dim1 * Dim2;
    std::cout << "Rectangle Area =  "<< res << "\n";
    return res;
}
