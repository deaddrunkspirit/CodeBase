#include <iostream>
#include <fstream>

class ReadWriter
{

private:

    std::fstream fin;
    std::fstream fout;

public:

    ~ReadWriter()
    {
        fin.close();
        fout.close();
    }

    ReadWriter()
    {
        fin.open("input.txt", std::ios::in);
        fout.open("output.txt", std::ios::out);
    }

    int readInt()
    {
        if (!fin.is_open())
            throw std::ios_base::failure("file not open");

        int n = 0;
        fin >> n;
        return n;
    }

    //This method only fill array. You should create it before call this method.
    void readArrays(int* arrId, int* arrWeight, int length)
    {
        if (!fin.is_open())
            throw std::ios_base::failure("file not open");

        for (int i = 0; i < length; i++)
            fin >> arrId[i] >> arrWeight[i];
    }

    void writeArrays(int* arrId,int* arrWeight, int n)
    {
        if (!fout.is_open())
            throw std::ios_base::failure("file not open");

        for (int i = 0; i < n; i++)
            fout << arrId[i] << "\t" << arrWeight[i] << "\n";
    }

};

int getMax(int array[], int n) {
    int res = array[0];
    for(int i = 1; i < n; ++i)
        if(array[i] > res)
            res = array[i];
    return res;
}

void countingSort(int *id, int *weight, int array_size)
{
    int max = getMax(weight, array_size);
    int countArray [max + 1];
    int sortedArrayWeight [array_size];
    int sortedArrayId [array_size];

    for (int i = 0; i < max + 1; ++i) {
        countArray[i] = 0;
    }
    for (int i = 0; i < array_size; ++i) {
        countArray[weight[i]] += 1;
    }
    for (int i = 1; i < max + 1; ++i) {
        countArray[i] += countArray[i - 1];
    }
    for (int i = 0; i < array_size; ++i) {
        sortedArrayWeight[countArray[weight[i]] - 1] = weight[i];
        sortedArrayId[countArray[weight[i]] - 1] = id[i];
        countArray[weight[i]] -= 1;
    }
    for (int i = 0; i < array_size; ++i) {
        weight[i] = sortedArrayWeight[array_size - i - 1];
        id[i] = sortedArrayId[array_size - i - 1];
    }
}

int main()
{
    //Объект для работы с файлами
    ReadWriter rw;

    int* weight = nullptr;
    int* id = nullptr;
    int n;

    //Ввод из файла
    n = rw.readInt();

    weight = new int[n];
    id = new int[n];
    rw.readArrays(id, weight, n);

    //Запуск сортировки, ответ в том же массиве (brr)
    countingSort(id, weight, n);

    //Запись в файл
    rw.writeArrays(id, weight, n);

    //освобождаем память
    delete[] id;
    delete[] weight;

    return 0;
}
