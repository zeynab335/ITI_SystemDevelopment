#include <stdio.h>
#include <stdlib.h>



void SwapByValue(int x , int y){
    int temp = x;
    x = y;
    y = temp;
}

void SwapByAddress(int *x , int *y){
    int temp = *x;
    *x = *y;
    *y = temp;
}



int main()
{
    int x=5  , y=6 ;

    /// SwapByUsing Value
    SwapByValue(x,y);

     printf(" Swap By Value \n X= %i \n y= %i\n" , x , y);

    /// SwapByUsing Address
    SwapByAddress(&x,&y);

    printf("Swap By Address \n X= %i \n y= %i \n" , x , y);



    return 0;
}
