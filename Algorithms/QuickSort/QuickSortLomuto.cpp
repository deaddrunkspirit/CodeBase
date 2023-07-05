#include "ReadWriter.h"

int depth = -1;

int lomuto(int* numbers, int left, int right) {
    int pivot = numbers[right];
    int i = left;
    for (int j = left; j < right; ++j) {
        if (numbers[j] <= pivot) {
            std::swap(numbers[i++], numbers[j]);
        }
    }
    std::swap(numbers[i], numbers[right]);
    return i;
}

void quickSort(int *numbers, int left_bound, int right_bound) {
    if (left_bound < right_bound) {
        depth++;
        int p = lomuto(numbers, left_bound, right_bound);
        if (p > 0) {
            quickSort(numbers, left_bound, p - 1);
        }
        quickSort(numbers, p + 1, right_bound);
    }
}

int main() {
    ReadWriter rw;

    //Ввод из файла
    int n = rw.readInt();

    int* arr = new int[n];
    rw.readArray(arr, n);

    quickSort(arr, 0, n - 1);
    //Запись в файл
    rw.writeInt(depth);
    rw.writeArray(arr, n);

    //освобождаем память
    delete[] arr;
    return 0;
}