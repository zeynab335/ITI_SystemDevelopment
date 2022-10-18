#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

int main()
{
    // in c language String data type not exist
    char ch , Name[10];
    int i;
    printf("Enter Your name \n");

     // exit loop when user press enter
     // 13 => ascii code of enter
     for(i=0 ; i<10; i++ ){
        // don't use scan fun
        ch = getche();
        if(ch == 13){
            /// ['0'] Terminator to know length of name [not size]
            Name[i] = '0';
            break;
        }
        Name[i] = ch;
     }

     // print name
     printf("Your Name is ");
     for(i=0; i<10 ; i++){
        if(Name[i]=='0') break;
        printf("%c" , Name[i]);

     }


    return 0;
}
