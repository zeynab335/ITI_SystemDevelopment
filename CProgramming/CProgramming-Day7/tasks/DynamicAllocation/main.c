#include <stdio.h>
#include <stdlib.h>
#include<windows.h>
#include <conio.h>

/// start Define Colors Value in HexCode
#define NormalPen 0x07
#define HighlightedColor 0xc0

/// start Define Ascii Values of Normal Key`
#define Enter 13
#define Esc  27

struct Employee {
    int ID , Age;
    char Name[100] , Gender , Adress[100];
    double Salary , Overtime , Deduct , Tax;
};

// Global Variables
//struct Employee EmpData[10] ;
int EmpSize;

char line[100];


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

/// Hightlight Function
void printLine(col , row){
    int i;
    for(i=0 ; i<10 ; i++){
        gotoxy(col+i , row);
        textattr(HighlightedColor);
        printf(" ");
    }
}

/// Start LineEditor

/// Start LineEditor
char* LineEditor (int col , int row , int SChar , int EChar ) {
    //*line = (char*)calloc(100) ;

    char ch , *end , *current , *start ;

    // to know what number of col will go in end
    int colPosition = col  , ExFlag = 0 , endPosition=col;

    start = line;
    current = line;
    end = line;

    //printLine(colPosition , row);

    do{
        gotoxy( colPosition , row);

        ch = getch();

        switch(ch){

            case Esc:
                ExFlag=1;
                break;

            /// ********** Extended Keys  ************

            /// press home case
            case 71:
                current = start;
                colPosition = col ;
                break;

            /// press end case
            case 79:
                current = end;
                colPosition= endPosition;
                break;

            /// press left arrow Case
            case 75:
                if(current > start){
                    current--;
                    colPosition -- ;
                }

                break;

            /// press right arrow Case
            case 77:
                if(current < end){
                    current++;
                    colPosition ++;
                }

                break;

            /// press enter
            case Enter:
                //null terminator
                *end = '\0';
                ExFlag = 1;
                break;

            default:
                if(ch >= SChar && ch <= EChar){

                    *current = ch;
                    printf("%c",ch);
                    colPosition++;
                    current++;
                         end++;
                        endPosition ++ ;


                }

                break;
        }


    }while(!ExFlag);


    return line;

}



/// SHow data by using getxy Function
void ShowData(struct Employee *EmpData  , int index){
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


        printLine(15 , 5);
        printLine(15 , 8);
        printLine(15 , 11);
        printLine(15 , 14);
        printLine(15 , 17);

        printLine(55 , 5);
        printLine(55 , 8);
        printLine(55 , 11);


        //gotoxy(15,5);
        //scanf("%i" , &EmpData[index].ID);
        EmpData[index].ID = atoi(LineEditor(15,5,45,57));

        //EmpData[index].Name = LineEditor(15,8,97,122);
        strcpy(EmpData[index].Name , LineEditor(15,8,97,122));

        EmpData[index].Salary = atoi(LineEditor(15,11,48,57));

        strcpy(EmpData[index].Adress ,LineEditor(15,14,97,122));

        EmpData[index].Deduct = atoi(LineEditor(15,17,48,57));

        EmpData[index].Age = atoi(LineEditor(55,5,48,57));

        EmpData[index].Overtime = atoi(LineEditor(55,8,48,57));

        _flushall();

        EmpData[index].Gender = LineEditor(55,11,97,122);
}



int CheckOverloading(struct Employee *EmpData , int index) {
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
void ReadEmployeesDetails (struct Employee *Emp , int index) {

    int AnotherIndex ;
    int CheckOverrideData = CheckOverloading(Emp , index);

    // override data
    if ( CheckOverrideData == 1){
        // start to print Employee data in col 1
       ShowData(Emp , index);
    }

    else if(CheckOverrideData == -1) {
        printf("Please Enter Another Index \n");
        scanf("%i" , &AnotherIndex);
        // start to print Employee data in col 1

        /// Using Recursion to check if user read allocated index or not
        ReadEmployeesDetails(Emp , AnotherIndex);
    }


    else{
        ShowData(Emp , index);
    }

}

/// in case 1
void ViewEmployeeDetailsByID(struct Employee *EmpData ,  int ID){
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
void ViewEmployeeDetails(struct Employee *EmpData){

    int j , Found = 0;

    for(j=0 ; j<EmpSize ; j++){

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
void DeleteEmpByID(struct Employee *EmpData  , int ID){
    int i=0 , index , Found = 0;

    while(i < EmpSize){
        printf("%i" , EmpData[i].ID);
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
        EmpData[index].ID = -1;
        textattr(HighlightedColor);
        printf("Deleted Successfully ");
        textattr(NormalPen);
        /*for(j=index ; j<EmpSize ; j++){
            //EmpData[j] = EmpData[j+1];
        }
        */

    }

}


/// Delete Item By Using Name [in Case 4]
void DeleteEmpByName(struct Employee *EmpData  , char Name[10]){
    int i=0, index , Found = 0;

    while(i < EmpSize){
        if(strcmp(EmpData[i].Name , Name)== 0){
            Found = 1;
            index = i;
            break ;
        }
        i++ ;
    }
    if(Found == 0) printf("Not Found Employee With this Name ");
    // Delete Employee from array
    if(Found == 1){
        EmpData[index].ID = -1;
        textattr(HighlightedColor);
        printf("Deleted Successfully ");
        textattr(NormalPen);
        /*for(j=index ; j<10 ; j++){
            //EmpData[j] = EmpData[j+1];
            EmpData[j].ID = -1;
        }*/

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

    /// *******************************************  ///

    /// Start initialization Allocation

    printf("Please Enter Size Of Employee \n ");
    scanf("%i" , &EmpSize);

    /// initialization of struct
    struct Employee *Emp;
    // allocate array of Employee in heap
    Emp = (struct Employee *) malloc(EmpSize * sizeof(struct Employee));

    for(i=0 ; i<EmpSize ; i++){
      Emp[i].ID = -1;
    }


    /// *******************************************  ///


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
                        if(AddByIndex < EmpSize){
                            ReadEmployeesDetails(Emp , AddByIndex);
                        }
                        else{
                            printf("This index not belong to array of Employee that Max Size = %i" , EmpSize );
                            getch();
                        }
                        break;

                    /// Display by ID Option
                    case 1:
                        system("cls");
                        printf("Please Enter Employee ID to Display Information \n ");
                        scanf("%i" , &FilterByID);

                        ViewEmployeeDetailsByID(Emp , FilterByID);
                        getch();
                        break;


                    /// Display All Option
                    case 2:
                        system("cls");
                        _flushall();
                        ViewEmployeeDetails(Emp);
                        getch();
                        break;


                    /// Delete Employee by ID
                    case 3:
                        system("cls");
                        printf("Please Enter Employee ID to Delete Information \n ");
                        scanf("%i" , &FilterByID);
                        DeleteEmpByID(Emp , FilterByID);
                        getch();
                        break;


                    /// Delete Employee By Using Name
                    case 4:
                        system("cls");
                        printf("Please Enter Employee ID to Delete Information \n ");
                        scanf("%s" , &FilterByName);
                        DeleteEmpByName(Emp , FilterByName);
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
