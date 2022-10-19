#include <stdio.h>
#include <stdlib.h>

int main()
{
    int TwoDArray[2][2] = {{1,2},{3,4}};
    int i;

    // loop in 2D Array using one for loop
    for(i=0 ; i<4; i++){
        printf("%i %i \n " , i/2 , i%2);
        printf("2D Array = %i \n" , TwoDArray[i/2][i%2]);
    }


    return 0;
}
