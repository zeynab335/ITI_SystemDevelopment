#include <iostream>
//#include "E:\MAHA\SD ITI\Programs\Code Blocks\MinGW\include\graphics.h"
//#include "E:\MAHA\SD ITI\Programs\Code Blocks\MinGW\include\winbgim.h"
#include "G:\ProgramSetup\CodeBlocks\MinGW\include\graphics.h"

#include<conio.h>

using namespace std;


class shapeColor
{
    protected :
     int color ;
     shapeColor ()
     {
        color = 0 ;
     }
     shapeColor(int clr)
     {
         color = clr ;
     }
     ~shapeColor()
     {
        // cout<<"shapeColor destructor"<<endl ;
     }
public :
     void draw ()
     {
         setcolor(color) ;
     }
};


class point
{
    int x , y ;

public :

///constructors & destructor
    point ()
    {
        x = y = 0 ;
      //  cout<<"Point Parameterless constructor "<<endl ;
    }

    point (int _x ,int _y)
    {
        x = _x ;
         y = _y ;
       // cout<<"Point constructor with parameters"<<endl ;
    }

    ~point ()
    {
        //cout<<"Point destructor"<<endl ;
    }

    ///setters & getters

void setX(int _x){x = _x ; }
void setY(int _y){y = _y ; }

int getX(){return x ; }
int getY(){return y ; }


   void show()
   {

       cout<<"("<<x<<","<<y<<")"<<endl ;
   }

};

/// Abstracted class
class Shape : public shapeColor
{

public :

    Shape ()
    {
  //cout<<"Shape Parameterless constructor "<<endl ;
    }

virtual void draw () = 0 ;

};



class rect : public Shape
{
    point ul ; ///Composition
    point lr ; ///Composition
public :

    rect ()
    {
 // cout<<"Rect Parameterless constructor "<<endl ;
    }

    /// constructors chaining
rect (int x1 , int y1 , int x2 ,int y2 , int clr)
:  ul(x1,y1) , lr(x2,y2)
    {
  //cout<<"Rect Parameter constructor "<<endl ;
    }

    ~rect ()
    {
          // cout<<"Rect destructor"<<endl ;
    }

void draw () override
{
    ///from graphics.h
    shapeColor::draw() ;
    rectangle(ul.getX(), ul.getY() , lr.getX() , lr.getY() ) ;
}


};

class Line : public Shape
{

point first ; ///Composition
point sec ; ///Composition

public :

    Line ()
    {
  //cout<<"line Parameterless constructor "<<endl ;
    }

    /// constructors chaining
Line (int x1 , int y1 , int x2 ,int y2, int clr)
: first(x1,y1) , sec(x2,y2)
    {
 // cout<<"line Parameter constructor "<<endl ;
    }
    ~Line ()
    {
         //  cout<<"line destructor"<<endl ;
    }

void draw() override
{
    ///from graphics.h
      shapeColor::draw() ;
    line(first.getX(), first.getY() , sec.getX() , sec.getY()) ;
}

};


class Circle: public Shape
{

point cent ; ///Composition
int radius ;

public :

    Circle ()
    {
  //cout<<"circle Parameterless constructor "<<endl ;
    }

    /// constructors chaining
Circle (int x1 , int y1 , int _radius , int clr)
: cent(x1,y1)
    {
        radius = _radius ;
  //cout<<"circle Parameter constructor "<<endl ;
    }

    ~Circle ()
    {
          // cout<<"circle destructor"<<endl ;
    }

void draw () override
{
    ///from graphics.h
      shapeColor::draw() ;
    circle(cent.getX(), cent.getY() ,radius) ;
}
};

///Aggregation

class Pic
{
    Shape **pShape ;
    int SNum ;

 public :
    Pic ()
    {
        SNum = 0 ;
        pShape=NULL;
       // cout<<"parameterless Pic constructor"<<endl ;
    }

    Pic (Shape **SArr , int s  )
    {
       SNum = s ;
        pShape = SArr;
      // cout<<"parameter Pic constructor"<<endl ;
    }

    ~Pic() {

         delete []pShape ;

        //cout<<"Pic destructor"<<endl ;
        }


void Paint ()
{

    for (int i=0 ; i<SNum ; i++)
    {
       pShape[i]->draw() ;
    }
}
};





int main()
{
 initgraph() ;

 Pic *p ;
Shape *shape[9] =
{new rect (370,355,480,384,7),
new rect (420,260,437,355,7),
new Line(410,160,390,211,7),
new Line(445,160,465,211,7),
new Line(390,364,382,374,7),
new Line(390,364,400,376,7),
new Line(382,374,400,376,7),
new Circle(428,220,77,7),
new Circle(428,155,33,7)
};

Pic(shape, 9);

p->Paint() ;


    return 0;
}
