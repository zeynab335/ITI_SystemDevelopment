#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <string.h>

int main()
{
    char FName[10] , SecName[10] , FullName[20] = "" ;
    int i;

    printf("Please Enter Your First Name \n");
    gets(FName);

    printf("Please Enter Your Second Name \n");
    gets(SecName);

    strcat(FullName , FName);
    strcat(FullName , " ");
    strcat(FullName , SecName);


    printf("FullName is = %s" , FullName );











    return 0;
}
