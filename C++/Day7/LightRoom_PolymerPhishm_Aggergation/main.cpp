#include <iostream>
#include "G:\ProgramSetup\CodeBlocks\MinGW\include\graphics.h"
#include <conio.h>
#include "Point.h"


/// import classes
using namespace std;

class Color{

    int color;

    public:
        Color(){ color = 0; cout << "cons color \n" ;}
        Color(int c){ color = c;}
        ~Color(){cout << "cons color \n" ;}

        void SetColor(){setcolor(color);}

};


class Line:public Color
{
    public:

        Point UL;
        Point LR;
        Line(){}
        Line(int x1 , int y1 , int x2 , int y2 , int c):UL(x1,y1),LR(x2,y2),Color(c){
            cout << "line" ;
        }
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
        Circle(){}
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

/*
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
};*/

class Triangle
{
    Line *L;
    int LSize ;

    public:
        Triangle(Line *L1 , int s)
        {
            L = L1;
            LSize = s;
            cout << "Cons of Triangle" << endl ;
        }
        ~Triangle(){cout << "Destructor of Triangle" << endl ;}
        /// end cons and destructor
        void DrawTriangle(){
            for(int i=0 ; i<LSize ; i++){
                L[i].DrawLines();
            }

        }
};




class Picture_V1{

    /// Start making Aggregation relationship
    Rect *R;
    Circle *C;
    Triangle *T;
    Line *L;
    int S_Lines ;
    int S_Circles ;

    public:
        Picture_V1(){ cout << "cons Picture_V1 \n" ;}
        Picture_V1(Rect *R1 , Circle *C1 , Triangle *T1 , Line *L1 , int SLines , int SCircles){
            R = R1;
            T = T1;

            C = C1;
            S_Circles = SCircles;

            L = L1;
            S_Lines = SLines;
        }

        ~Picture_V1(){cout << "cons Picture_V1 \n" ;}


        void Paint(){
            cout << "Draw" ;
            R->DrawRectangle();
            T->DrawTriangle();
             for(int i=0 ; i<S_Lines ; i++){
                L[i].DrawLines();
            }
            for(int i=0 ; i<S_Circles ; i++){
                C[i].DrawCircle();
            }

        }


        void setRect( Rect *R1){ R=R1;}
        void setTriangle( Triangle *T1){ T=T1;}

        void setLines( Line *L1 , int SLines){
            L = L1;
            S_Lines = SLines;

        }
        void setCircle( Circle *C1 , int SCircles){
            C = C1;
            S_Circles = SCircles;
        }


};






int main()
{

    initgraph();

    Rect *R = new Rect(600,500, 950 ,590 , 5);

    Line *T_Line = new Line[3];
    T_Line[0] = Line(600, 570, 650 , 500, 5);
    T_Line[1] = Line(600 , 570 , 750 , 570, 3);
    T_Line[2] = Line(650, 500 , 750 , 570 , 4);

    Triangle *T = new Triangle(T_Line , 3);


    Line *L   = new Line[4];

    L[0] = Line(700, 300 ,700 ,500 , 5);
    L[1] = Line(850, 300 ,850 ,500 , 5);

    L[2] = Line(805, 100 ,850 ,300 , 5);
    L[3] = Line(735, 100 ,700 ,300 , 5);


    Circle *C = new Circle[2];

    C[0] = Circle(775,300,150 , 5);
    C[1] = Circle(770,120,80 , 5);


    Picture_V1 *P1 = new Picture_V1(R, C , T , L , 4,2);

    P1->Paint();

    getche();

    return 0;
}

