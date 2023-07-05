#include <iostream>
#include <vector>
#include <string>
#include <fstream>
#include <thread>
#include <mutex>

using namespace std;

int m, n, k, taskCount = 0;

vector<string> catalog;

string getRow(int row);

vector<string> getArguments(ifstream &in);

/**
 * A task method that fills catalog
 */
void task() {
    mutex mut;

    mut.lock();
    int row = taskCount++;
    mut.unlock();

    while (taskCount - 1 < m) {
        // calculate row
        string val = getRow(row);
        // we add a row to the catalog
        catalog.insert(catalog.begin() + row, val);

        // increase row count
        mut.lock();
        row = taskCount++;
        mut.unlock();
    }
}

/**
 * This method gets a row in string format
 */
string getRow(int row) {
    string str = "row: " + to_string(row + 1) + "\n";
    for (int i = 1; i <= n; i++) {
        str += "\tshelf: " + to_string(i) + "\n";
        for (int j = 1; j <= k; j++) {
            str += "\t\tbook: " + to_string(j) + "\n";
        }
    }
    return str;
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
    if (argc != 3) {
        cout << "Command prompt arguments are class path, input file path "
                "and output file path\nThree and only three arguments allowed";
        return -1;
    }
    ifstream in;
    ofstream out;
    in.open(argv[1]);
    vector<string> args = getArguments(in);
    in.close();
    m = stoi(args[0]);
    n = stoi(args[1]);
    k = stoi(args[2]);
    catalog.resize(m);
    thread firstThread(task);
    thread secondThread(task);
    firstThread.join();
    secondThread.join();
    out.open(argv[2]);
    for (int i = 0; i < m; ++i) {
        string outVal = catalog.at(i);
        cout << outVal + "\n";
        out << outVal + "\n";
    }
    out.close();
    return 0;
}
