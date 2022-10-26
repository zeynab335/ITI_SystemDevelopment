#include <iostream>

using namespace std;

int Count;

class Complex
{
    /// Default access Modifier is Private
    int real;
    int img;


public:

    /// Overloaing Constractor
    Complex(int _real , int _img){

        real = _real;
        img = _img;
        Count++;
        cout << "Img and Real Cons Add => " << this << " \n\n";
    }
    Complex(int _real){
        real = _real; img=0;
        Count++;
        cout << "Real Cons Add => " << this << " \n\n";
    }
    Complex(){
        Count++;
        cout << "Parmeterless Cons Add => " << this << " \n\n";
        real=0 ; img=0;
    }


    /// Destracror
    ~Complex() {
        cout <<"Destructor Of Cost Add = "<< this <<" \n\n";
    }

    void setReal(int _real) {real = _real;}
    int getReal(){return real;}

    void setImg(int _img){img = _img;}
    int getImg(){return img;}


    void printComplex(){

        if(img == 0 && real == 0 ){
            cout << 0 << endl;
        }
        else if(real == 0  && img > 1){
            cout << img << "i"  << endl;
        }
        else if(img == 0 && real > 1 ){
            cout << real << endl;
        }
        else if(img < 0 ){
            cout << real  << img << "i" << endl;
        }
        else{
            cout << real  <<  "+" << img << "i \n" << endl;
        }

    }


    /// complex c [all by value => will create new complex in memory]
    Complex Sum(Complex c){
        Complex Res;

        cout << "Res Add = " << &Res <<endl;
        cout << "cons Parameter Add = " << &c <<endl;

        Res.real = real + c.real;
        Res.img  = img + c.img;

        return Res;  // return reference
    }
};

int main()
{
    // store in stack
    Complex c1(1,2) , c2(5) ,c3;
    c3 = c1.Sum(c2);
    c3.printComplex();

    cout << "C1 Add = " << &c1 <<endl;
    cout << "C2 Add = " << &c2 <<endl;
    cout << "C3 Add = " << &c3 <<endl;


    cout << "Num Of Objects are = " << Count <<endl;




    return 0;
}
