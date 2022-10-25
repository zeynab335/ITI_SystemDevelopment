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

// Global Variables
struct Employee EmpData[10] ;


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


/// SHow data by using getxy Function
void ShowData(int index){
    system("cls");
    int i;
    char PrintData[6][10] = { {"ID"} , {"Name"} , {"Salary"} , {"Address" } , {"Deduct"} };
    char PrintDataSecCol[3][10] = { {"Age"} , {"Overtime"},  {"Gender"}  };
    // start to print Employee data in col 1
        for(i=0 ; i<5 ; i++){
            gotoxy(3, 5 + 3*i);
            printf("%s : " , PrintData[i] );
        }

        // start to print Employee data in col 2
        for(i=0 ; i<3 ; i++){
            gotoxy(40, 5 + 3*i);
            printf("%s : " ,PrintDataSecCol[i] );
        }


        gotoxy(15,5);
        scanf("%i" , &EmpData[index].ID);
        gotoxy(15,8);
        scanf("%s" , EmpData[index].Name);
        gotoxy(15,11);
        scanf("%lf" , &EmpData[index].Salary);
        gotoxy(15,14);
        scanf("%s" , EmpData[index].Adress);
        gotoxy(15,17);
        scanf("%lf", &EmpData[index].Deduct);

        gotoxy(55,5);
        scanf("%i" , &EmpData[index].Age);
        gotoxy(55,8);
        scanf("%lf" , &EmpData[index].Overtime);
        _flushall();
        gotoxy(55,11);
        scanf("%c", &EmpData[index].Gender);

}



int CheckOverloading(int index) {
    // check if data in array has allocated or not by using index
    char check[10];

    if(EmpData[index].ID > 0 && strlen(EmpData[index].Name) > 0){
        printf("This index is Allocated Are You Want To Allocate it 'Yes' OR 'No' \n ");
        scanf("%s" , check);

        if(strcmp(check , "Yes") == 0 || strcmp(check , "yes") ==0 ){
            printf("Yes i accept to Override Data \n");
            return 1;
        }
        else{
            return -1;
        }
    }
    return 0;

}


/// ************* bouns Task  *******************

/// in case 0
void ReadEmployeesDetails (int index) {

    int AnotherIndex ;
    int CheckOverrideData = CheckOverloading(index);

    // override data
    if ( CheckOverrideData == 1){
        // start to print Employee data in col 1
       ShowData(index);
    }

    else if(CheckOverrideData == -1) {
        printf("Please Enter Another Index \n");
        scanf("%i" , &AnotherIndex);
        // start to print Employee data in col 1

        /// Using Recursion to check if user read allocated index or not
        ReadEmployeesDetails(AnotherIndex);
    }


    else{
        ShowData(index);
    }

}

/// in case 1
void ViewEmployeeDetailsByID(int ID){
    int i =0 , Found = 0 ;

    while(i < 10){
        if(EmpData[i].ID == ID ){
            Found = 1;
            printf("Employee ID   = %i \n" , EmpData[i].ID );
            printf("Employee Name = %s \n" , EmpData[i].Name );
            double NetSalary = EmpData[i].Salary + EmpData[i].Overtime - EmpData[i].Deduct;
            printf("Employee Net Salary = %lf \n" , NetSalary );
            return;
        }
        i++ ;
    }
    if(Found == 0) printf("Not Found Employee With this ID");

}


/// in case 2
void ViewEmployeeDetails(){

    int j , Found = 0;

    for(j=0 ; j<10 ; j++){

        if(EmpData[j].ID > 0 && strlen(EmpData[j].Name) > 0){
            Found = 1;

            printf("Employee ID is : %i \n" ,  EmpData[j].ID );
            printf("Employee Name is : %s \n" , EmpData[j].Name );


            double NetSalary = EmpData[j].Salary + EmpData[j].Overtime - EmpData[j].Deduct ;

            printf("Employee Net Salary is : %lf \n" , NetSalary );

            printf("\n \n \n ");
        }
    }
    if(Found == 0 ) printf("Employees Not Exist");

}


/// Delete Item By Using ID  [in Case 3]
void DeleteEmpByID(int ID){
    int i ,j , index , Found = 0;

    while(i < 10){
        if(EmpData[i].ID == ID ){
            Found = 1;
            index = i;
            break ;
        }
        i++ ;
    }
    if(Found == 0) printf("Not Found Employee With this ID ");

    // Delete Employee from array
    if(Found == 1){
        for(j=index ; j<10 ; j++){
            EmpData[j] = EmpData[j+1];

        }

        printf("Deleted Successfully ");
    }

}


/// Delete Item By Using Name [in Case 4]
void DeleteEmpByName(char Name[10]){
    int i ,j , index , Found = 0;

    while(i < 10){
        if(strcmp(EmpData[i].Name , Name)==0){
            Found = 1;
            index = i;
            break ;
        }
        i++ ;
    }
    if(Found == 0) printf("Not Found Employee With this Name ");
    // Delete Employee from array
    if(Found == 1){
        for(j=index ; j<10 ; j++){
            EmpData[j] = EmpData[j+1];
        }
        printf("Deleted Successfully ");
    }

}



int main()
{
    // define 2D array to store Menu items
    char Menu[6][100]= {{"New"} , {"Display By ID"} , {"Display All"} , {"Delete By ID"} , {"Delete By Name"} , {"Exit"}};

    char ch , FilterByName[10];

    // initialize current Variable to store index of item in Menu to color it
    int i  , Current=0 , FilterByID , AddByIndex;

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
                        printf("Please Enter Index you Want to store Employee \n ");
                        scanf("%i" , &AddByIndex);
                        ReadEmployeesDetails(AddByIndex);
                        break;

                    /// Display by ID Option
                    case 1:
                        system("cls");
                        printf("Please Enter Employee ID to Display Information \n ");
                        scanf("%i" , &FilterByID);

                        ViewEmployeeDetailsByID(FilterByID);
                        getch();
                        break;


                    /// Display All Option
                    case 2:
                        system("cls");
                        _flushall();
                        ViewEmployeeDetails();
                        getch();
                        break;


                    /// Delete Employee by ID
                    case 3:
                        system("cls");
                        printf("Please Enter Employee ID to Delete Information \n ");
                        scanf("%i" , &FilterByID);
                        DeleteEmpByID(FilterByID);
                        getch();
                        break;


                    /// Delete Employee By Using Name
                    case 4:
                        system("cls");
                        printf("Please Enter Employee ID to Delete Information \n ");
                        scanf("%s" , &FilterByName);
                        DeleteEmpByName(FilterByName);
                        getch();
                        break;

                    // Item 2 => Exit Menu
                    case 5:
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
