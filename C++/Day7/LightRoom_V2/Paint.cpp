#include <iostream>
#include "Paint.h"

/// Start cons and destructor
Point::Point(){
    x = 0; y = 0;
    //std::cout << "Parameterless Point Cons \n" ;
}

/// OverLoading Cons
Point::Point(int x_ , int y_){
    x = x_ ; y = y_ ;
}

Point::~Point(){}
/// end cons and destructor



/// start Setter and getter methods
Point::setWidth(int value){x=value;}
Point::setHeight(int value){y=value;}
Point::getWidth(){return x;}
Point::getHeight(){return y;}
/// end Setter and getter methods


/// start Methods in Point Class
void Point::show(){std::cout << "Point = (" << x << "," << y << ")" << std::endl ;}

/// end Methods in Point Class

