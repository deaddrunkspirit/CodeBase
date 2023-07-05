#include "ReadWriter.h"
#include "vector"

using namespace std;


long long solve(int N, int M, vector<vector<long long>> &matrix, int i, int j) {
    if (i == 1 && j == 1) {
        return 1;
    }
    if (i < 1 || j < 1 || i > N || j > M) {
        return 0;
    }
    if (matrix[i][j] != -1) {
        return matrix[i][j];
    }

    return matrix[i][j] = (solve(N, M, matrix, i - 2, j - 1) + solve(N, M, matrix, i - 2, j + 1) +
                           solve(N, M, matrix, i - 1, j - 2) + solve(N, M, matrix, i + 1, j - 2));
}

int main() {
    ReadWriter rw;

    int N = rw.readInt(); //количество строк (rows)
    int M = rw.readInt(); //количество столбцов (columns)

    vector<vector<long long>> matrix(N + 1, vector<long long>(M + 1, -1));

    //решение
    long long res = solve(N, M, matrix, N, M);
    //результат в файл
    rw.writeLongLong(res);

    return 0;
}