#include <iostream>
#include <string>
#include <bits/stdc++.h>

using namespace std;

int Count;

class Complex
{
    /// Default access Modifier is Private
    int real;
    int img;


public:
    void setReal(int);
    int getReal();
    void setImg(int);
    int getImg();

    /// Overloaing Constractor
    Complex(int _real = 0 , int _img=0){

        real = _real;
        img = _img;
        Count++;
    }

    /// Copy constractor
    Complex(Complex &c_old){
        real = c_old.real;
        img  = c_old.img;
        Count++;
    }


    /// Destracror
    ~Complex() {
        //cout <<"Destructor Of Cost Add = " <<  this << " \n\n";

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
            cout << real  <<  "+" << img << "i \n" << endl;
        }

    }


    /// complex c [all by value => will create new complex in memory]
    Complex Sum(const Complex &c){
        //Complex Res;
        real += c.real;
        img  +=  c.img;

        return *this;  // return reference
    }


    /// *********************Start Operator overloading ************************ ///
    /// Start Subtract two complexes


    Complex operator - (const Complex &c){
        Complex Result(real - c.real , img  - c.img) ;
        return Result;
    }


    Complex operator - (int num){
        Complex Result( real - num , img) ;
        return Result;
    }


    /// C1 -= c2
    Complex &operator -= (Complex &c){
        real -=c.real ;
        img -=c.img ;
        return *this;
    }


    /// C1 -= 7
    Complex &operator -= (int num){
        real -= num ;
        return *this;
    }

     /// --C1
    Complex operator --( ){
        real--;
        return *this;
    }


    /// C1--
    Complex operator --(int){
        Complex temp(*this);
        real--;
        return temp;
    }


     /// ==
    bool operator ==(const Complex &c){
        return (real==c.real && img == c.img);
    }


    /// !=
    bool operator !=(const Complex &c){
        return (real!=c.real && img != c.img);
    }


    /// greater than
    bool operator >(const Complex &c){
        return (real > c.real);
    }

     /// greater than or equal
    bool operator >=(const Complex &c){
        return (real >= c.real);
    }


     /// smaller than
    bool operator <(const Complex &c){
        return (real < c.real);
    }

    /// smaller than or equal
    bool operator <=(const Complex &c){
        return (real <= c.real);
    }

    /// (int) casting operator
    operator int(){
        return real;
    }



     /// fun return int
     string toS(int k){
        stringstream ss;
        ss<<k;
        string s;
        ss>>s;
        return s;
    }

    /// (char) casting operator
    operator char* (){
        int idx=0;
        char *c = new char[100];

        string s=toS(real);
        for(int i=0;i<s.length();i++){
            c[idx]=s[i];
            idx++;
        }

        if(img>=0) c[idx++]='+';

        s=toS(img);
        for(int i=0;i<s.length();i++){
            c[idx]=s[i];
            idx++;
        }
        c[idx++]='i';
        c[idx++] = '\0';

        return c;
    }

};



    /// ********************* end Operator overloading ************************ ///




    /// Standalone functions

    Complex operator - (int num , Complex &c){
        Complex Result(num - c.getReal() , c.getImg()) ;
        return Result;
    }

    /// C1 -= 7
    Complex operator -= (int num , Complex &c ){
        Complex Result(num - c.getReal() , c.getImg()) ;
        return Result;
    }



int main()
{
    /// Without Copy Constractor
    Complex c1(7,4) , c2(5,3);
    Complex c3 , c4 , c5 , c6(3,3) , c7 ;


    /// start Operator

    /// Complex num 1

    c3 = c1 - c2;
    cout << "c1 - c2 = " ;
    c3.printComplex();



    /// Complex num 2

    c4 = 7 - c2;
    cout << "7 - c2 = " ;
    c4.printComplex();



     /// Complex num 3

    c5 = c2 - 7;
    cout << "c2 - 7 = " ;
    c5.printComplex();


    /// Complex num 4

    c1 -= c2 ;
    cout << "c1 -= c2 ==> " ;
    c1.printComplex();


    /// Complex num 5
    c1 -= 7 ;
    cout << "c1 -= 7 ==> " ;
    c1.printComplex();


    /// Complex num 7
    --c2;
    cout << "--c1 ==> " ;
    c2.printComplex();


    /// Complex num 8
    c7 = c2-- ;
    cout << "c1-- ==> " ;
    c7.printComplex();


    /// Complex num 9
    c1.printComplex();
    c2.printComplex();
    c6.printComplex();

    cout << "c1!=c2 ==> " << (c1 != c2) <<endl ;
    cout << "c2==c6 ==> " << (c2 == c6) << endl;


    /// get only Real
    cout << "real of c2 " << ((int)c2) << endl;

    /// get char
    c1.setImg(-2);
    char* str = (char*) c1;
    int i=0;
    while(str[i] != '\0') {
        cout << str[i] ;
        i++;
    }


    return 0;
}


/// Use Scope Operating to implement member fun outside class
void Complex::setReal(int _real) {real = _real;}
int  Complex::getReal(){return real;}
void Complex::setImg(int _img){img = _img;}
int  Complex::getImg(){return img;}


