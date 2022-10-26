#include <iostream>

using namespace std;

 void PrintQueue(int que[] , int Size){
    for(int i=Size-1 ; i>=0 ; i-- ){
        cout << "i" << " = " << que[i] << "\n\n";

        }
}

class QueueCircular
{
    int tail;   // increase when push
    int head;   // decrease when pop
    int Lenght;
    int Size;
    /// not know size of array => will allocate arr in heap
    int *que;

   public:
        /// Constractor
        QueueCircular(int _Size){
            Size = _Size;
            tail = 0;
            head = 0;
            Lenght =0;
            que = new int[Size];

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


        void ENQ(int num){
            /// check is not full
            if(!isFull()){
                /// push first then increase tos
                que[tail] = num;
                tail = (tail + 1) % Size;
                Lenght++;

                cout << "====== Push " << num << "=======\n ";
                PrintQueue(que ,Size);
            }
            else{
                cout <<"Queue is Full \n";
            }
        }

        /// POP
        int DEQ(){
            int deq ;
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


    QueueCircular q(Size);
    //QueueV2 q(Size);


    q.ENQ(5);
    q.ENQ(2);
    q.ENQ(1);
    q.ENQ(4);
    q.ENQ(8);

    cout << "POP = " << q.DEQ() << endl;
    q.ENQ(6);
    cout << "POP = " << q.DEQ() << endl;

    q.ENQ(7);
    q.ENQ(8);




    return 0;
}
