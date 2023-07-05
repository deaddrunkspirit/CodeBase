#include <iostream>
#include <fstream>
#include <stdlib.h>
#include <vector>
using namespace std;

int recursion = 0;

void heapify(int* numbers, int array_size, int i) {
	if (i >= array_size / 2) {
		recursion--;
    	return;
    }
	int largest = i;
    int left = 2 * i + 1;
    int right = 2 * i + 2;
    if (left < array_size && numbers[left] > numbers[i])
        largest = left;

    if (right < array_size && numbers[right] > numbers[largest])
        largest = right;

    if (largest != i) {
        std::swap(numbers[i], numbers[largest]);
        recursion += 1;
        heapify(numbers, array_size, largest);
    }
}

int buildHeap(int* numbers, int array_size) {
    int max = -1;
    for (int i = array_size / 2 - 1; i >= 0; --i) {
        heapify(numbers, array_size, i);
        if (recursion > max) max = recursion;
        recursion = 0;
    }
	return max;
}


int main() {
    int *brr;
    int n;

    fstream fin;
    fin.open("input.txt",ios::in);
    if(fin.is_open()) {
        fin >> n;
        brr = new int[n];
        for (int i = 0; i < n; i++) {
            fin >> brr[i];
        }

        fin.close();
    }
    int res = buildHeap(brr, n);
    fstream fout;
    fout.open("output.txt",ios::out);
    fout << res << endl;
    for (int i = 0; i < n; i++)
        fout << brr[i] << " ";

    fout.close();
    delete[] brr;
    return 0;
}