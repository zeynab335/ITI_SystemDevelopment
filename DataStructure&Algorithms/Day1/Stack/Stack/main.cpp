#include <iostream>
#include <string.h>

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

class Stack
{
   public:
        /// Constractor

        static Employee *pTOS;
        static int Length;

        Stack()
        {
            cout<< "stack cons";
            pTOS = NULL;
         }

        bool isEmpty(){return pTOS==NULL;}
        bool isFull(){return false;}

        void Push(Employee *NewEmp){
            //Employee *NewEmp = new Employee(Emp);

            if(!isFull()){
            /// if no space
            if(NewEmp == NULL){
                cout << "Stack is Full/n";
                return;
            }
            else{
                cout << "\nPush";
                /// if no nodes in stack
                if(isEmpty()) {
                    NewEmp->pPrev = NULL;
                    NewEmp->pNext = NULL;
                    pTOS = NewEmp;
                }

                else{
                    /// to make previous node link to newEmployee
                    pTOS->pNext = NewEmp;
                    NewEmp->pPrev = pTOS;
                    NewEmp->pNext = NULL;
                    pTOS = NewEmp;
                }
                Length++;
            }
        }
    }

        /// POP
        Employee * Pop(){
            /// check is not full
            Employee *pTemp ;

            if(!isEmpty()){
                ///  decrease tos first then pop
                pTemp = pTOS;
                pTOS = pTOS->pPrev;

                delete pTemp;
                Length--;
            }
            else{
                cout <<"Stack is Empty \n";
                return 0;
            }

        }


        /// Peek
        Employee * Peek(){
            /// check is not full
            if(!isEmpty()){
                ///  decrease tos first then pop
                return pTOS;
            }
            else{
                cout <<"Stack is Empty \n";
                return 0;
            }

        }


    // viewContent
    void viewContent(){
        Employee *pTemp;
        if (isEmpty()) {
            cout << "Stack Empty\n";
            return;
        }
        else {
            pTemp = pTOS;
            while (pTemp != NULL) {
                 cout << "\nEmployee ID = " <<pTemp->id  << endl;
                 cout << "Employee Name = " <<pTemp->Name << endl;
                 cout << "Employee salary =" <<pTemp->salary  << endl;

                // Assign temp link to temp
                pTemp = pTemp->pPrev;

                if (pTemp != NULL)
                    cout << "************************" ;
            }
        }

    }


     ///Destractor
        ~Stack(){
            Employee *dEmp ;
            while(pTOS!=NULL){
                dEmp = pTOS;
                pTOS = pTOS->pPrev ;
                delete dEmp;
            }
            delete pTOS;
        }




};



Employee* Stack::pTOS = NULL;
int Stack::Length = 0;

int main()
{

    Employee E1(10,"z" , 5000) , E2(20,"z" , 5000) , E3(30,"z" , 5000);
    Stack s1;


    s1.Push(&E1);
    s1.Push(&E2);
    s1.Push(&E3);

    s1.viewContent();


    cout << "\n******** Peek Last Employee ******** \n";
    Employee::DisplayEmployeeData(s1.Peek());

    s1.Pop();
    s1.Pop();

    cout << "Length = " << Stack::Length << endl;
    cout << "\n******** view Employees after Pop 2 Emp ******** \n";
    s1.viewContent();



    return 0;
}
