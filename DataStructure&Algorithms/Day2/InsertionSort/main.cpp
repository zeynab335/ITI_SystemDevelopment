#include <iostream>
using namespace std;

// insertion sort
void InsertionSortAlgo(int arr[], int n)
{
	int i, j;
	for (i = 1; i < n; i++)
	{
        for(int j=i-1 ; j>=0 ; j-- ){
            if(arr[j] > arr[j+1]){
                swap(arr[j+1] , arr[j]);
            }
        }
    }
}


int main()
{
	int *arr = new int[6]{ 10,5,4,2,1,11};

	InsertionSortAlgo(arr, 6);
	for (int i = 0; i < 6; i++)
		cout << arr[i] << " ";

	return 0;
}
