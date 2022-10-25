#include <stdio.h>
#include <stdlib.h>
#include <windows.h>

void gotoxy( int column, int line ){
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
    int i , n , r=1 , c;

    // without using do while

    do{
        printf("Enter Length of coords = ");
        scanf("%d" , &n);

    }
    while(n%2 ==0 || n<=1);


    // start rest program
    c= n/2+1;
    for(i=1 ; i<=(n*n) ; i++){
            gotoxy(c*3,r*3);
            printf("%d" , i);

            if(i%n == 0){
                r++;
            }
            else{
                r--;
                c--;
                if(r==0) r=n;
                if(c==0) c=n;

            }
        }



//    if(n%2 != 0){

   // }
    /*else{
        printf("Sorry your length not odd");
    }
    */


    return 0;
}
