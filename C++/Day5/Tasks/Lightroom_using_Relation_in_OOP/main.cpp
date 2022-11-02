#include <iostream>
#include "G:\ProgramSetup\CodeBlocks\MinGW\include\graphics.h"
#include <conio.h>
#include "Point.h"


/// import classes
using namespace std;



class Line
{
    public:

        Point UL;
        Point LR;
        int color;

        Line(int x1 , int y1 , int x2 , int y2 , int c):UL(x1,y1),LR(x2,y2){
            color = c;
            cout << "cons of Line" << endl ;
        }
        ~Line(){}
        /// end cons and destructor

         void DrawLines(){
            int v1 = UL.getWidth();
            int v2 = UL.getHeight();
            int v3 = LR.getWidth();
            int v4 = LR.getHeight();
            setcolor(color);

            line(v1 , v2 , v3 , v4);
        }

};


class Rect
{
    Line L;
    int color;
    public:

        Rect(int x1_ , int y1_ , int x2_ , int y2_ , int c):L(x1_,y1_,x2_,y2_ , c){
            cout << "cons of Rectangle" << endl ;
        }
        ~Rect(){}
        /// end cons and destructor

        void DrawRectangle(){
            int v1 = L.UL.getWidth();
            int v2 = L.UL.getHeight();
            int v3 = L.LR.getWidth();
            int v4 = L.LR.getHeight();

            rectangle(v1 , v2 , v3 , v4);
        }


};


class Circle
{
    int center , color;
    Point XY;
    public:
        Circle(int x , int y ,int center_ ,int c):XY(x,y){
            cout << "Cons of Circle" << endl ;
            center = center_;
            color = c;
        }
        ~Circle(){}
        /// end cons and destructor
        void DrawCircle(){
            setcolor(color);
            circle(XY.getWidth() , XY.getHeight() , center);
        }
};


class Triangle
{
    Line L1;
    Line L2;
    Line L3;
    int color;
    public:
        Triangle(int x[4] , int y[4] , int z[4] , int c)
        :L1(x[0], x[1], x[2] , x[3] , c)
        ,L2(y[0], y[1], y[2] , y[3] , c)
        ,L3(z[0] ,z[1], z[2] , z[3] , c)
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

    Rect R(600,500, 950 ,590 , 3);

    Line l1(700, 300 ,700 ,500 , 3);
    Line l2(850, 300 ,850 ,500 , 3);

    Line l3(805, 100 ,850 ,300 , 3);
    Line l4(735, 100 ,700 ,300 , 3);

    Circle c1(775,300,150 , 3);
    Circle c2(770,120,80 , 3);

//    setbkColor(2);

    R.DrawRectangle();

    l1.DrawLines();
    l2.DrawLines();

    c1.DrawCircle();
    c2.DrawCircle();

    l3.DrawLines();
    l4.DrawLines();


    Triangle T(TX , TY , TZ , 5);
    T.DrawTriangle();



    getche();

    return 0;
}

