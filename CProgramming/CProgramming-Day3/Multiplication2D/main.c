#include <stdio.h>
#include <stdlib.h>

int main()
{
    int i , j , k , M1[3][2] , M2[2][1] , result[3][1] ={0} ;

    // initialize Array M1
   for(i=0 ; i<3 ; i++){
        for(j=0 ; j<2 ; j++){
            printf("Enter number in Matrix 1 row %i and col %i \n" , i , j);
            scanf("%i" , &M1[i][j]);
        }
        printf("\n\n");
    }

    // initialize Array M2
    for(i=0 ; i<2 ; i++){
        for(j=0 ; j<1 ; j++){
            printf("Enter number in Matrix 2 row %i and col %i \n" , i , j);
            scanf("%i" , &M2[i][j]);
        }
        printf("\n\n");
    }

    // start Multiplication
    // M1(row) * M2(col)
    // M1[0][0] * M2[0][0] + M1[0][1] + M2[1][0]
    // M1[1][0] * M2[0][0] + M1[1][1] + M2[1][0]
    // M1[2][0] * M2[0][0] + M1[2][1] + M2[1][0]

    for(i=0 ; i<3 ; i++ ){
        for(j=0 ; j<1 ; j++){
            //for(k=0;k<2;k++)
            //{
                //result[i][j]+=M1[i][k]* M2[k][j];
                result[i][j] = (M1[i][j] * M2[j][0]) + (M1[i][j+1] * M2[j+1][0]) ;
            //}
            }
    }

     // print Multiplication
     for(i=0 ; i<3 ; i++ ){
        for(j=0 ; j<1 ; j++){
            printf("%i \n" , result[i][j]);
        }
    }

    return 0;

}
