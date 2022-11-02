#include <iostream>

using namespace std;

template <class T_Array>
class intArray{

    T_Array *Arr ;
    int Size , ArrLength;

    public :
    intArray(int num){
        Size = num;
        Arr  = new T_Array[Size];
    }

    intArray(const intArray & a){
        Size = a.Size;
        Arr  = new T_Array[Size];
        for(int i=0 ; i<Size ; i++){
            Arr[i] = a.Arr[i];
        }
    }


    T_Array & operator [](int index){
        if( (index>=0) && (index < Size)) {return Arr[index];}
    }

    ~intArray(){
        delete [] Arr;
    }

    int GetSize() {
        return Size ;
    }

    void setValue (int index , T_Array value){
        if(index>=0 && index<Size ){
            Arr[index] = value;
        }
    }


    T_Array getValue (int index){
        if(index>=0 && index<Size )return Arr[index];
    }



     /// Equal Operator
    intArray & operator = (const intArray &a1){
        /// already make constractor
        delete [] Arr;
        Size = a1.Size;

        Arr = new T_Array[Size];
        for(int i=0 ; i<Size ; i++){
            Arr[i] = a1.Arr[i];
        }

        return *this;
    }



    /// sum array member Function
    intArray  operator + (intArray &a){
        intArray R(Size);
        for(int i=0 ; i < Size ; i++){
            R.Arr[i]= a.Arr[i] + Arr[i];
        }
        return R;
    }



};


int main()
{
    intArray<int> A1(3) ;
    intArray<char> A2(3) ;

    A1[0] = 5 ;
    A1[1] = 4 ;
    A1[2] = 3 ;

    A2[0]= 'c'  ;
    A2[1]= 'k' ;
    A2[2]= 'a' ;

    cout << "Array of Numbers using Tempelte member = \n";
    for(int i=0 ; i < A1.GetSize() ; i++){
        cout << "A1 = " << A1[i]  << endl;
    }

    cout << "\nArray of Characters using Tempelte member = \n";


     for(int i=0 ; i < A2.GetSize() ; i++){
        cout << "A2 =  " << A2[i]  << endl;
    }




    return 0;
}
