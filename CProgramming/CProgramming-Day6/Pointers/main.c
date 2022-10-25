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
char* LineEditor (int col , int row , int SChar , int EChar ) {
    char line[10] , ch , FinalArr[10];
    char *end , *current , *start ;

    // to know what number of col will go in end
    int colPosition = col  , ExFlag = 0 , endPosition=col;

    start = line;
    current = line;
    end = line;

    printLine(colPosition , row);

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
                current--;
                colPosition -- ;
                break;

            /// press right arrow Case
            case 77:
                current++;
                colPosition ++;
                break;

            /// press enter
            case Enter:
                //null terminator
                ExFlag = 1;
                *end = '\0';
                break;

            default:
                if(ch >= SChar && ch <= EChar){
                    *current = ch;
                    printf("%c",ch);

                    current++;
                    colPosition++;

                    end++;
                    endPosition ++ ;
                }

                break;
        }


    }while(!ExFlag);





    return line;

}





int main()
{
    char ch[10] ;

    ch = LineEditor(15,5,97,122);

    //strcpy(ch , LineEditor(15,5,97,122)) ;

    printf("%s" , ch);


    return 0;
}
