#include "Circle.h"
#include <iostream>

Circle::Circle()
{
    std::cout << "Cons Circle \n";
}

Circle::~Circle()
{
    std::cout << "destructor of Circle ";
}


 /// Override fun [when type of inheretance is public]  ==> to prevent access parent from child
//setDim1(int d){Dim1 = Dim2 = d;}
//setDim2(int d){Dim1 = Dim2 = d;}

/// create new fun to calculate area in circle
void Circle::setDim(int d1){Dim1 = Dim2 = d1;}
int Circle::getDim(){return Dim1;}

double Circle::CalcArea(){
    double res = 3.14*Dim1*Dim2 ;
    std::cout << "Circle Area =  "<< res << "\n";
    return res;
}

