#include <iostream>

using namespace std;

int getIndexOfMinValue(int arr[] , int fsIndex ,int lsIndex){
    int index = fsIndex;
    for(int i= fsIndex+1 ; i<lsIndex ; i++){
        if(arr[i] > arr[index]) index = i;
    }

    return index;
}

void SelectionSort(int arr[] , int Size){
    int index;
    for(int i=0 ; i<Size ; i++){
        index = getIndexOfMinValue(arr,i,Size);
        swap(arr[i] ,  arr[index]);
    }

    /// print sorted data
    for(int i=0 ; i<Size ; i++){
        cout << "Element" << i+1 << " = " << arr[i] << "\n";
    }
}



int main()
{
    int *arr = new int[5]{10,8,4,6,5};

    SelectionSort(arr,5);


    return 0;
}
