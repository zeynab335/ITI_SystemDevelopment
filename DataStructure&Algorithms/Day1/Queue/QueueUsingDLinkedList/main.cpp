#include <iostream>

using namespace std;

class Employee{
public:

    int id;
    char *Name;
    float salary;

    Employee *pPrev;
    Employee *pNext;

    Employee(int _id , char *_name ,float _salary){
        cout<<"emp cons";
        id = _id;
        Name = _name;
        salary = _salary;
        pPrev = NULL;
        pNext = NULL;
    }


    Employee(Employee *E){
        cout<<"emp copy cons";
        id = E->id;
        Name = E->Name;
        salary = E->salary;
        pPrev = NULL;
    }

    static void DisplayEmployeeData(Employee *pEmp){
        cout << "\nEmployee ID = " << pEmp->id  << endl;
        cout << "Employee Name = " << pEmp->Name << endl;
        cout << "Employee salary =" << pEmp->salary  << endl;

    }

};


class Queue
{

   public:
        static Employee *pTail;// increase when push
        static Employee *pHead;// decrease when pop

        static int Length;

        /// Constractor
        Queue(){
            cout<< "stack cons";
            pTail = NULL;
            pHead = NULL;
        }

        ///Destractor
        ~Queue(){
            Employee *dEmp ;
            while(pHead!=NULL){
                dEmp = pHead;
                pHead = pHead->pNext ;
                delete dEmp;
            }
            delete pHead;
            delete pTail;
        }

        /// check if stack full
        /// tail==size ? true : false
        int isEmpty(){return (pTail == NULL && pHead == NULL);}
        bool isFull(){return false;}

        void ENQ(Employee *NewEmp){
            /// check is not full

            /// if no space
            if(NewEmp == NULL){
                cout << "Queue is Full/n";
                return;
            }

            else{
            if(!isFull()){
                if(isEmpty()) {
                    NewEmp->pPrev = NULL;
                    NewEmp->pNext = NULL;
                    pHead = pTail = NewEmp;
                }
                else{
                    /// to make previous node link to newEmployee
                    pTail->pNext = NewEmp;
                    NewEmp->pPrev = pTail;
                    NewEmp->pNext = NULL;
                    pTail = NewEmp;
                }
                Length++;
            }

        }
    }


        /// POP
        Employee * DEQ(){
            /// check is not full
            Employee *pTemp ;

            if(!isEmpty()){
                pTemp = pHead;
                pHead = pHead->pNext;

                delete pTemp;
                Length--;
            }
            else{
                cout <<"Queue is Empty \n";
                return 0;
            }
        }

        /// Peek
        Employee * Peek(){
            if(!isEmpty()){
                return pHead;
            }
            else{
                cout <<"Queue is Empty \n";
                return 0;
            }

        }



    // viewContent
    void viewContent(){
        Employee *pTemp;
        if (isEmpty()) {
            cout << "Queue Empty\n";
            return;
        }
        else {
            pTemp = pHead;
            while (pTemp != NULL){
                 cout << "\nEmployee ID = " <<pTemp->id  << endl;
                 cout << "Employee Name = " <<pTemp->Name << endl;
                 cout << "Employee salary =" <<pTemp->salary  << endl;

                // Assign temp link to temp
                pTemp = pTemp->pNext;

                if (pTemp != NULL)
                    cout << "************************" ;
            }
        }

    }


};


Employee* Queue::pTail = NULL;
Employee* Queue::pHead = NULL;
int Queue::Length = 0;

int main()
{

    Employee E1(10,"z" , 5000) , E2(20,"z" , 5000) , E3(30,"z" , 5000);
    Queue q;

    q.ENQ(&E1);
    q.ENQ(&E2);
    q.ENQ(&E3);

    q.viewContent();

    cout << "\n******** Peek Last Employee ******** \n";
    Employee::DisplayEmployeeData(q.Peek());

    q.DEQ();
    q.DEQ();
    cout << "\n******** view Employees after DEQ 2 Emp ******** \n";
    q.viewContent();
    cout << "Length = " << Queue::Length << endl;



    return 0;
}
