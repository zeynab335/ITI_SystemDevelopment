#include <stdio.h>
#include <stdlib.h>
#include <windows.h>
#include <string.h>
#include <conio.h>

struct Employee {
    int ID , Age;
    char Name[100] , Gender , Adress[200];
    double Salary , Overtime , Deduct , Tax;
};


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





int main()
{
    struct Employee Emp ;
    int i;
    char PrintData[6][10] = { {"ID"} , {"Name"} , {"Salary"} , {"Address" } , {"Deduct"} };
    char PrintDataSecCol[3][10] = { {"Age"} , {"Overtime"},  {"Gender"}  };

    gotoxy(10,1);
    printf("Please Enter Your Data \n");

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
    scanf("%i" , &Emp.ID);
    gotoxy(15,8);
    scanf("%s" , Emp.Name);
    gotoxy(15,11);
    scanf("%lf" , &Emp.Salary);
    gotoxy(15,14);
    scanf("%s" , Emp.Adress);
    gotoxy(15,17);
    scanf("%lf", &Emp.Deduct);

    gotoxy(55,5);
    scanf("%i" , &Emp.Age);
    gotoxy(55,8);
    scanf("%lf" , &Emp.Overtime);
    gotoxy(55,11);
    scanf("%c", &Emp.Gender);



    getche();
    system("cls");



    /// ************* Einishing get data from Employee

    // start Displaying Employee Data
    gotoxy(3,3);
    printf("Employee ID is : %i" ,Emp.ID );

    gotoxy(3,6);
    printf("Employee Name is : %s" ,Emp.Name );

    gotoxy(3,9);
    double NetSalary = Emp.Salary + Emp.Overtime - Emp.Deduct ;
    printf("Employee Net Salary is : %lf" , NetSalary );

    printf("\n \n");

    getche();

    return 0;
}
