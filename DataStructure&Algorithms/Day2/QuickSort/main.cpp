// C++ Implementation of the Quick Sort Algorithm.
#include <iostream>
using namespace std;

int partition(int arr[], int start, int end)
{

	int pivot = arr[start];

	int count = 0;
	for (int i = start + 1; i <= end; i++) {
		if (arr[i] <= pivot)
			count++;
	}

	// Giving pivot element its correct position
	int pivotIndex = start + count;
	swap(arr[pivotIndex], arr[start]);


	for (int i = 0; i <= end; i++) {
		cout << arr[i] << " ";
	}
	cout << "\n count = " << count  << "\n";


	// Sorting left and right parts of the pivot element
	int i = start, j = end;


	while (i < pivotIndex && j >= pivotIndex) {

		while (arr[i] <= pivot) {
			i++;   // to go to next elem to check with arr[j]
		}

		while (arr[j] > pivot) {
			j--;
		}

		if (i < pivotIndex && j >= pivotIndex) {
			swap(arr[i++], arr[j--]);
		}
	}

	cout << pivotIndex << "\n";

	return pivotIndex;
}

void quickSort(int arr[], int start, int end)
{

	// base case
	if (start >= end)
		return;

	// partitioning the array
	int p = partition(arr, start, end);

	// Sorting the left part
	quickSort(arr, start, p - 1);

	// Sorting the right part
	quickSort(arr, p + 1, end);
}

int main()
{

	int arr[] = { 5,2,4,1,10,6,0 };
	int n = sizeof(arr) / sizeof(int);

	quickSort(arr, 0, n - 1);

	for (int i = 0; i < n; i++) {
		cout << arr[i] << " ";
	}

	return 0;
}
