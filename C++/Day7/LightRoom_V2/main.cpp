#include <iostream>
#include "G:\ProgramSetup\CodeBlocks\MinGW\include\graphics.h"
#include <conio.h>
#include "Paint.h"


/// import classes
using namespace std;


/// Abstract class
class Shapes{
    int color;

    public:
        Shapes(int c){ color = c ;}
        Shapes(){ cout << "cons Shapes \n" ;}

        ~Shapes(){cout << "cons Shapes \n" ;}

        void SetColor(){setcolor(color);}

        virtual void Draw() = 0;



};


class Line:public Shapes
{
    public:

        Point UL;
        Point LR;
        Line(){}
        Line(int x1 , int y1 , int x2 , int y2 , int c):UL(x1,y1),LR(x2,y2),Shapes(c){
            cout << "line" ;
        }
        ~Line(){}
        /// end cons and destructor

         void Draw() override{
            line(UL.getWidth() , UL.getHeight() , LR.getWidth() ,  LR.getHeight());

        }
};


class Rect:public Shapes
{
    Point UL;
    Point LR;
    public:

        Rect(int x1_ , int y1_ , int x2_ , int y2_ , int c):UL(x1_,y1_),LR(x2_,y2_),Shapes(c){}
        React(){cout << "cons of Rectangle" << endl ;}

        ~Rect(){cout << "des of Rectangle" << endl ;}
        /// end cons and destructor

        void Draw() override{
            rectangle(UL.getWidth() , UL.getHeight() , LR.getWidth() ,  LR.getHeight());
        }
};


class Circle:public Shapes
{
    int center;
    Point XY;
    public:
        Circle(){}
        Circle(int x , int y ,int center_ ,int c):XY(x,y),Shapes(c){
            cout << "Cons of Circle" << endl ;
            center = center_;
        }
        ~Circle(){}
        /// end cons and destructor
        void Draw() override{
            circle(XY.getWidth() , XY.getHeight() , center);
        }
};


class Triangle:Shapes
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
        void Draw() override{
            for(int i=0 ; i<LSize ; i++){
                L[i].Draw();
            }

        }
};




class Picture_V2{
    Shapes **SPtr;
    int Size;

    public:
        Picture_V2(){ cout << "cons Picture_V2 \n" ;}
        Picture_V2(Shapes **_SPtr , int s){
            SPtr = _SPtr;
            Size = s;
        }

        ~Picture_V2(){cout << "cons Picture_V2 \n" ;}

        void Paint(){

             for(int i=0 ; i<Size ; i++){
                SPtr[i]->SetColor();
                SPtr[i]->Draw();
            }
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


    Line *L   = new Line[4];
    L[0] = Line(700, 300 ,700 ,500 , 5);
    L[1] = Line(850, 300 ,850 ,500 , 5);
    L[2] = Line(805, 100 ,850 ,300 , 5);
    L[3] = Line(735, 100 ,700 ,300 , 5);


    Circle *C = new Circle[2];
    C[0] = Circle(775,300,150 , 5);
    C[1] = Circle(770,120,80 , 5);



    Shapes *SPTr[10] = {R , T_Line , &T_Line[1] , &T_Line[2] , L , &L[1] , &L[2] , &L[3] , C , &C[1] };

    Picture_V2 *P1 = new Picture_V2(SPTr , 10);
    P1->Paint();



    getche();

    return 0;
}

