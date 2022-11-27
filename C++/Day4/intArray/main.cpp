#include <iostream>

using namespace std;

class intArray{

    int *Arr , Size , ArrLength;
    public :
    intArray(int num){
        Size = num;
        Arr  = new int[Size];
        for(int i=0 ; i<Size ; i++){
            Arr[i] = -1;
        }
    }

    intArray(const intArray & a){
        Size = a.Size;
        Arr  = new int[Size];
        for(int i=0 ; i<Size ; i++){
            Arr[i] = a.Arr[i];
        }
    }


    int & operator [](int index){
        if( (index>=0) && (index < Size)) {return Arr[index];}
    }

    ~intArray(){

         for(int i=0 ; i<Size ; i++){
            Arr[i] = -2;
        }


        delete [] Arr;
    }

    int GetSize() {
        return Size ;
    }

    void setValue (int index , int value){
        if(index>=0 && index<Size ){
            Arr[index] = value;
        }
    }


    int getValue (int index){
        if(index>=0 && index<Size )return Arr[index];
    }



     /// Equal Operator
    intArray & operator = (const intArray &a1){
        /// already make constractor
        delete [] Arr;
        Size = a1.Size;

        Arr = new int[Size];
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

    /// another sum array Standalone
    /*
    intArray operator + (intArray &a , intArray &a2){
        intArray R(a.GetSize());
            for(int i=0 ; i < a.GetSize() ; i++){
                R.setValue(i , (a.getValue(i) + a2.getValue(i)));
            }
            return R;
    }
    */


int main()
{
    intArray MyA(7) , MyA2(7) , A_Res(3) , A1(3) , A2(3);
    A1[0] = 5  ; A1[1]=4 ;
    A2[0] = 1  ; A2[1]=3 ;

    MyA[0] = 5  ; MyA[1]=4 ;
    MyA2[0] = 1  ; MyA2[1]=3 ;


    /// Using Equal operator
    MyA = MyA2;

    for(int i=0 ; i<= MyA.GetSize() ; i++){
        if(MyA[i] < 0){
            break;
        }
        MyA[i] = 3*i;
        cout << "in MyA Element " << i << " = " << MyA[i] << endl ;
    }

    A_Res = A1 + A2;


    for(int i=0 ; i < A_Res.GetSize() ; i++){
        if(A_Res.getValue(i) < 0) break;
        cout << "A1 = " << A1[i] << "  A2 =  " << A2[i] <<"  A_Res = " << A_Res.getValue(i) << endl ;
    }

    //cout << (A1 + A2).getValue(0) ;




    return 0;
}
