#include <iostream>
#include <fstream>
#include <string>
#include <vector>

using namespace std;


vector<int> getBorders(string str) {
    int n = str.length();
    vector<int> res = vector<int>(n, 0);
    for (int i = 1; i < n; i++) {
        int j = res[i - 1];
        while ((j > 0) && (str[i] != str[j])) j = res[j - 1];
        if (str[i] == str[j]) res[i] = j + 1;
        else res[i] = 0;
    }
    return res;
}

void kmp(string& source, string& substring, vector<int>& res) {
    res = vector<int>(0);
    vector<int> borders = getBorders(substring);
    int j = 0;
    for (int i = 0; i < source.length(); ++i) {
        while (j == substring.length() || (j > 0 && substring[j] != source[i])) {
            j = borders[j - 1];
            if (source.length() - i < substring.length() - j) break;
        }
        if (substring[j] == source[i]) j++;
        if (j == substring.length()) res.push_back(i - j + 1);
    }
}

int main() {
    string t;
    string p;
    vector<int> res;

    ifstream fin;
    fin.open("input.txt");
    if (fin.is_open()) {
        getline(fin, t);
        getline(fin, p);
        fin.close();
    }

    kmp(t, p, res);

    fstream fout;
    fout.open("output.txt", ios::out);
    fout << res.size() << "\n";
    for (std::vector<int>::const_iterator i = res.begin(); i != res.end(); ++i)
        fout << *i << "\n";
    fout.close();

    return 0;
}
