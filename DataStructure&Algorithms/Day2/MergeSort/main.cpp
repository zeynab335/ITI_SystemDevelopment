#include <iostream>

using namespace std;


void Merge(int *arr , int LFsIndex ,int LLsIndex , int RFsIndex ,int RLsIndex ){
    /// because it not start from index 0 [because of Recursion]
    int index = LFsIndex;
    /// SaveFirst => used to copy data in temp array into origin array
    int SaveFirst = LFsIndex;

    const int Size = (LLsIndex-LFsIndex+1) + (RFsIndex-RLsIndex+1) ;
    int *Temp = new int[Size];

    /// case 1 [when LF <= LR and RF <= RL] ==> take lower size
    while((LFsIndex <= LLsIndex) && (RFsIndex <= RLsIndex)){
        if(arr[LFsIndex] < arr[RFsIndex]) Temp[index++]  = arr[LFsIndex++];
        else Temp[index++]  = arr[RFsIndex++];
    }


    /// case 2 [when Looping in Left Array ending, in this case loop in the rest elem in Right Array ]
    while(RFsIndex <= RLsIndex){
        Temp[index++]  = arr[RFsIndex++];
    }

     /// case 3 [when Looping in Right Array ending, in this case loop in the rest elem in Left Array ]
    while(LFsIndex <= LLsIndex){
        Temp[index++]  = arr[LFsIndex++];
    }


    /// deep copy of all elem in Temp array into original array
    /// use SaveFirst , RLsIndex because it's change in fun scope
    for(int i= SaveFirst ; i<=RLsIndex ; i++){
        arr[i] = Temp[i];
    }
}

/// Divide array into sub arrays
void MergeSort(int *arr , int FsIndex ,int LsIndex ){
    /// false when FsIndex = LsIndex
    if(FsIndex < LsIndex){
        int MidIndex = (FsIndex+LsIndex)/2 ;
        MergeSort(arr, FsIndex , MidIndex);
        MergeSort(arr, MidIndex+1 , LsIndex);
        Merge(arr, FsIndex , MidIndex ,MidIndex+1 , LsIndex);
    }
}


int main()
{

    /// ASC Bubble Sort
    int *arr = new int[4]{1,4,2,3};
    MergeSort(arr,0,3);

    /// print sorted data
    cout << "\n******** Sorted ASC ********\n" ;
    for(int i=0 ; i<4 ; i++){
        cout << "Element" << i+1 << " = " << arr[i] << "\n";
    }

    return 0;
}
