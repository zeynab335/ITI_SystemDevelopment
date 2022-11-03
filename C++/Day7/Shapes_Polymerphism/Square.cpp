#include "Square.h"
#include <iostream>


Square::Square()
{
    std::cout << "Cons Square \n";
}

Square::~Square()
{
    std::cout << "destructor of Square \n";
}

/// Override fun [when type of inheretance is public]  ==> to prevent access parent from child
void Square::setDim1(int d){Dim1 = Dim2 = d;}
void Square::setDim2(int d){Dim1 = Dim2 = d;}

