#include "ReadWriter.h"
//iostream, fstream включены в ReadWriter.h
using namespace std;

// Функция для поиска максимального значения в массиве
int getMax(int array[], int n) {
    int res = array[0];
    for(int i = 1; i < n; ++i)
        if(array[i] > res)
            res = array[i];
    return res;
}

// Функция сортировки подсчетом
void countingSort(int *numbers, int array_size)
{
	int max = getMax(numbers, array_size);
    int countArray [max + 1];
    int sortedArray [array_size];

    for (int i = 0; i < max + 1; ++i) {
        countArray[i] = 0;
    }
    for (int i = 0; i < array_size; ++i) {
        countArray[numbers[i]] += 1;
    }
    for (int i = 1; i < max + 1; ++i) {
        countArray[i] += countArray[i - 1];
    }
    for (int i = array_size - 1; i >= 0; --i) {
        sortedArray[countArray[numbers[i]] - 1] = numbers[i];
        countArray[numbers[i]] -= 1;
    }
    for (int i = 0; i < array_size; ++i) {
        numbers[i] = sortedArray[i];
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
    countingSort(brr, n);

    //Запись в файл
    rw.writeArray(brr, n);

    //освобождаем память
    delete[] brr;

    return 0;
}
