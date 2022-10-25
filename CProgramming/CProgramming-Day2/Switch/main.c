#include <stdio.h>
#include <stdlib.h>

int main()
{

    int num;

    printf("Please Choose your item in menu :\n 1- item1 \n 2- item2 \n 3-item3 \n  ");
    scanf("%d" , &num);
        switch(num){
            case 1:
                printf("Item 1 in Menu ");
            break;
            case 2:
                printf("Item 2 in Menu ");
            break;
            case 3:
                printf("Item 3 in Menu ");
            break;

        }


    return 0;
}
