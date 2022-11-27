#include <stdio.h>
#include <stdlib.h>

struct simple{
    float c ;  int a;
};
struct complex {
    simple sa[4];
    simple s;
};
int main()
{
    complex c1 ;
    float *temp = &c1.sa[2].c;
    c1.sa[2].c = 22.2;


    printf("%.1f" , *&*temp);

    int a=10,b;
b=a++ + ++a;
printf("%d,%d,%d,%d",b,a++,a,++a);

    return 0;
}
