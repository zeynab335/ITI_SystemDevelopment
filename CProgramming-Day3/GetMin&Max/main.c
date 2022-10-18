#include <stdio.h>
#include <stdlib.h>
#define Size 4

int main()
{
    int i ,j ,Arr[Size]={0} , MinValue   , MaxValue;
    // scan 4 numbers in array
    for(i=0 ; i<Size ; i++){
        printf("Enter Element %i in Array = " , i+1);
        scanf("%i" , &Arr[i]);
    }


    // get min value
    MinValue = Arr[0];
    MaxValue = Arr[0];

    for(i=0; i<Size ; i++){
        if(Arr[i] > MaxValue){
            MaxValue = Arr[i];
        }
        if(Arr[i] < MinValue){
            MinValue = Arr[i];
        }
    }

    printf("Minimum Value = %i \n" , MinValue);
    printf("Maximum Value = %i " ,  MaxValue);


    return 0;
}
