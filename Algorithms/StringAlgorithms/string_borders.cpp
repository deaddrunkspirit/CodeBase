#include <iostream>
#include <fstream>
#include <string>
#include <stdlib.h>
#include <vector>

using namespace std;


vector<int> prefix_function (string s) {
    vector<int> prefix(s.length(), 0);
    for (int i = 1; i < prefix.size(); ++i) {
        int j = prefix[i - 1];
        while (j > 0 && s[i] != s[j]) {
            j = prefix[j - 1];
        }
        if (s[i] == s[j]) {
            ++j;
        }
        prefix[i] = j;
    }
    return prefix;
}

void getBorders(string &s, string& res) {
    vector<int> prefix = prefix_function(s);
    vector<int> len = vector<int>();
    for (int i = prefix.size() - 1; i > 0; i = prefix[i - 1]) {
        if (prefix[i] > 0) {
            len.push_back(prefix[i]);
        }
    }
    for (int i = len.size() - 1; i >= 0; i--) {
        res += s.substr(0, len[i]) + "\n";
    }
}

int main() {
    string input;
    string res;

    ifstream fin;
    fin.open("input.txt");
    if (fin.is_open()) {
        getline(fin, input);
        fin.close();
    }

    getBorders(input, res);

    fstream fout;
    fout.open("output.txt", ios::out);
    fout << res;
    fout.close();

    return 0;
}
