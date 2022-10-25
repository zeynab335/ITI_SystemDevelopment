#include <iostream>

using namespace std;

class Complex
{
    /// Default access Modifier is Private
    int real;
    int img;

public:
    void setReal(int _real){
        real = _real;
    }
    int getReal(){
        return real;
    }

    void setImg(int _img){
        img = _img;
    }
    int getImg(){
        return img;
    }


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
            cout << real  <<  "+" << img << "i" << endl;
        }

    }


    Complex Sum(Complex c){
        Complex c3;

        c3.real = real + c.getReal();
        c3.img  = img + c.getImg();

        return c3;
    }

};

 Complex Sub(Complex c1 , Complex c2){
     Complex c3;
     c3.setReal(c1.getReal() - c2.getReal()) ;
     c3.setImg(c1.getImg() - c2.getImg()) ;
    return c3;
}


int main()
{
    int r1 , i1 , r2 , i2 ;
    Complex c1 , c2 , c_Sum , c_Sub ;

    cout << "Enter Real Number 1 " << endl;
    cin >> r1;
    cout << "Enter Imagine Number 1 " << endl;
    cin >> i1;

    c1.setReal(r1);
    c1.setImg(i1);

    cout << "Enter Real Number 2 " << endl;
    cin >> r2;
    cout << "Enter Imagine Number 2 " << endl;
    cin >> i2;


    c2.setReal(r2);
    c2.setImg(i2);

    cout << "Real = " << c1.getReal() <<endl ;
    cout << "Imagine = " << c1.getImg() <<endl ;

    /// Task Part 1
     //c1.printComplex();

    /// Task Part 2

    c_Sum = c2.Sum(c1);
    cout << "Sum Of Two Complex = " << endl ;
    c_Sum.printComplex();



    c_Sub = Sub(c1 , c2);
    cout << "Sub Of Two Complex = " << endl ;
    c_Sub.printComplex();



    return 0;
}
