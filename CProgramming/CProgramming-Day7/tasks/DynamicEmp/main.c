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




char* _LineEditor (int col , int row , int SChar , int EChar ) {
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

    // return address of Array of Character
    char** LineEditor (int c , int *size ,int *XPos , int *YPos ,int *SChar , int *EChar )
    {
        int i, j , colPosition , ExFlag = 0 , endPosition , row;
        // to know what number of col will go in end
        char ch , *end , *current , *start  , **line ;

        /// Start Allocate Array to Each Lines
        line = (char**) malloc(c*sizeof(char*));

        for(i=0 ; i<c ; i++){
            line[i] = (char*) malloc(size[i]*sizeof(char));
        }

        ///



        for(i=0 ; i<c ; i++){
            start           = line[i];
            current         = line[i];
            end             = line[i];

            colPosition     = XPos[i];
            row             = YPos[i];

            /// To get character by character and store in line of index
            for(j=0 ; j<size[i] ; j++){
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

                    /// press enter
                    case Enter:
                        //null terminator
                        *end = '\0';
                        ExFlag = 1;
                        break;

                    default:
                        if(ch >= SChar[i] && ch <= EChar[i]){

                            *current = ch;
                            printf("%c",ch);
                            colPosition++;
                            current++;
                            end++;
                            endPosition ++ ;
                        }

                        break;
                }




            }
            printf("\n");

        }


        for(i=0 ; i<c ; i++){
            for(j=0 ; j<size[i] ; j++){
                printf("\n %s" , line[i][j] );
            }
        }







    }
    void ShowData(struct Employee *EmpData  , int index)
    {
        system("cls");
        int i , c=8;
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
        for(i=0 ; i<3 ; i++){
            gotoxy(40, 5 + 3*i);
            printf("%s : " ,Labels[i] );
        }

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


        LineEditor (c , SizeOFLines ,XPos , YPos ,SChar , EChar );



        /// Free Allocations in heap

        free(Labels);
        free(SizeOFLines);
        free(XPos);
        free(YPos);
        free(SChar);
        free(EChar);

}


int main()
{


    struct Employee *Emp;
    int i;
    // allocate array of Employee in heap
    Emp = (struct Employee *) malloc(2 * sizeof(struct Employee));

    for(i=0 ; i<2 ; i++){
      Emp[i].ID = -1;
    }

    ShowData(Emp , 0);
    getch();


    return 0;
}
