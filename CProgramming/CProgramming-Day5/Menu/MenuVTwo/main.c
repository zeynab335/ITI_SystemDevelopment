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
};
struct Employee EmpData[3] ;



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


void ReadEmployeesDetails () {
    int j , i;
    char PrintData[6][10] = { {"ID"} , {"Name"} , {"Salary"} , {"Address" } , {"Deduct"} };
    char PrintDataSecCol[3][10] = { {"Age"} , {"Overtime"},  {"Gender"}  };


    for(j=0 ; j<3 ; j++){

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



        gotoxy(15,5);
        scanf("%i" , &EmpData[j].ID);
        gotoxy(15,8);
        scanf("%s" , EmpData[j].Name);
        gotoxy(15,11);
        scanf("%lf" , &EmpData[j].Salary);
        gotoxy(15,14);
        scanf("%s" , EmpData[j].Adress);
        gotoxy(15,17);
        scanf("%lf", &EmpData[j].Deduct);

        gotoxy(55,5);
        scanf("%i" , &EmpData[j].Age);
        gotoxy(55,8);
        scanf("%lf" , &EmpData[j].Overtime);
        _flushall();
        gotoxy(55,11);
        scanf("%c", &EmpData[j].Gender);

        system("cls");

    }
}



void ViewEmployeeDetails(){

    int j;
    for(j=0 ; j<3 ; j++){
        printf("Employee %i ID is : %i \n" , j+1 , EmpData[j].ID );

        printf("Employee %i Name is : %s \n" ,j+1 , EmpData[j].Name );

        double NetSalary = EmpData[j].Salary + EmpData[j].Overtime - EmpData[j].Deduct ;

        printf("Employee %i Net Salary is : %lf \n" , j+1 , NetSalary );

        printf("\n \n \n ");

    }
}




int main()
{

    // define 2D array to store Menu items
    /*char Menu[6][100]=
        {
            {"New"} , {"Display By ID"} , {"Display All"} , {"Delete By ID"} , {"Delete By Name"} , {"Exit"}
        };
    */
    char Menu[3][10]= {{"New"} , {"Display"} , {"Exit"}};


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
                        getch();
                        break;

                    // Item 1 => Save
                    case 1:
                        system("cls");
                        ViewEmployeeDetails();
                        getch();
                        break;

                    // Item 2 => Exit Menu
                    case 2:
                        ExitFlag = 1;
                        break;
                    }

                /// End of Case Enter
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
