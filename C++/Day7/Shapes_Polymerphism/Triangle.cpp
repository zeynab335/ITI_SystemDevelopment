#include "Triangle.h"
#include <iostream>



Triangle::Triangle()
{
    std::cout << "Cons Triangle \n" ;
}

Triangle::~Triangle()
{
    std::cout << "Cons Triangle \n" ;
}

double Triangle::CalcArea(){
    double res = 0.5 * Dim1 * Dim2 ;
    std::cout << "Triangle Area =  "<< res << "\n";
    return res;
}
