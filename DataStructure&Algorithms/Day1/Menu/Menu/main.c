#include <stdio.h>
#include <stdlib.h>
#include<windows.h>
#include <conio.h>

/// start Define Colors Value in HexCode
#define NormalPen 0x07
#define HighlightedColor 0xc0

/// start Define Ascii Values of Normal Key
#define Enter 13
#define Esc  27

struct Employee {
    int ID , Age;
    char Name[100] , Gender , Adress[200];
    double Salary , Overtime , Deduct , Tax;

    /// start def pointers
    struct Employee *pNext;
    struct Employee *pPrev;
};


/// Global Pointers
struct Employee *pStart;
struct Employee *pLast;

void textattr (int i)
{
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), i);
}

void gotoxy( int column, int line )
  {
  COORD coord;
  coord.X = column;
  coord.Y = line;
  SetConsoleCursorPosition(
    GetStdHandle( STD_OUTPUT_HANDLE ),
    coord
    );
}


struct Employee * AddNode(){
    struct Employee *E = (struct Employee *) malloc(sizeof (struct Employee));
    // if no space to create pointer
    E->Age = 10;
    if(E==NULL) exit(0);
    E->pNext = NULL;
    E->pPrev = NULL;

    return E;
}

void ReadEmployeesDetails () {
    int j , i;
    char PrintData[6][10] = { {"ID"} , {"Name"} , {"Salary"} , {"Address" } , {"Deduct"} };
    char PrintDataSecCol[3][10] = { {"Age"} , {"Overtime"},  {"Gender"}  };


    for(j=0 ; j<1 ; j++){
        gotoxy(10,1);
        printf("Please Enter Your Data of Employee %i \n" , j+1);

        // start to print Employee data in col 1
        for(i=0 ; i<5 ; i++){
            gotoxy(3, 5 + 3*i);
            printf("%s : " ,PrintData[i] );
        }

        // start to print Employee data in col 2
        for(i=0 ; i<3 ; i++){
            gotoxy(40, 5 + 3*i);
            printf("%s : " ,PrintDataSecCol[i] );
        }

        struct Employee *EmpData = AddNode();

        if(pLast==NULL) pLast = pStart = EmpData;
        else{
            pLast->pNext = EmpData;
            EmpData->pPrev = pLast;
            pLast = EmpData;
        }

        gotoxy(15,5);
        scanf("%i" , &EmpData->ID);
        gotoxy(15,8);
        scanf("%s" , EmpData->Name);
        gotoxy(15,11);
        scanf("%lf" , &EmpData->Salary);
        gotoxy(15,14);
        scanf("%s" , EmpData->Adress);
        gotoxy(15,17);
        scanf("%lf", &EmpData->Deduct);

        gotoxy(55,5);
        scanf("%i" , &EmpData->Age);
        gotoxy(55,8);
        scanf("%lf" , &EmpData->Overtime);
        _flushall();
        gotoxy(55,11);
        scanf("%c", &EmpData->Gender);

        system("cls");

    }
}




void DisplayAll(){
    int j=0;
    struct Employee *PDisplay = pStart ;

    while(PDisplay != NULL){
        printf("Employee %i ID is : %i \n" , j+1 , PDisplay->ID );

        printf("Employee %i Name is : %s \n" , j+1 ,PDisplay->Name );

        double NetSalary = PDisplay->Salary + PDisplay->Overtime - PDisplay->Deduct ;

        printf("Employee %i Net Salary is : %lf \n" , j+1 , NetSalary );

        printf("\n \n \n ");

        /// to advance pointer
        PDisplay = PDisplay->pNext;
        j++;
    }

}


struct Employee * Search(int ID){
    struct Employee *PSearch = pStart ;

    while(PSearch != NULL ) {
        if(PSearch->ID == ID){
            break;
        }
        PSearch = PSearch -> pNext;
    }

    return PSearch;
}

void DisplayEmp(int ID){

    struct Employee *PDisplayEmp = Search(ID) ;

    if(PDisplayEmp != NULL){

       printf("Employee ID is : %i \n"  , PDisplayEmp->ID );

        printf("Employee Name is : %s \n" , PDisplayEmp->Name );

        printf("\n \n \n ");


    }
    else{
        printf("Employee Not Found");
    }

}


/// Delete all

void DeleteAll(){
    struct Employee *PDelete;

    while(pStart != NULL){
        PDelete = pStart;
        pStart = pStart -> pNext;
        delete PDelete;
    }

    pLast = NULL;
    printf("Deleted Successfully ");

}



/// Delete Node
void Delete(int ID){
    struct Employee *PDelete = Search(ID);

    /// case 1 (if no employee with this id )
    if(PDelete == NULL) printf("Employee Not Found");


    /// case 2 (id employee in first node)
    else {
        // only one node
        if(pStart == pLast){
            pStart = pLast = NULL;
        }
        else if(PDelete==pStart){
            pStart = pStart->pNext ;
            pStart->pPrev = NULL;
        }
        else if(PDelete==pLast){
            pLast = pLast->pPrev ;
            pLast->pNext = NULL ;
        }
        else{
            PDelete->pPrev->pNext = PDelete->pNext;
            PDelete->pNext->pPrev = PDelete->pPrev;
        }
         delete PDelete;
        printf("Deleted Successfully ");
    }

}









int main()
{

    char Menu[6][50]= {{"New"} , {"Display All"} , {"Display By ID"} , {"Delete All"} , {"Delete By Id"} ,{"Exit"}};


    char ch;

    // initialize current Variable to store index of item in Menu to color it
    int i  , Current=0;

    // initialize ExitFlag to indicate that user want to Exit Menu
    int ExitFlag = 0;

    do {

        // Change Color into NormalPen
        textattr(NormalPen);

        // use this fun to clean Window Screen
        system("cls");

        // Loop in 2D Array
        for(i=0; i < 6 ; i++ ){

            // change color of Menu Items [When Current == index]
            if(Current == i){
                // change color value into Highlighted Color
                textattr(HighlightedColor);
            }
            else{
             textattr(NormalPen);
            }

            gotoxy(10 , (5+3*i));
            printf("%s \n" , Menu[i]);
        }

        // get choice from user
        ch = getche();
        switch(ch){
            // when use press Exit
            case Esc:
                ExitFlag = 1;
                break;

            // when use press Enter
            case Enter:
                // check current to know which item of Menu is Pressed
                switch(Current){
                    // item 0 => New
                    case 0:
                        // clean Window Screen to Show Another Content
                        system("cls");
                        ReadEmployeesDetails();
                        break;

                    // Item 1 => Save
                    case 1:
                        system("cls");
                        DisplayAll();
                        _getch();
                        break;

                    case 2:
                        int id;
                        system("cls");
                        printf("Please Enter Employee ID \n");
                        scanf("%d" , &id);
                        DisplayEmp(id);
                        _getch();

                        break;

                    /// Delete all
                    case 3:
                        system("cls");
                        DeleteAll();
                        _getch();
                        break;

                    case 4:
                        int DelId;
                        system("cls");
                        printf("Please Enter Employee ID \n");
                        scanf("%d" , &DelId);
                        Delete(DelId);
                        _getch();
                        break;
                    // Item 2 => Exit Menu
                    case 5:
                        ExitFlag = 1;
                        break;


                /// End of Case Enter
                }
            break;

            /// when use press Extended Key [Check First Byte]
            case -32:
                // get second byte from buffer
                ch = getche();

                // check Extended Key Ascii
                switch(ch){

                    // press Down Key
                    case 80:
                        Current ++ ;
                        if(Current > 5)
                            Current=0;
                        break;

                    // Press Up Key
                    case 72:
                        Current -- ;
                        if(Current < 0)
                            Current=5;
                        break;

                    // Press Exit Key
                    case 27:
                        ExitFlag = 1;
                        break;

                }
                break;


        }

    }while(!ExitFlag);


    // to hide text bottom in console
    _getch();
    return 0;
}
