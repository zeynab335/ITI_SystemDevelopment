#include <stdio.h>
#include <stdlib.h>

int main()
{
    /// Deceleration
    // **Marks => pointer to Pointer
    int **Marks , *sumOfSt , *AvgOfSub , i , j ;
    int StdNum , SubNum ;

    // get Student Numbers
    printf("Please Enter Student Numbers \n");
    scanf("%i" , &StdNum);


    // get Subject Numbers
    printf("Please Enter Subject Numbers \n");
    scanf("%i" , &SubNum);


    /// Initialization
    // initialize mark pointer [array of Student]
    Marks = (int**) malloc(StdNum * sizeof(int*));

    // initialize sum pointer
    sumOfSt = (int*) malloc(StdNum*sizeof(int));

    AvgOfSub = (int*) malloc(SubNum*sizeof(int));

   for(i=0 ; i<StdNum ; i++){
        Marks[i] = (int*) malloc(SubNum*sizeof(int));
   }

   // initialization in sum
   for(i=0 ; i<StdNum ; i++){
        sumOfSt[i] = 0 ;
   }

    // initialization in avg
   for(i=0 ; i<SubNum ; i++){
        AvgOfSub[i] = 0 ;
   }


   for(i=0 ; i<StdNum ; i++){
    for(j=0 ; j<SubNum ; j++){
        printf("Enter Student = %i and Subject = %i ==> " , i+1 ,j+1);
        scanf("%i" , &Marks[i][j]);
        sumOfSt[i] += Marks[i][j] ;
        AvgOfSub[j]+= Marks[i][j];
    }
   }

   for(i=0 ; i<StdNum ; i++){
    for(j=0 ; j<SubNum ; j++){
        printf("\n Student %i and Subject %i = %i" , i+1 , j+1, Marks[i][j]);
    }
   }

    for(i=0 ; i < SubNum ; i++){
        printf("\n Avg of Subject %i = %i" , i+1 , AvgOfSub[i]/StdNum);
    }

    for(i=0 ; i < StdNum ; i++){
        printf("\n SUM of Student %i Grades are =  %i" , i+1 ,sumOfSt[i]);
    }


    /// Free Pointer address from heap
    for(i=0 ; i<StdNum ; i++){
        free(Marks[i]);
        free(sumOfSt[i]);
    }
    for(i=0 ; i<SubNum ; i++){
        free(AvgOfSub[i]);
    }
    free(Marks);




    return 0;
}
