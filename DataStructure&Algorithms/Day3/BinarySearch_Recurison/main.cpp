#include <iostream>

using namespace std;

/// work done in sorted array
/// Binary Search in Recursive way
int BinarySearch(int *arr , int low , int high , int value ){
    if(low <= high){
        int mid = (low+high)/2;
        if (value == arr[mid]) return mid;
        else if(value < arr[mid]) {/// go left
            return BinarySearch(arr , low , mid-1 , value );
        }
        else { /// go right
            return BinarySearch(arr , mid +1 , high , value );
        }
    }
    return -1;
}



int main()
{
    int arr[] = {1,3,4,5,6};
    int searchValue = BinarySearch(arr,0,5, 3);

    if(searchValue == -1 ) cout << "Not Found ";
    else cout << "arr[" << searchValue  << "] = " << arr[searchValue] ;

    return 0;
}
