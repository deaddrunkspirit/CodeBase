#include <iostream>
#include <string>
#include <vector>
#include <fstream>

using namespace std;

string getLCS(string x, string y) {
    vector<vector<int>> len = vector<vector<int>>(x.size() + 1);
    string lcs;
    for (int i = 0; i <= x.length(); i++) {
        len[i].resize(y.size() + 1);
    }
    for (int i = x.length() - 1; i >= 0; i--) {
        for (int j = y.length() - 1; j >= 0; j--) {
            if (x[i] != y[j]) {
                len[i][j] = max(len[i + 1][j], len[i][j + 1]);
            } else {
                len[i][j] = 1 + len[i + 1][j + 1];
            }
        }
    }
    for (int i = 0, j = 0; len[i][j] != 0 && x.length() > i && y.length() > j;) {
        if (x[i] == y[j]) {
            lcs.push_back(x[i]);
            i++;
            j++;
        } else {
            if (len[i][j] == len[i + 1][j]) i++;
            else j++;
        }
    }

    return lcs;
}

int main() {
    string x;
    string y;
    string res;

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