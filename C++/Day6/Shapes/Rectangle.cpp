#include "Rectangle.h"
#include <iostream>


Rectangle::Rectangle()
{
    std::cout << "Cons Rectangle \n" ;
}

Rectangle::Rectangle(int d1 ,int d2){Dim1=d1 ; Dim2=d2 ; std::cout << "rectangle cons \n" ;}


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
