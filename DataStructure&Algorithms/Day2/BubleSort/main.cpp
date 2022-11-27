#include <iostream>

using namespace std;

void BubbleSortAsc(int *arr , int Size){
    int index;
    bool isSorted;

    for(int i=0 ; i<Size ; i++){
        isSorted = true;
        for(int j=0 ; j<Size-i-1 ; j++){
            if(arr[j] > arr[j+1]){
                swap(arr[j] , arr[j+1]);
                isSorted = false;
            }
        }
        if(isSorted) return;
    }
}



void BubbleSortDesc(int *arr , int Size){
    int index;
    bool isSorted;

    for(int i=0 ; i<Size ; i++){
        isSorted = true;
        for(int j=0 ; j < Size-i-1 ; j++){
            if(arr[j] < arr[j+1]){
                swap(arr[j] , arr[j+1]);
                isSorted = false;
            }
        }
        if(isSorted) return;
    }
}

int main()
{

    /// ASC Bubble Sort
    int *arr = new int[5]{1,2,3,6,5};
    BubbleSortAsc(arr,5);

    /// print sorted data
    cout << "\n********************* Sorted ASC *********************\n" ;
    for(int i=0 ; i<5 ; i++){
        cout << "Element" << i+1 << " = " << arr[i] << "\n";
    }

    /// DESC Bubble Sort
    int *arr2 = new int[5]{1,2,3,6,5};
    BubbleSortDesc(arr2,5);

    /// print sorted data
    cout << "\n ********************* Sorted DESC *********************\n" ;
    for(int i=0 ; i<5 ; i++){
        cout << "Element" << i+1 << " = " << arr2[i] << "\n";
    }

    return 0;
}
