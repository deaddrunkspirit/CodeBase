#include <iostream>
#include <fstream>
#include <string>
#include <vector>

using namespace std;

vector<int> manacher(string s) {
    vector<int> res(s.length(), 0);
    for (int i = 0, l = 0, r = -1; i < res.size(); i++) {
        int j = 1;
        if (i <= r)
            j = min(res[l + r - i], r - i + 1);
        while(i + j < res.size() && i - j >= 0 && s[i + j] == s[i - j])
            j++;
        res[i] = j;
        if (i + j - 1 > r) {
            l = i - j + 1;
            r = i + j - 1;
        }
    }
    vector<int> result = vector<int>(s.length(), 0);
    for (int i = 0; i < s.length(); i++)
        result[i] = res[i] * 2 - 1;
    return result;
}

int main() {
    string str;
    vector<int> res;
    ifstream fin;
    fin.open("input.txt");
    if (fin.is_open()) {
        getline(fin, str);
        fin.close();
    }

    res = manacher(str);
    fstream fout;
    fout.open("output.txt", ios::out);
    for (std::vector<int>::const_iterator i = res.begin(); i != res.end(); ++i)
        fout << *i << " ";
    fout.close();

    return 0;
}
