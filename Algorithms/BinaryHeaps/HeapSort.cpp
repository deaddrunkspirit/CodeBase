#include <iostream>
#include <fstream>
#include <stdlib.h>
#include <vector>
using namespace std;

void heapify(int* numbers, int array_size, int i) {
    int largest = i;
    int left = 2 * i + 1;
    int right = 2 * i + 2;
    if (left < array_size && numbers[left] > numbers[i])
        largest = left;
 
    if (right < array_size && numbers[right] > numbers[largest])
        largest = right;
 
    if (largest != i) {
        std::swap(numbers[i], numbers[largest]);
        heapify(numbers, array_size, largest);
    }
}
 
void buildHeap(int* numbers, int array_size) {
    for (int i = array_size / 2 - 1; i >= 0; --i) {
        heapify(numbers, array_size, i);
    }
}
 
void heapSort(int* numbers, int array_size) {
    buildHeap(numbers, array_size);
    for (int i = array_size - 1; i >= 0; --i) {
        std::swap(numbers[0], numbers[i]);
        array_size--;
        heapify(numbers, array_size, 0);
    }
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
    heapSort(brr, n);
    fstream fout;
    fout.open("output.txt",ios::out);
    for (int i = 0; i < n; i++)
        fout << brr[i] << " ";

    fout.close();
    delete[] brr;
    return 0;
}