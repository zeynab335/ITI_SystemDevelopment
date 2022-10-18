#include <stdio.h>
#include <stdlib.h>


int main()
{
    int i , j , Arr[3][3] , sum[3] = {0};

    for(i=0 ; i<3 ; i++){
        for(j=0 ; j<3 ; j++){
            printf("Enter number in row %i and col %i \n" , i , j);
            scanf("%i" , &Arr[i][j]);
            sum[i] += Arr[i][j];
        }
        printf("\n\n");
    }
    // print sum of all rows
    for(j=0 ; j<3 ; j++ ){
        printf("Sum Of Row %i = %i \n" , j , sum[j] );
    }

    return 0;
}
