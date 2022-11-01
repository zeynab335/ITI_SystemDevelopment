#include <iostream>

using namespace std;


class Stack
{
    int tos;
    int Size;
    /// not know size of array => will allocate arr in heap
    int *stk;

   public:
        /// Constractor

        Stack(int _size=4){
            Size = _size;
            tos = 0;
            stk = new int[Size];
        }


        /// Copy constractor

         Stack(Stack &s){
            Size = s.Size;
            tos = s.tos;
            stk = new int[Size];
            for(int i=0 ; i<tos ; i++){
                stk[i] = s.stk[i];
            }
        }


        /// check if stack full
        /// tos==size ? true : false
        int isFull(){return tos==Size;}
        int isEmpty(){return tos==0;}


        void Push(int num){
            /// check is not full
            if(!isFull()){
                /// push first then increase tos
                stk[tos] = num;
                tos++;
            }
            else{
                cout <<"Stack is Full \n";
            }

        }

        /// POP
        int Pop(){
            /// check is not full
            if(!isEmpty()){
                ///  decrease tos first then pop
                return stk[--tos];
            }
            else{
                cout <<"Stack is Empty \n";
                return -1;
            }

        }


        /// Peek
        int Peek(){
            /// check is not full
            if(!isEmpty()){
                ///  decrease tos first then pop
                return stk[tos-1];
            }
            else{
                cout <<"Stack is Empty \n";
                return 0;
            }

        }

    // call by value
    //friend void VContent(Stack s);

    /// call by Reference
    //friend void VContent(const Stack &s);



    /// Reverse
    Stack Reverse(){
        Stack R ;
        for(int i=tos-1 ; i>=0 ; i--){
            R.Push(stk[i]);
        }
        return R;

    }

     ///Destractor
        ~Stack(){
           /// use in Call By Value
            for(int i=0 ; i<tos ; i++){
                stk[i] = -1;
            }

            delete [] stk;
        }

    /// Equal Operator
    Stack & operator = (const Stack &s1){
        /// already make constractor
        delete [] stk;
        tos = s1.tos;
        Size = s1.Size;

        stk = new int[Size];
        for(int i=0 ; i<Size ; i++){
            stk[i] = s1.stk[i];
        }

        return *this;
    }

     /// [] Operator
    int & operator[](int index){
        return stk[index];
    }


    /// Append two stacks in one stack
    Stack operator +(Stack &s1){
        int Size_ = s1.Size + Size;
        Stack R(Size_);

        for(int i=0 ; i<tos ; i++){
            R.Push(stk[i]);
        }
        for(int i=0 ; i<s1.tos ; i++){
            R.Push(s1.stk[i]);
        }

    return R;
    }

    void VContent(){
        for(int i=0 ; i<tos ; i++){
            cout << "Element " << i  << "=" << stk[i] <<endl;
        }
    }



};


/// vContent using friend function
/*
void VContent(const Stack &s){
    for(int i=0 ; i<s.tos ; i++){
        cout << "Element " << i  << "=" << s.stk[i] <<endl;
    }
}
*/



int main()
{

    Stack s1 , s3 ,s2 , s4;

    cout << s1.Pop() << endl;
    s1.Push(5);
    s1.Push(2);
    s1.Push(3);
    s1.Push(4);

    s2.Push(1);
    s2.Push(2);
    s2.Push(5);
    s2.Push(4);


    cout<< "View Content of S1 = " <<endl;
    s1.VContent();

    /// Use Copy constractor to initialize obj by another obj
    //Stack s2(s1);

    /// using plus operator overloading
    s3 = s1;

    cout<< "\nView Content of S3 = \n" <<endl;
    s3.VContent();

    /// s1 + s2
    cout<< "\n \nView Content of S1 + s2 = " <<endl;
    s4 = s1 + s2;
    s4.VContent();

    /// Access stack using index   arr[i]
    cout<< " \n Stk of s3 = " << s4[0]  <<endl;


    return 0;
}
