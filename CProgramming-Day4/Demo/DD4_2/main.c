#include <stdio.h>
#include <stdlib.h>
#include <string.h>


int ComNumeric (int n1 , int n2) {
    /// [n1 > n2] == [n1-n2] ==> return +ve
    /// [n1 < n2] == [n1-n2] ==> return -ve
    /// [n1 = n2] == [n1-n2] ==> return 0

    return n1 - n2 ;

}

int main()
{

    /// start Comparison in Numeric

        /*
        int num1 , num2;
        printf("Enter Num1 and Num2 \n");
        scanf("%i %i" , &num1 , &num2);

        printf("--------------- \n");

        int ComparisonValue = ComNumeric(num1 , num2);
        printf("%i" , ComparisonValue);

        */


    /// String Functions
        char str1[10] , str2[10];
        printf("Enter String 1 \n");
        scanf("%s" , str1);
        printf("Enter String 2 \n");
        scanf("%s" , str2);

        printf(" \n****************** \n");

        if(strcmp(str1 , str2)== 0)
            printf("Equality Strings");
        else
            printf("Not Equality Strings");


    // string Comparison



    return 0;
}
