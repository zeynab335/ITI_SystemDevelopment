#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

int main()
{
    char Name[10] , ch;
    int i;

    printf("Please Enter Your Name \n");


    ///using gets and puts [Not Need to make delimeter]
    //gets(Name);
    //puts(Name);


    /// Using getChe [Null terminator (delimeter \0) ]

    for(i=0 ; i<10 ; i++){
        ch = _getche();
        if(ch == 13) {
            Name[i] = '\0';
            break;
        }
        Name[i] = ch;
    }

    printf("\n");

    /// Print Name array using For loop

    for(i=0 ; i<10 ; i++){
        printf("%c" , Name[i]);
        if(Name[i] == '\0') break;
    }


    /// Print Name array using while loop
    /*
    i = 0;
    while(Name[i]!= '\0'){
        printf("%c" , Name[i]);
        i++ ;
    }
    */



    return 0;
}
