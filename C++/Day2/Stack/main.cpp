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
        Stack(int _Size){
            Size = _Size;
            tos = 0;
            stk = new int[Size];
        }

        ///Destractor
        ~Stack(){
            delete [] stk;
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

};

int main()
{
    int Size;
    cout << "Enter Size of Stack array \n" << endl;
    cin >> Size;

    Stack s1(Size);

    cout << s1.Pop() << endl;
    s1.Push(5);
    s1.Push(2);
    s1.Push(1);
    cout << s1.Pop() << endl;
    cout << s1.Peek() << endl;
    cout << s1.Pop() << endl;





    return 0;
}
