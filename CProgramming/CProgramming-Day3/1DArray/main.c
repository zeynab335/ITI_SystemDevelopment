#include <stdio.h>
#include <stdlib.h>
#define Size 4

int main()
{
    int i , Arr[Size]={0};
    // scan 4 numbers in array
    for(i=0 ; i<Size ; i++){
        printf("Enter Element %i in Array = " , i+1);
        scanf("%i" , &Arr[i]);
    }

    // print all elements in array
    for(i=0 ; i<Size ; i++){
        printf(" Element %i = %i \n" ,i+1 ,Arr[i]);
    }

    return 0;
}
