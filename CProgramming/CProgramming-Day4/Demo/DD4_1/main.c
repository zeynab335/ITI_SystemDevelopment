#include <stdio.h>
#include <stdlib.h>
#include <conio.h>


void sum(){
    printf("hello");
    if(9>2)return;
}

int main()
{
    // Print Ascii of Extended Keys
    char ch ;

    do{
        printf("Please Press any Key \n" );
        ch = _getch();

        /// check if key is Extended Using First Byte == -32 Or Not
        if(ch == -32){
            ch=_getch();  // print the second byte from Buffer
            printf("You Press in Extended Key , And Ascii Code is %i " , ch);
        }
        else{
            printf("You Press in Normal Key %c , And Ascii Code is %i " ,ch ,ch);
        }
    }
    while(ch != 0x0d);

    return 0;
}
