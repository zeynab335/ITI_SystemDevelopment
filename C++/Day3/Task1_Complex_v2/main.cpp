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
        //cout << "Img and Real Cons  => " << Count << " \n\n";
    }
    Complex(int _real){
        real = _real; img=0;
        Count++;
        cout << "Real Cons Add => " << this << " \n\n";
        //cout << "Img and Real Cons  => " << Count << " \n\n";

    }
    Complex(){
        Count++;
        cout << "Parmeterless Cons Add => " << this << " \n\n";
        //cout << "Parmeterless Cons => " << Count << " \n\n";

        real=0 ; img=0;
    }



    /// Copy constractor
    Complex(Complex &c_old){
        real = c_old.real;
        img  = c_old.img;
        Count++;
        cout <<"Copy Cost = " << " \n\n";
    }


    /// Destracror
    ~Complex() {
        cout <<"Destructor Of Cost Add = " <<  this << " \n\n";

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
    Complex Sum(Complex &c){
        Complex Res;

        Res.real = real + c.real;
        Res.img  = img + c.img;

        return Res;  // return reference
    }
};

int main()
{
    /// Without Copy Constractor
    // store in stack
    Complex c1(1,2) , c2(5);
    Complex c3;

    c3 = c1.Sum(c2);

    //cout <<"real_res" << c3.getReal() <<endl;
    c3.printComplex();

    cout << "Num Of Objects are = " << Count <<endl;


    /// with copy constractor




    return 0;
}
