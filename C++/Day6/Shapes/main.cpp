#include <iostream>
#include "Shape.h"

#include "Rectangle.h"
#include "Square.h"
#include "Circle.h"
#include "Triangle.h"


using namespace std;



/// Calculate all area [using one obj]
int getShapesArea(Rectangle R1 , Square S1 , Circle C1 , Triangle T1){

    return R1.CalcArea() + S1.CalcArea() + C1.CalcArea() + T1.CalcArea();

}


/// Calculate all area [using one obj]  ==> using static size
int getShapesArea(Rectangle *R1 , Square *S1 , Circle *C1 , Triangle *T1){
    int sum = 0;
    cout  << "\n\nStart Showing each area of shapes \n\n";
    for(int i=0 ; i<2 ; i++)
        sum += R1[i].CalcArea() + S1[i].CalcArea() + C1[i].CalcArea() + T1[i].CalcArea();

    return sum;
}

/// Calculate all area [using one obj]  ==> using Dynamic size
int getShapesAreaDynaimcSize(Rectangle *R1 , Square *S1 , Circle *C1 , Triangle *T1 , int R_Size , int S_Size , int C_Size , int T_Size){
    int sum = 0;

    cout  << "\n\nStart Showing each area of shapes \n\n";
    for(int i=0 ; i<R_Size ; i++)
        sum += R1[i]    .CalcArea();

    for(int i=0 ; i<S_Size ; i++)
        sum += S1[i].CalcArea() ;

    for(int i=0 ; i<C_Size ; i++)
        sum += C1[i].CalcArea() ;

    for(int i=0 ; i<T_Size ; i++)
        sum += T1[i].CalcArea() ;


    return sum;
}


int main()
{


    /// Rectangle
    Rectangle r1(10,20);
    r1.CalcArea() ;


    /// Square
    Square s1 ;
    s1.setDim1(10);   /// initialize override fun in square class
    s1.setDim2(10);
    s1.CalcArea();

    /// Circle
    Circle c1;
    c1.setDim(5);
    c1.CalcArea();

    /// Triangle
    Triangle t1;
    t1.setDim1(10);
    t1.setDim2(20);
    t1.CalcArea() ;




    /// /*****************************************************************************/


    //Rectangle R_Arr[2];

    Rectangle *R_Arr = new Rectangle[2];

    R_Arr[0].setDim1(10);
    R_Arr[0].setDim2(10);
    R_Arr[1].setDim1(20);
    R_Arr[1].setDim2(20);


    /// another style to initialize array of objects
    Square    S_Arr[2] = {Square(10,10) , Square(20,20)};
    Triangle  T_Arr[2] = {Triangle(10,20) , Triangle(10,20)};
    Circle    C_Arr[2] = {Circle(10,10) , Circle(10,10)};





    //cout << "\nAll Shapes Area = " << getShapesArea(r1,s1,c1,t1) << "\n" <<endl;
    cout << "\nAll Shapes Area using Pointers = " << getShapesArea(R_Arr,S_Arr,C_Arr,T_Arr) << "\n" <<endl;
    cout << "\nAll Shapes Area using Pointers = " << getShapesAreaDynaimcSize(R_Arr,S_Arr,C_Arr,T_Arr , 2 ,2,2,2) << "\n" <<endl;






    return 0;
}
