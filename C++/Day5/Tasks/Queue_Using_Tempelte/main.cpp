#include <iostream>

using namespace std;

template <class T_QueueCircular>
 void PrintQueue(T_QueueCircular que[] , int Size){
    for(int i=Size-1 ; i>=0 ; i-- ){
        cout << "i" << " = " << que[i] << "\n\n";

        }
}

template <class T_QueueCircular>
class QueueCircular
{
    int tail;   // increase when push
    int head;   // decrease when pop
    int Lenght;
    int Size;
    /// not know size of array => will allocate arr in heap
    T_QueueCircular *que;

   public:
        /// Constractor
        QueueCircular(int _Size){
            Size = _Size;
            tail = 0;
            head = 0;
            Lenght =0;
            que = new T_QueueCircular[Size];

            /// Initialize queue
            for(int i=0 ; i<Size ; i++){
                    que[i] = 0;
            }
        }

        ///Destractor
        ~QueueCircular(){
            delete [] que;
        }

        /// check if stack full
        /// tail==size ? true : false
        int isEmpty(){return (Lenght == 0);}
        int isFull(){return (Lenght == Size)  ;}


        void ENQ(T_QueueCircular value){
            /// check is not full
            if(!isFull()){
                /// push first then increase tos
                que[tail] = value;
                tail = (tail + 1) % Size;
                Lenght++;
                cout << "Value " << "="  << value << endl;
            }
            else{
                cout <<"Queue is Full \n";
            }
        }

        /// POP
        T_QueueCircular DEQ(){
            T_QueueCircular deq ;
            /// check is not full
            if(!isEmpty()){
                deq = que[head];
                head = (head + 1) % Size;
                Lenght--;

                cout << "====== POP ======= \n";
                return deq;
            }
            else{
                cout <<"Queue is Empty \n";
                return -1;
            }

        }

};



int main()
{
    int Size;
    cout << "Enter Size of Queue array \n" << endl;
    cin >> Size;

    QueueCircular<int> q_int(4);
    QueueCircular<char> q_char(4);

    q_int.ENQ(5);
    q_int.ENQ(2);
    q_int.ENQ(1);

    cout << "POP = " << q_int.DEQ() << endl;

    cout << "***************************************" ;
    cout << " Show how use char in Tempelet class \n" << endl;

    q_char.ENQ('a');
    q_char.ENQ('b');
    q_char.ENQ('c');

    cout << "POP = " << q_char.DEQ() << endl;





    return 0;
}
