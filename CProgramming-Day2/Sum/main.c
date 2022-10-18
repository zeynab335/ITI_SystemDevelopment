#include <stdio.h>
#include <stdlib.h>

int main()
{
    int sum=0 , i=0 , x;


    do{
        printf("Enter Number %d = " , i+1);
        scanf("%d" , &x);
        sum += x;
        i++;
    }
    while(sum < 100);
    printf("Sum = %d" , sum);

    return 0;
}
