#include <iostream>
#include <fstream>
#include <string>

using namespace std;

//Основная задача - реализовать данный метод
int countMaxCross(string& riverMap) {
    char currentChar;
    int n = riverMap.size(), leftCross[n], rightCross[n], lastLeft[n], lastRight[n], i;
    leftCross[0] = 0;
    rightCross[0] = 1;
    lastLeft[0] = lastRight[0] = 0;
    for (i = 1; i <= riverMap.length(); i++) {
        currentChar = riverMap[i - 1];
        leftCross[i] = leftCross[i - 1];
        rightCross[i] = rightCross[i - 1];
        lastLeft[i] = lastLeft[i - 1];
        lastRight[i] = lastRight[i - 1];
        if (currentChar == 'L') {
            leftCross[i] = leftCross[lastLeft[i - 1]] + 1;
            lastLeft[i] = i;
        } else if (currentChar == 'R') {
            rightCross[i] = rightCross[lastRight[i - 1]] + 1;
            lastRight[i] = i;
        } else {
            leftCross[i] = leftCross[lastLeft[i - 1]] + 1;
            rightCross[i] = rightCross[lastRight[i - 1]] + 1;
            lastLeft[i] = lastRight[i] = i;
        }
        if (leftCross[i - 1] == 0) {
            leftCross[i] = 1;
        } if (rightCross[i - 1] == 1) {
            rightCross[i] = 2;
        } if (leftCross[i] + 1 < rightCross[i]) {
            rightCross[i] = leftCross[i] + 1;
        } if (rightCross[i] + 1 < leftCross[i]) {
            leftCross[i] = rightCross[i] + 1;
        }
    }
    return rightCross[n];
}

int main() {
    string riverMap;
    int res;

    ifstream fin;
    fin.open("input.txt");
    if (fin.is_open()) {
        getline(fin, riverMap);
        fin.close();
    }
    
    res = countMaxCross(riverMap);
    
    fstream fout;
    fout.open("output.txt", ios::out);
    fout << res;
    fout.close();

    return 0;
}
