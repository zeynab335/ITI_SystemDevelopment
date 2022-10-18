#include <stdio.h>
#include <stdlib.h>

int main()
{
    int i , j , Arr[3][4] , avg[4] = {0};

    for(i=0 ; i<3 ; i++){
        for(j=0 ; j<4 ; j++){
            printf("Enter number in row %i and col %i \n" , i , j);
            scanf("%i" , &Arr[i][j]);
            avg[j] += Arr[i][j];
        }
        printf("\n\n");
    }
    // print sum of all rows
    for(j=0 ; j<4 ; j++ ){
        printf("Sum Of Row %i = %i \n" , j , avg[j]/3 );
    }

    return 0;
}
