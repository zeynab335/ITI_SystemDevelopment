#include <iostream>

using namespace std;


int SearchSortedArray(int *arr , int Size , int value ){

    /// cond =? check if it sorted or not
    /// if search in value = 2  ==>  arr[0]=3   ==> in this case not execute for loop
    for(int i=0 ; (i<Size) || (arr[i] < value) ; i++){
        cout << "enter\n" ;
        if(arr[i] == value)
            return i;
    }
    return -1;

}

int main()
{
    int arr[] = {1,3,4,5};
    int searchValue = SearchSortedArray(arr ,5 ,1);

    if(searchValue == -1 ) cout << "Not Found ";
    else cout << "arr[" << searchValue  << "] = " << arr[searchValue] ;

    return 0;
}
