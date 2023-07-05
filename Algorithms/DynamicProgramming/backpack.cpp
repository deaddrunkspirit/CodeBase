#include <iostream>
#include <sstream>
#include <algorithm>

using namespace std;


int main() {
    int N, W, k;
    cin >> N >> W;
    int mass[N], cost[N], matrix[N + 1][W + 1];

    for (int i = 0; i < N; i++) {
        cin >> mass[i];
    }

    for (int i = 0; i < N; i++) {
        cin >> cost[i];
    }

    for (int i = 0; i <= W; i++) {
        matrix[0][i] = 0;
    }

    for (int i = 0; i <= N; i++) {
        matrix[i][0] = 0;
    }

    for (int i = 1; i <= N; i++) {
        for (int j = 1; j <= W; j++) {
            k = 0;
            if(j >= mass[i - 1]) {
                k = matrix[i - 1][j - mass[i - 1]] + cost[i - 1];
            }
            matrix[i][j] = max(k, matrix[i - 1][j]);
        }
    }
    cout << matrix[N][W];

    return 0;
}