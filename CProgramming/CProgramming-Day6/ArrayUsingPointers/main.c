#include <stdio.h>
#include <stdlib.h>

int main()
{
    int Arr[5] , i;

    printf("Please Enter Array Elements \n");
    for(i=0 ; i<5 ; i++){
        printf("Element %i = " , i+1);
        scanf("%i" , Arr+i);
    }

     for(i=0 ; i<5 ; i++){
        printf("Print Element %i = %i \n" , i+1 , *(Arr+i));
    }





    return 0;
}
