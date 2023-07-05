#include <iostream>
#include <fstream>
#include <utility>
#include <vector>
#include <string>

/**
 * Path to folder to store binary files
 */
std::string dataFolder;

/**
 * This global variable used to name binary files
 */
unsigned long long fileNum;

std::vector<std::string> split(const std::string& str, const std::string& delimiter);

std::vector<std::string> readData(const std::string& inputPath);

class Node {
private:
    int cntKeys;
    std::vector<std::string> children;
    std::vector<int> keys;
    std::vector<int> values;
    bool isLeaf;
    std::string fileName;

    /**
     * This private constructor used to get a node from a string
     * @param node parameters such as
     * count of keys in node [0]
     * keys                  [1]
     * values                [2]
     * path to binary file   [3]
     * paths to children     [4]
     */
    explicit Node(std::vector<std::string> params) {
        cntKeys = stoi(params[0]);
        fileName = params[3];
        children = split(params[4], "!");
        if (children[0].empty()) children = std::vector<std::string>();
        isLeaf = children.empty();
        std::vector<std::string> keysStr = split(params[1], "!");
        std::vector<std::string> valuesStr = split(params[2], "!");
        keys = std::vector<int>();
        values = std::vector<int>();
        for (int i = 0; i < keysStr.size(); ++i) {
            keys.push_back(stoi(keysStr[i]));
            values.push_back(stoi(valuesStr[i]));
        }
    }

public:
    /**
     * This constructor used to create an empty node
     */
    Node() {
        cntKeys = 0;
        isLeaf = true;
        keys = std::vector<int>(0);
        values = std::vector<int>(0);
        children = std::vector<std::string>(0);
        fileName = dataFolder + "/" + std::to_string(fileNum) + ".bin";
        fileNum++;
    }

    /**
     * This static method reads a binary file and converts its data to Node
     * @param path to binary file
     * @return parsed Node
     */
    static Node read(const std::string& filePath) {
        std::ifstream reader;
        reader.open(filePath);
        size_t n = 0;
        std::string str;
        reader.read((char*)&n, sizeof(n));
        str.resize(n);
        reader.read(&str[0], n);
        reader.close();
        return Node(split(str, "|"));
    }

    /**
     * This method writes Node to binary file
     */
    void write() {
        std::ofstream writer;
        std::string data = nodeToString();
        writer.open(fileName, std::ios::binary);
        size_t n = data.size();
        writer.write((const char*)&n, sizeof(n));
        writer.write(data.c_str(), n);
        writer.close();
    }

    /**
     * This method converts all information about Node to string
     * So we can restore this Node later from secondary memory
     * @return string Node information in special format
     * [count of keys]|[key]!...![key]|[value]!...![value]|[path to binary file]|[path to child]!...![path to child]
     */
    std::string nodeToString() {
        std::string res;
        res += std::to_string(cntKeys) + "|";
        res += vectorIntToString(keys) + "|";
        res += vectorIntToString(values) + "|";
        res += fileName;
        res += vectorStringToString(children) + "|";
        return res;
    }

    /**
     * This method converts vector of Integers to string
     * @param list of integers
     * @return list of integers in one string  with delimiter [!]
     */
    static std::string vectorIntToString(std::vector<int> vec) {
        std::string res;
        if (vec.empty()) return nullptr;
        for (int i = 0; i < vec.size() - 1; ++i) {
            res += std::to_string(vec[i]) + "!";
        }
        res += std::to_string(vec[vec.size() - 1]);
        return  res;
    }

    /**
     * This method converts a vector of strings to one string
     * @param list of strings
     * @return list of strings in one string with delimiter [!]
     */
    static std::string vectorStringToString(std::vector<std::string> vec) {
        std::string res;
        if (vec.empty()) return "";
        for (int i = 0; i < vec.size() - 1; ++i) {
            res += vec[i] + "!";
        }
        res += vec[vec.size() - 1];
        return  res;
    }

    /**
     * This method returns whether the Node is a leaf or not
     * A node is a leaf if it has no children
     * @return
     */
    bool getIsLeaf() {
        return children.empty();
    }

    void setIsLeaf(bool status) {
        isLeaf = status;
    }

    std::string getFileName() {
        return fileName;
    }

    std::vector<int>& getKeys() {
        return keys;
    }

    int getKey(int i) {
        return keys[i];
    }

    void setKey(int i, int val) {
        if (i >= keys.size()) {
            keys.push_back(val);
        }
        else keys[i] = val;
        cntKeys = keys.size();
    }

    std::vector<std::string>& getChildren() {
        return children;
    }

    void setChild(int i, const std::string& value) {
        if (children.size() <= i) children.push_back(value);
        else children[i] = value;
    }

    std::string getChild(int i) {
        return children[i];
    }

    std::vector<int>& getValues() {
        return values;
    }

    void setValue(int i, int value) {
        if (i >= values.size()) {
            values.push_back(value);
        }
        else values[i] = value;
    }

    int getValue(int i) {
        return values[i];
    }

    int getCntKeys() const {
        return cntKeys;
    }

    void setCntKeys(int n) {
        cntKeys = n;
        keys.resize(n);
        values.resize(n);
        if (!isLeaf) children.resize(n + 1);
    }
};

class BTree {
    int t;
    int min_elements;
    int max_elements;
    Node root;
    BTree(Node root, int t) {
        this->t = t;
        min_elements = t - 1;
        max_elements = 2 * t - 1;
        this->root = std::move(root);

    }
public:
    explicit BTree(int t) {
        this->t = t;
        min_elements = t - 1;
        max_elements = 2 * t - 1;
        root = Node();
    }

    /**
     * This method inserts a value and a key in a B tree
     * @param key to insert
     * @param value to insert
     * @return true if insert successful and false if key is already used
     */
    bool insert(const int& key, const int& val) {
        if (find(key) != INT32_MIN) return false;
        Node r = root;
        if (root.getCntKeys() == max_elements) {
            root = Node();
            root.setIsLeaf(false);
            root.setChild(0, r.getFileName());
            splitChild(r, 0);
            insertNotFull(root, key, val);
        }
        else {
            insertNotFull(root, key, val);
        }
        return true;
    }

    /**
     *
     * @param x
     * @param k
     * @param val
     */
    void insertNotFull(Node &x, const int& k, const int& val) {
        int i = x.getCntKeys();
        if (x.getIsLeaf()) {
            while (i >= 1 && k < x.getKey(i - 1)) {
                x.setKey(i, x.getKey(i - 1));
                x.setValue(i, x.getValue(i - 1));
                i--;
            }
            x.setKey(i, k);
            x.setValue(i, val);
            x.write();
        }
        else {
            Node child;
            while (!child.getIsLeaf()) {
                while (i >= 1 && k < x.getKey(i - 1)) {
                    i--;
                }
                child = Node::read(x.getChild(i));
            }
            if (child.getCntKeys() == max_elements) {
                splitChild(child, i);
                if (k > x.getKey(i)) {
                    i++;
                }
            }
            child = Node::read(x.getChild(i));
            insertNotFull(child, k, val);
        }
    }

    /**
     *
     * @param child
     * @param i
     */
    void splitChild(Node &child, const int& i) {
        Node z = Node();
        z.setIsLeaf(child.getIsLeaf());
        z.setCntKeys(min_elements);
        for (int j = 0; j < min_elements; ++j) {
            z.setKey(j, child.getKey(j + min_elements));
            z.setValue(j, child.getValue(j + min_elements));
        }
        if (!child.getIsLeaf()) {
            for (int j = 0; j < t; ++j) {
                z.setChild(j, child.getChild(j + t));
            }
        }

        root.getChildren().insert(root.getChildren().cbegin() + i + 1, z.getFileName());
        root.getKeys().insert(root.getKeys().cbegin() + i, child.getKey(min_elements));
        root.getValues().insert(root.getValues().cbegin() + i, child.getValue(min_elements));
        root.setCntKeys(root.getCntKeys() + 1);
        child.setCntKeys(min_elements);
        child.write();
        z.write();
        root.write();
    }

    /**
     * This method finds and returns element on specified place
     * @param key to find for value
     * @return value in BTree or min element of Int32 if nothing was found
     */
    int find(const int& key) {
        int i = 0;
        while (i < root.getCntKeys() && key > root.getKey(i)) i++;
        if (i < root.getCntKeys() && key == root.getKey(i)) return root.getValue(i);
        if (root.getIsLeaf()) return INT32_MIN;
        else {
            Node child = Node::read(root.getChild(i));
            BTree newTree = BTree(child, t);
            return newTree.find(key);
        }
    }
};

int main(int argc, char** argv) {
    int t = std::stoi(argv[1]);
    dataFolder = argv[2];
    std::string inputPath = argv[3];
    std::string outputPath = argv[4];
    BTree tree = BTree(t);
    /// BTree created and arguments set
    std::vector<std::string> commands = readData(inputPath);
    std::ofstream writer;
    std::string res;
    /// Now we have a list of commands to go through
    for (auto & i : commands) {
        std::vector<std::string> command = split(i, " ");
        /// parsed command
        if (command[0] == "insert") {
            res += tree.insert(stoi(command[1]), stoi(command[2])) ? "true" : "false";
            res += "\n";
        }
        else if (command[0] == "find") {
            int ans = tree.find(stoi(command[1]));
            if (ans == INT32_MIN) res += "null\n";
            else res += std::to_string(tree.find(stoi(command[1]))) + "\n";
        }
        else res += "unknown command(";
    }
    writer.open(outputPath);
    writer << res;
    writer.close();
}

/**
 * This method splits string with specified delimeter to get vector of strings
 * @param string to split
 * @param delimiter
 * @return vector of strings
 */
std::vector<std::string> split(const std::string& str, const std::string& delimiter){
    size_t pos_start = 0, pos_end, delim_len = delimiter.length();
    std::string token;
    std::vector<std::string> res;

    while ((pos_end = str.find (delimiter, pos_start)) != std::string::npos) {
        token = str.substr (pos_start, pos_end - pos_start);
        pos_start = pos_end + delim_len;
        res.push_back (token);
    }

    res.push_back (str.substr (pos_start));
    return res;
}

/**
 * This method reads data from a text file and returns vector of lines of text file
 * @param path to file to read data
 * @return list of lines from text file
 */
std::vector<std::string> readData(const std::string& inputPath) {
    std::ifstream reader;
    reader.open(inputPath);
    std::vector<std::string> commands;
    std::string command;
    while (!reader.eof()) {
        getline(reader, command);
        commands.push_back(command);
    }
    reader.close();
    return commands;
}
