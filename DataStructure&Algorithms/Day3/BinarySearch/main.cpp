#include <iostream>

using namespace std;

/// Binary Search in iterative way
int BinarySearch(int *arr ,  int Size ,int value ){
    cout << "go \n" ;
    int high = Size;
    int low = 0 ;
    while(low <= high){
        int mid = (low+high)/2;
        if (value == arr[mid]) return mid;
        else if(value < arr[mid]) {/// go left
            high = mid-1;
        }
        else { /// go right
           low = mid +1 ;
        }
    }
    return -1;
}



int main()
{
    int arr[] = {1,3,4,5};
    int searchValue = BinarySearch(arr,4,3);

    if(searchValue == -1 ) cout << "Not Found ";
    else cout << "arr[" << searchValue  << "] = " << arr[searchValue] ;

    return 0;
}
