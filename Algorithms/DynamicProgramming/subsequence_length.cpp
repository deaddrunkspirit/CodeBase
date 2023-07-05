#include <iostream>
#include <string>
#include <vector>
#include <fstream>

using namespace std;

int getLCS(string x, string y) {
    vector<vector<int>> len;
    len.resize(x.size() + 1);
    for (int i = 0; i <= x.length(); i++) {
        len[i].resize(y.size() + 1);
    }
    for (int i = x.length() - 1; i >= 0; i--) {
        for (int j = y.length() - 1; j >= 0; j--) {
            if (x[i] != y[j]) {
                len[i][j] = max(len[i + 1][j], len[i][j + 1]);
            }
            else {
                len[i][j] = 1 + len[i + 1][j + 1];
            }
        }
    }
    
    return len[0][0];
}

int main() {
    string x;
    string y;
    int res;

    ifstream fin;
    fin.open("input.txt");
    if (fin.is_open()) {
        getline(fin, x);
        getline(fin, y);
        fin.close();
    }
    
    res = getLCS(x, y);

    fstream fout;
    fout.open("output.txt", ios::out);
    fout << res;
    fout.close();

    return 0;
}