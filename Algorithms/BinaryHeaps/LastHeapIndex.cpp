#pragma once
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
	void readArray(int* arr, int length)
	{
		if (!fin.is_open())
			throw std::ios_base::failure("file not open");

		for (int i = 0; i < length; i++)
			fin >> arr[i];
	}

	void writeInt(int n)
	{
		if (!fout.is_open())
			throw std::ios_base::failure("file not open");
		fout << n << "\n";
	}
	void writeArray(int* arr, int n)
	{
		if (!fout.is_open())
			throw std::ios_base::failure("file not open");
		for (int i = 0; i < n; i++)
			fout << arr[i] << " ";
	}
};

int lastIndex(int* numbers, int array_size) {
    for (int i = 0; i < array_size; ++i) {
        if (array_size < 3 && numbers[0] < numbers[1]) return 1;
        if (numbers[i + 1] > numbers[i / 2]) return i;
    }
    return array_size - 1;
}


int main()
{
	ReadWriter rw;
    int *brr = nullptr;
    int n;
    //Ввод из файла
    n = rw.readInt();
	brr = new int[n];
    rw.readArray(brr, n);

    int res = lastIndex(brr, n);
    rw.writeInt(res);

    //освобождаем память
    delete[] brr;

    return 0;
}