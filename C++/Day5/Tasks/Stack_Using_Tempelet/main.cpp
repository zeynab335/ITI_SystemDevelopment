#include <iostream>

using namespace std;


template <class MyStack>
class Stack{

    int tos;
    int Size;
    /// not know size of array => will allocate arr in heap
    MyStack *stk;

    /// Static count
    static int Count;

   public:
        /// Constractor

        Stack (MyStack _size=4){
            Size = _size;
            tos = 0;
            stk = new MyStack[Size];
            Count ++;
        }


        /// Copy constractor

         Stack (Stack &s){
            Size = s.Size;
            tos = s.tos;
            stk = new MyStack[Size];
            for(int i=0 ; i<tos ; i++){
                stk[i] = s.stk[i];
            }
            Count ++;
        }

        ///Destractor
        ~Stack(){
            delete [] stk;
            Count --;
        }


        /// check if stack full
        /// tos==size ? true : false
        int isFull(){return tos==Size;}
        int isEmpty(){return tos==0;}


        void Push(MyStack num){
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
        MyStack Pop(){
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

    /// Reverse
    Stack Reverse(){
        Stack R ;
        for(int i=tos-1 ; i>=0 ; i--){
            R.Push(stk[i]);
        }
        return R;

    }

    /// Equal Operator
    Stack & operator = (const Stack &s1){
        /// already make constractor
        delete [] stk;
        tos = s1.tos;
        Size = s1.Size;

        stk = new MyStack[Size];
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


    /// get count
    static GetCount(){ return Count;}


};

/// to initialize private or member static
template <class MyStack>
int Stack<MyStack>::Count = 0;

int main()
{

    Stack<int> s1 ;
    Stack<char> s2 ;
    Stack<char> s3 ;

    cout << s1.Pop() << endl;
    s1.Push(5);
    s1.Push(2);
    s1.Push(3);
    s1.Push(4);

    s2.Push('a');
    s2.Push('b');
    s2.Push('c');


    cout<< "View Content of S1 = " <<endl;
    s1.VContent();

    cout<< "\nView Content of S2 = " <<endl;
    s2.VContent();


    cout << "\nGet Count of All Objects that created in class  = \n";
    cout << "In Stack of Integers = " << Stack<int>::GetCount() << endl;
    cout << "In Stack of Characters = " << Stack<char>::GetCount() << endl;



    return 0;
}
