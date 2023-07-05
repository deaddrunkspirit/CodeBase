#include <memory>
#include <string>
#include <iostream>
#include <fstream>
#include <cmath>
#include <vector>
#include <map>

using namespace std;

class CuckooFilter{
    unsigned int *buckets;
    int bucketsCount;
    const double fpr = 0.06;
    const int b = 4;
    const int f_size = 7;
    const double a = 0.95;

public: explicit CuckooFilter(int n){
        double m = n * (fpr + 1);
        bucketsCount = twoPow(m);
        buckets = new unsigned int[bucketsCount];
        for (int i = 0; i < bucketsCount; ++i)
            buckets[i] = 0;
    }

    void Insert(const string& x){
        unsigned int f = fingerprint(x) % 127 + 1;
        unsigned int i1 = std::hash<string>{}(x) % bucketsCount;
        unsigned int i2 = i1 ^ (std::hash<int>{}(f) % bucketsCount);
        if (bucketContains(f, buckets[i1]) || bucketContains(f, buckets[i2])) return;
        if (hasEmptyEntry(buckets[i1]) != -1){
            buckets[i1] = pushBucket(f, buckets[i1], hasEmptyEntry(buckets[i1]));
            return;
        }
        else if (hasEmptyEntry(buckets[i2]) != -1) {
            buckets[i2] = pushBucket(f, buckets[i2], hasEmptyEntry(buckets[i2]));
            return;
        }

        for (int j = 0; j < 500; ++j) {
            f = swapFingerprint(f, buckets[i1]);
            i1 = int((size_t)i1 ^ (std::hash<int>{}(f) % bucketsCount));
            if (hasEmptyEntry(buckets[i1]) != -1){
                buckets[i1] = pushBucket(f, buckets[i1], hasEmptyEntry(buckets[i1]));
                return;
            }
        }
        throw "Hashtable is full";
    }

    bool Lookup(const string& x){
        unsigned int f = fingerprint(x) % 127 + 1;
        unsigned int i1 = std::hash<string>{}(x) % bucketsCount;
        unsigned int i2 = i1 ^ (std::hash<int>{}(f) % bucketsCount);
        if (bucketContains(f, buckets[i1]) || bucketContains(f, buckets[i2]))
            return true;
        return false;
    }
private:
    unsigned int swapFingerprint(int f, unsigned int &bucket){
        unsigned int bucketVal = bucket % 128;
        bucket -= bucketVal;
        bucket = pushBucket(f, bucket, 0);
        return bucketVal;
    }

    static int twoPow(double m){
        int n, i = 0;
        while(true){
            n = pow(2, i);
            if (n > m) return n;
            i++;
        }
    }
    static unsigned long long fingerprint(const string& x){
        const int p = 129;
        unsigned long long hash = 0, p_pow = 1;
        for (char i : x) {
            hash += (i - 'a' + 1) * p_pow;
            p_pow *= p;
        }
        return hash;
    }

    unsigned int pushBucket(unsigned int f, unsigned int bucket, unsigned int i){
        i *= f_size;
        for (int j = 0; j < f_size; ++j) {
            bucket += f % 2 * (int)pow(2, j + i);
            f /= 2;
        }
        return bucket;
    }

    bool bucketContains(unsigned int f, unsigned int bucket){
        for (int j = 0; j < b; ++j) {
            auto num = (unsigned int)((bucket % (unsigned int)pow(128, j + 1)) / pow(128, j));
            if (num == f)
                return true;
        }
        return false;
    }

    unsigned int hasEmptyEntry(unsigned int bucket) {
        for (int j = 0; j < b; ++j)
            if ((bucket % (unsigned int)pow(128, j + 1) / pow(128, j) == 0))
                return j;
        return -1;
    }
};

vector<string> split(string str, string delimiter){
    size_t pos = 0;
    string token;
    vector<string> result;
    while ((pos = str.find(delimiter)) != string::npos)
    {
        token = str.substr(0, pos);
        result.push_back(token);
        str.erase(0, pos + delimiter.length());
    }
    result.push_back(str);
    return result;
}

int main(int argc, char *argv[]) {
    try {
        string inputPath = argv[1];
        string outputPath = argv[2];
        ofstream out;
        ifstream in;
        string res;
        vector<string> commands = vector<string>();
        in.open(inputPath);
        string command;
        while (!in.eof()) {
            getline(in, command);
            commands.push_back(command);
        }
        in.close();
        res += "Ok\n";
        int n = stoi(split(commands[0], " ")[1]); // количество видео
        map<string, unique_ptr<CuckooFilter>> users = map<string, unique_ptr<CuckooFilter>>();
        for (int i = 1; i < commands.size(); ++i) {
            vector<string> args = split(commands[i], " ");
            if (users.find(args[1]) == users.end()) {
                users.insert(pair<string, unique_ptr<CuckooFilter>>(args[1], new CuckooFilter(n)));
            }
            if (args[0] == "watch") {
                users[args[1]]->Insert(args[2]);
                res += "Ok\n";
            } else if (args[0] == "check") {
                string response = users[args[1]]->Lookup(args[2]) ? "Probably" : "No";
                res += response + "\n";
            } else throw "Invalid command!";
        }
        out.open(outputPath);
        out << res;
        out.close();
    }
    catch (char *e){
        cout << e;
    }
}