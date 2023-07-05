#include <iostream>
#include <vector>
#include <string>
#include <fstream>
#include <thread>
#include <algorithm>


using namespace std;

int m, n, k, taskCount = 0;
int threadCount;

/**
 * Variable to set book ids
 * Increments after every book counted;
 */
int bookId = 100001;

vector<string> catalog;

vector<string> getArguments(ifstream &in);

/**
 * A task method that fills catalog
 */
void task() {
    int row_num;
    // write info about where current task is running
#pragma omp critical
    {
        row_num = taskCount++;
        cout << "task: " << row_num + 1 << " thread: " << this_thread::get_id() << endl;
    }
    while (row_num < m) {
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < k; j++) {
                string line = "Book ID: " + to_string(bookId++) +
                              +"\n\trow: " + to_string(row_num + 1)
                              + "\n\tbook case: " + to_string(i + 1);
                // pushing info about book to catalog
#pragma omp critical
                {
                    catalog.push_back(line);
                }
            }
        }
#pragma omp critical
        {
            row_num = taskCount++;
            cout << "task: " << row_num + 1 << " thread: " << this_thread::get_id() << endl;
        }
    }
}

/**
 * This method reads a text file and returns a vector of m, n, k string values
 */
vector<string> getArguments(ifstream &in) {
    vector<string> args;
    string arg;
    while (!in.eof()){
        getline(in, arg);
        args.push_back(arg);
    }
    return args;
}

int main(int argc, char** argv) {
    // Check if there are invalid arguments in command prompt
    if (argc != 4) {
        cout << "Command prompt arguments are class path, input file path, "
                "output file path and count of threads\nThree and only four arguments allowed";
        return -1;
    }
    ifstream in;
    ofstream out;
    in.open(argv[1]);
    // Здесь была ошибка
    threadCount = stoi(argv[3]);
    vector<string> args = getArguments(in);
    in.close();
    m = stoi(args[0]);
    n = stoi(args[1]);
    k = stoi(args[2]);
    if (args.size() != 3) {
        cout << "Invalid number of arguments in test file";
        return -1;
    }
    if (m <= 0) {
        cout << "M can't be equals 0 or negative";
        return -1;
    }
    else if (n <= 0) {
        cout << "N can't be equals 0 or negative";
        return -1;
    }
    else if (k <= 0) {
        cout << "K can't be equals 0 or negative";
        return -1;
    }
    catalog.reserve(m * n * k);
    out.open(argv[2]);
    // run in 4 parallel threads all rows and write Book info to output file
#pragma omp parallel for num_threads(threadCount)
    for (int i = 0; i < threadCount; ++i) task();
    sort(catalog.begin(), catalog.end());
    out << "Books count: " << size(catalog) << endl;
    for (auto const &line: catalog) {
        out << line << endl;
    }
}

