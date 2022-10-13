#include <stdio.h>
#include <stdlib.h>

#include <conio.h>



int main()
{
    // getChar
    char c1;
    printf("Enter Character \n");
    c1 = getchar();
    printf("Using getChar %c \n" ,c1);

    // **********************

    // getC ==> files [getc(File f) , putc(char c , file f)]


    // **********************
    // che ==> enter automatic
    /* The getche () function reads a single character from the keyword,
        but data is displayed on the output screen.
    */
    char c2;
    printf("Enter Character \n");
    c2 = getche();
    printf("Using getChar %c \n" ,c2);


    /* getch () function reads a single character from the keyboard.
        It doesn’t use any buffer,
    */
    char c3;
    printf("Enter Character \n");
    c3 = getch();
    printf("Using getChar %c \n" ,c3);


    return 0;
}
