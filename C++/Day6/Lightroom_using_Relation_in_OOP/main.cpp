#include <iostream>
#include "G:\ProgramSetup\CodeBlocks\MinGW\include\graphics.h"
#include <conio.h>
#include "Point.h"


/// import classes
using namespace std;


class Color{

    int color;

    public:
        Color(){ cout << "cons color \n" ;}
        Color(int c){ color = c;}
        ~Color(){cout << "cons color \n" ;}

        void SetColor(){setcolor(color);}

};


class Line:public Color
{
    public:

        Point UL;
        Point LR;

        Line(int x1 , int y1 , int x2 , int y2 , int c):UL(x1,y1),LR(x2,y2),Color(c){}
        ~Line(){}
        /// end cons and destructor

         void DrawLines(){
            SetColor();
            line(UL.getWidth() , UL.getHeight() , LR.getWidth() ,  LR.getHeight());

        }

};


class Rect:Color
{
    Point UL;
    Point LR;
    public:

        Rect(int x1_ , int y1_ , int x2_ , int y2_ , int c):UL(x1_,y1_),LR(x2_,y2_),Color(c){}
        React(){cout << "cons of Rectangle" << endl ;}

        ~Rect(){cout << "des of Rectangle" << endl ;}
        /// end cons and destructor

        void DrawRectangle(){
            SetColor();
            rectangle(UL.getWidth() , UL.getHeight() , LR.getWidth() ,  LR.getHeight());
        }
};


class Circle:public Color
{
    int center;
    Point XY;
    public:
        Circle(int x , int y ,int center_ ,int c):XY(x,y),Color(c){
            cout << "Cons of Circle" << endl ;
            center = center_;
        }
        ~Circle(){}
        /// end cons and destructor
        void DrawCircle(){
            SetColor();
            circle(XY.getWidth() , XY.getHeight() , center);
        }
};


class Triangle
{
    Line L1;
    Line L2;
    Line L3;
    public:
        Triangle(int x[4] , int y[4] , int z[4] , int c1 , int c2 , int c3)
        :L1(x[0], x[1], x[2] , x[3] , c1)
        ,L2(y[0], y[1], y[2] , y[3] , c2)
        ,L3(z[0] ,z[1], z[2] , z[3] , c3)
        {
            cout << "Cons of Triangle" << endl ;
        }
        ~Triangle(){cout << "Destructor of Triangle" << endl ;}
        /// end cons and destructor
        void DrawTriangle(){
           L1.DrawLines();
           L2.DrawLines();
           L3.DrawLines();
        }
};


int main()
{
    /// Triangle lines array
    int TX[4] = {600, 570, 650 , 500};
    int TY[4] = {600 , 570 , 750 , 570};
    int TZ[4] = {650, 500 , 750 , 570};

    initgraph();

    Rect R(600,500, 950 ,590 , 5);

    Line l1(700, 300 ,700 ,500 , 5);
    Line l2(850, 300 ,850 ,500 , 5);

    Line l3(805, 100 ,850 ,300 , 5);
    Line l4(735, 100 ,700 ,300 , 5);

    Circle c1(775,300,150 , 5);
    Circle c2(770,120,80 , 5);

//    setbkColor(2);

    R.DrawRectangle();

    l1.DrawLines();
    l2.DrawLines();

    c1.DrawCircle();
    c2.DrawCircle();

    l3.DrawLines();
    l4.DrawLines();


    Triangle T(TX , TY , TZ , 5 , 3 ,4);
    T.DrawTriangle();



    getche();

    return 0;
}

