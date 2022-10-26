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
void printLine(int col , int row , int size){
    int i;
    for(i=0 ; i< size; i++){
        gotoxy(col+i , row);
        textattr(HighlightedColor);
        printf(" ");
    }
}

/// Start LineEditor

/// Start LineEditor
  // return address of Array of Character
    char** LineEditor (int c , int *size ,int *XPos , int *YPos ,int *SChar , int *EChar )
    {
        int i, j, circle, colPosition , ExFlag = 0 , endPosition , row , ExFlag2=0;
        // to know what number of col will go in end
        char ch , *end , *current , *start  , **line ;

        /// Start Allocate Array to Each Lines
        line = (char**) malloc(c*sizeof(char*));
        for(i=0 ; i<c ; i++){
            line[i] = (char*) malloc(size[i]*sizeof(char));
        }

        /// Initialize lines

        for(i=0 ; i<c ; i++){
            for(j=0; j<size[i]-1;j++){
                line[i][j] = ' ';
            }
            line[i][size[i]-1] = '\0';
        }



        /// For Each line in Form Get Data in Line

        i=0 ;
        j=0;
        gotoxy(XPos[0],YPos[0]);

        while(i<c && !ExFlag2){

            colPosition     = XPos[i];
            endPosition     = XPos[i];
            row             = YPos[i];

            start           = line[i];
            current         = line[i];
            end             = line[i];

            j=0 , circle=0;


            /// To get character by character and store in line of index
                do{
                    gotoxy( colPosition , row);
                    ExFlag=0;
                    ExFlag2 = 0;
                    /*if (j >= size[i]){
                            *end = '\0';
                            ExFlag=1;
                            break;
                    }
                    else ExFlag=0;
                    */

                    ch = getch();

                    switch(ch){

                        /// Exist to menu Form
                        case Esc:
                            ExFlag=1;
                            ExFlag2 = 1;

                            /// Filter Lines to delete in display
                            line[0][0] = -1;

                            break;

                        /// press Tap
                        case 9:
                            ///null terminator
                                if(j<=size[i]){
                                    *end = '\0';
                                    ExFlag = 1;

                                    if(i==c-1){
                                        circle = 1;
                                        row = YPos[0];
                                    }
                                    break;
                                }


                            break;


                        /// ********** Extended Keys  ************

                        /// press home case
                        case 71:
                            current = start;
                            colPosition = XPos[i] ;
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

                        /// Press Down
                         case 80:
                            ///null terminator
                            *end = '\0';
                            ExFlag = 1;
                            if(i==c-1){
                                circle = 1;
                                row = YPos[0];
                            }

                            break;


                            /// Press UP
                            case 72:
                                *end = '\0';
                                ExFlag = 1;
                                i--;i--;
                                /*if(i!=0){
                                    *end = '\0';
                                    ExFlag = 1;
                                    i--;
                                }
                                */

                            break;

                        /// press enter
                        case Enter:
                            //null terminator
                            *end = '\0';
                            ExFlag = 1;
                            ExFlag2 = 1;

                            break;

                        default:
                            if(ch >= SChar[i] && ch <= EChar[i]){
                                if(colPosition < XPos[i]+size[i]){
                                    *current= ch;
                                    current++;
                                    printf("%c",ch);
                                    colPosition++;
                                    endPosition++ ;
                                    end++;
                                    if(j<size[i]){
                                        j++;
                                    }

                                }
                            }


                            break;
                    }


            }while(!ExFlag);

                if(circle == 1){
                    i=0;
                }
                else i++;
        }


        return line;

    }



/// SHow data by using getxy Function

    void ShowData(struct Employee *EmpData  , int index)
    {
        system("cls");
        int i=0 ,c=8;
        int *SizeOFLines , *XPos , *YPos , *SChar , *EChar ;
        char **Labels;

        /// Start Initialization of Collections in Heap
        // initialize pointers to Array of Size in Each line
        SizeOFLines = (int*) malloc(c*sizeof(int));

        // initialize pointers to Array of XPositions , YPositions

        XPos = (int*) malloc(c*sizeof(int));
        YPos = (int*) malloc(c*sizeof(int));

        // initialize pointers to Array of Start Hexi number of Start , End Characters
        SChar = (int*) malloc(c*sizeof(int));
        EChar = (int*) malloc(c*sizeof(int));

        /// end Initialization of Collections in Heap



        /// Start Printing Form Details
        Labels = (char**) malloc(8*sizeof(char*));

        for(i=0 ; i<8 ; i++){
            Labels[i] = (char*) malloc(10*sizeof(char*));
        }
        Labels[0] = "ID";
        Labels[1] = "Name";
        Labels[2] = "Salary";
        Labels[3] = "Address";
        Labels[4] = "Deduct";
        Labels[5] = "Age";
        Labels[6] = "Overtime";
        Labels[7] = "Gender";


        /// end Printing Form Details

        // start to print Employee data in col 1
        for(i=0 ; i<5 ; i++){
            gotoxy(3, 5 + 3*i);
            printf("%s : " , Labels[i] );
        }

        // start to print Employee data in col 2
        gotoxy(40, 5);
        printf("%s:" ,Labels[5] );
        gotoxy(40, 8);
        printf("%s:" ,Labels[6] );
        gotoxy(40, 11);
        printf("%s:" ,Labels[7] );

        /// End Printing Form Details


        SizeOFLines[0]=2;               /// ID Size
        SizeOFLines[1]=10;              /// Name Size
        SizeOFLines[2]=5;               /// Salary
        SizeOFLines[3]=15;              /// Address
        SizeOFLines[4]=5;               /// Deduct
        SizeOFLines[5]=2;               /// Age
        SizeOFLines[6]=5;               /// Overtime
        SizeOFLines[7]=1;               /// Gender

        /// Start Initialize XPos and YPos

        for(i=0 ; i<5 ; i++) XPos[i] = 15;
        for(i=5 ; i<8 ; i++) XPos[i] = 55;

        for(i=0 ; i<5 ; i++) YPos[i] = 5+(3*i);
        YPos[5] = 5;
        YPos[6] = 8;
        YPos[7] = 11;

        /// end Initialize XPos and YPos


        /// Start Initialize Start and End Characters
        for(i=0 ; i<c ; i++){
            switch(i){
                /// ID - Age
                case 0 :
                case 5 :
                    SChar[i]=45;
                    EChar[i]=57;
                    break;

                /// Name - Address - Gender Characters
                case 1 :
                case 3 :
                case 7 :
                    SChar[i]=97;
                    EChar[i]=122;
                    break;

                /// Salary - Deduct - Overtime Characters
                case 2 :
                case 4 :
                case 6 :
                    SChar[i]=48;
                    EChar[i]=57;
                    break;
            }

        }
        /// end Initialize Start and End Characters


        /// Start Drawing Inputs Of Form
        for(i=0 ; i< c ; i++){
            printLine(XPos[i], YPos[i] , SizeOFLines[i]);
        }
        /// end Drawing Inputs Of Form


        char** Data = LineEditor(c , SizeOFLines ,XPos , YPos ,SChar , EChar );

        EmpData[index].ID= atoi(Data[0]);
        strcpy(EmpData[index].Name , Data[1]);
        EmpData[index].Salary   = atoi(Data[2]);
        strcpy(EmpData[index].Adress , Data[3]);

        EmpData[index].Deduct   = atoi(Data[4]);
        EmpData[index].Age      = atoi(Data[5]);
        EmpData[index].Overtime = atoi(Data[6]);
        EmpData[index].Gender  = Data[7];

        /// Free Allocations in heap

        free(Labels);
        free(SizeOFLines);
        free(XPos);
        free(YPos);
        free(SChar);
        free(EChar);

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

    while(i < EmpSize){
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

        if(EmpData[j].ID > 0 && strlen(EmpData[j].Name) >= 0){
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
    int i  , j , Current=0 , FilterByID , AddByIndex;

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
      for(j=0; j<10 ; j++){
        Emp[i].Name[j] = ' ';
      }
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

     free(Emp);


    return 0;
}
