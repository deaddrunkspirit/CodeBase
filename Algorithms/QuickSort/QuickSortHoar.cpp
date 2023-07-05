#include "ReadWriter.h"

int depth = 0;

void quickSort(int *numbers, int left_bound, int right_bound) {
    int x = numbers[(left_bound + right_bound) / 2];
    int left = left_bound;
    int right = right_bound;
    while (left <= right) {
        while (x > numbers[left] && left <= right) left++;
        while (x < numbers[right] && left <= right) right--;
        if (numbers[right] <= x && numbers[left] >= x && left <= right) {
            std::swap(numbers[left], numbers[right]);
            left++;
            right--;
        }
    }
    if (left_bound < right) {
        depth++;
        quickSort(numbers, left_bound, right);
    }
    if (right_bound > left) {
        depth++;
        quickSort(numbers, left, right_bound);
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