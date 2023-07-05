#include "ReadWriter.h"
//iostream, fstream включены в ReadWriter.h
using namespace std;

int getMaxNum(int array[], int n) {
    int res = array[0];
    for(int i = 1; i < n; ++i)
        if(array[i] > res)
            res = array[i];
    return res;
}

// Функция сортировки подсчетом
void countingSort(int *numbers, int array_size, int pos)
{
    int min = (numbers[0] / pos) % 256;
    int max = (numbers[0] / pos) % 256;
    for(int i = 1; i < array_size; ++i) {
        if ((numbers[i] / pos) % 256 > max) {
            max = (numbers[i] / pos) % 256;
        }
        if ((numbers[i] / pos) % 256 < min) {
            min = (numbers[i] / pos) % 256;
        }
    }
    int countArray [max - min + 1];
    int sortedArray [array_size];

    for (int i = 0; i < max - min + 1; ++i) {
        countArray[i] = 0;
    }
    for (int i = 0; i < array_size; ++i) {
        countArray[(numbers[i] / pos) % 256 - min] += 1;
    }
    for (int i = 1; i < max - min + 1; ++i) {
        countArray[i] += countArray[i - 1];
    }
    for (int i = array_size - 1; i >= 0; --i) {
        sortedArray[countArray[(numbers[i] / pos) % 256 - min] - 1] = numbers[i];
        countArray[(numbers[i] / pos) % 256 - min] -= 1;
    }
    for (int i = 0; i < array_size; ++i) {
        numbers[i] = sortedArray[i];
    }
}

// Функция цифровой сортировки
void radixSort(int *numbers, int array_size)
{
    int max = getMaxNum(numbers, array_size);
    for (int i = 1; max / i > 0; i *= 256) {
        countingSort(numbers, array_size, i);
    }
}

//Не удалять и не изменять метод main без крайней необходимости.
//Необходимо добавить комментарии, если все же пришлось изменить метод main.
int main()
{
    //Объект для работы с файлами
    ReadWriter rw;

    int *brr = nullptr;
    int n;

    //Ввод из файла
    n = rw.readInt();

    brr = new int[n];
    rw.readArray(brr, n);

    //Запуск сортировки, ответ в том же массиве (brr)
    radixSort(brr, n);

    //Запись в файл
    rw.writeArray(brr, n);

    //освобождаем память
    delete[] brr;

    return 0;
}
