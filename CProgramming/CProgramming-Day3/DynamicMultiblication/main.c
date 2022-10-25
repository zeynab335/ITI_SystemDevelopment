#include <stdio.h>
#include <stdlib.h>

int main()
{
    int i , j , k , M1[3][2] , M2[2][1] , result[3][1] ={0} ;
    int r1 , c1 , r2 , c2;

    do{
        // get row and col size
        printf("enter the number of row in Array 1 =");
        scanf("%d",&r1);

        printf("enter the number of column in Array 1 =");
        scanf("%d",&c1);

        // get row and col size
        printf("enter the number of row in Array 2 =");
        scanf("%d",&r2);

        printf("enter the number of column in Array 2 =");
        scanf("%d",&c2);
    }
    while(c1!=r2);

    // get col size
    // initialize Array M1
    printf("Enter Values in Array 1 \n");
    for(i=0 ; i<r1 ; i++){
        for(j=0 ; j<c1 ; j++){
            printf("Enter number in Matrix 1 row %i and col %i \n" , i , j);
            scanf("%i" , &M1[i][j]);
        }
        printf("\n\n");
    }

    // initialize Array M2
    printf("Enter Values in Array 2 \n");
    for(i=0 ; i<r2 ; i++){
        for(j=0 ; j<c2 ; j++){
            printf("Enter number in Matrix 2 row %i and col %i \n" , i , j);
            scanf("%i" , &M2[i][j]);
        }
        printf("\n\n");
    }

    for(i=0 ; i<r1 ; i++ ){
        for(j=0 ; j<c2 ; j++){
            //for(k=0;k<c1;k++)
            //{
            if(r1==c2){
                result[i][j] += M1[i][j]* M2[j][i];
                printf("%d %d %d \n" ,  result[i][j] , i , j);
            }
            else{
                result[i][j] = (M1[i][j] * M2[j][0]) + (M1[i][j+1] * M2[j+1][0]);

            }

                //result[i][j] = (M1[i][j] * M2[j][0]) + (M1[i][j+1] * M2[j+1][0]) ;
            //}
        }
    }

     // print Multiplication
     for(i=0 ; i<r1 ; i++ ){
        for(j=0 ; j<c2 ; j++){
            printf("%i \n" , result[i][j]);
        }
    }

    return 0;

}
