#include <iostream>
#include "Shape.h"

#include "Rectangle.h"
#include "Square.h"
#include "Circle.h"
#include "Triangle.h"



using namespace std;


/// Calculate all area [using one obj]  ==> using Dynamic size
double getShapesAreaDynaimcSize(Shape** ShapesArr , int Size){
    double sum = 0;

    cout  << "\n\nStart Showing each area of shapes \n\n";

    for(int i=0 ; i<Size ; i++)
        sum += ShapesArr[i]->CalcArea() ;

    cout  << "\n\nStart Showing sum of areas of shapes \n";
    return sum;
}


int main()
{

    Rectangle *R_Arr = new Rectangle[2];

    R_Arr[0].setDim1(10);
    R_Arr[0].setDim2(10);
    R_Arr[1].setDim1(20);
    R_Arr[1].setDim2(20);


    /// another style to initialize array of objects
    Square    S_Arr[2] = {Square(10,10) , Square(20,20)};
    Triangle  T_Arr[2] = {Triangle(10,20) , Triangle(10,20)};
    Circle    C_Arr[2] = {Circle(10,10) , Circle(10,10)};


    Shape *ShapesArr[8] = {R_Arr , &R_Arr[1] , S_Arr , &S_Arr[1] , T_Arr , &T_Arr[1], C_Arr , &C_Arr[1]};

    cout  << getShapesAreaDynaimcSize(ShapesArr , 8) << "\n\n" ;








    return 0;
}
