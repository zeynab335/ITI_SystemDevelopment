#include <stdio.h>
#include <stdlib.h>

int main()
{
    int num1 , num2;
    printf("Please Enter num1 and num2 \n");
    printf("num1 = ");
    scanf("%d" , &num1);
    printf("num2 = ");
    scanf("%d" , &num2);

    int num1_ = 0b1011;
    int num2_ = 0b1001;

    int XOR = num1_ ^ num2_;
    int OR = num1_ | num2_;
    //int AND = num1 & num2;


    printf("XOR Bitwise %b\n" , XOR);
    printf("OR Bitwise %b\n" , OR);
    //printf("AND Bitwise %d\n" , AND);


    return 0;
}
