#include <iostream>
#include <vector>
#include <sstream>
#include <cstdlib>
#include <fstream>

using namespace std;

template<typename T> std::string to_string(const T &t){
    std::stringstream ss;
    ss << t;
    return ss.str();
}

struct Point {
private:
    int x, y;
public :
    Point(int x, int y) {
        this->x = x;
        this->y = y;
    }
    Point() = default;

    int getX() { return x; }

    int getY() { return y; }

    string pointToString() { return to_string(x) + " " + to_string(y); }
};

Point point0;

class stack {
private:
    vector<Point> data;
public:
    const int MAX_STACK_SIZE = 1000;
    int maxSize{};
    stack(int maxSize){
        this->maxSize = maxSize;
    }
    void pop();
    void push(Point pt);
    int size();
    Point top();
    Point nextToTop();
    bool isEmpty();
    void wkt(vector<Point> points, int n, string path, string order);
    void plain(string path, string order);


};

void stack::push(Point pt) {
    if (size() == maxSize)
        throw "Stack is full . . .";
    data.push_back(pt);
}

void stack::pop() {
    if (isEmpty())
        throw "Stack is empty . . .";
    data.pop_back();
}

int stack::size() {
    return data.size();
}

Point stack::top() {
    if (isEmpty())
        throw "Stack is empty . . .";
    return data[size() - 1];
}

Point stack::nextToTop() {
    if (isEmpty())
        throw "Stack is empty . . .";
    return data[size() - 2];
}

bool stack::isEmpty() {
    if (size() == 0)
        return true;
    return false;
}

void reversePoints(vector<Point> points, string order){
    if (order == "cc")
        return;
    Point data;
    for (int i = 1; i < points.size(); ++i) {
        data = points[i];
        points[i] = points[points.size() - i];
        points[points.size() - i] = data;
    }
}

void stack::plain(string path, string order) {
    reversePoints(data, order);
    string res = to_string(size()) + "\n";
    for (int i = 0; i < size(); ++i) {
        res += data[i].pointToString() + "\n";
    }
    FILE *outputFile;
    outputFile = fopen(path.c_str(), "w");
    fprintf(outputFile, res.c_str());
    fclose(outputFile);
}

void stack::wkt(vector<Point> points, int n, string path, string order) {
    reversePoints(data, order);
    string res = "MULTIPOINT (";
    for (int i = 0; i < n - 2; ++i) {
        res += "(" + points[i].pointToString() + "), ";
    }
    res += "(" + points[n - 1].pointToString() + "))\n";
    res += "POLYGON ((";
    for (int i = 0; i < size() - 1; ++i) {
        res += data[i].pointToString() + ", ";
    }
    res += data[size()  - 1].pointToString() + "))";
    FILE *outputFile;
    outputFile = fopen(path.c_str(), "w");
    fprintf(outputFile, res.c_str());
    fclose(outputFile);
}

int orientation(Point p1, Point p2, Point p3){
    int value = (p3.getX() - p2.getX()) * (p2.getY() - p1.getY()) -
            (p3.getY() - p2.getY()) * (p2.getX() - p1.getX());
    return value == 0 ? 0 : value > 0 ? 1 : 2;
}

int dist(Point p1, Point p2){
    return (p1.getY() - p2.getY()) * (p1.getY() - p2.getY()) +
        (p1.getX() - p2.getX()) * (p1.getX() - p2.getX());
}

int compare(const void *p1, const void *p2){
    auto *point1 = (Point *)p1;
    auto *point2 = (Point *)p2;
    int orient = orientation(point0, *point1, *point2);
    return orient == 0 ? dist(point0, *point2) >= dist(point0, *point1) ? -1 : 1 : orient == 2 ? -1 : 1;
}

stack GrahamScan(vector<Point> points, int n){
    int yMin = points[0].getY(), min = 0, m = 1;
    for (int i = 0; i < n; ++i) {
        int y = points[i].getY();
        if ((yMin == y && points[i].getX() < points[min].getX()) || (y < yMin)){
            min = i;
            yMin = points[i].getY();
        }
    }
    Point swap = points[0];
    points[0] = points[min];
    points[min] = swap;
    point0 = points[0];
    qsort(&points[1], n - 1, sizeof(Point), compare);
    for (int i = 0; i < n; ++i) {
        while (i < n - 1 && orientation(point0, points[i], points[i + 1]) == 0)
            i++;
        points[m] = points[i];
        m++;
    }
    if (m < 3) throw "Impossible to find convex hull";
    auto s = stack(n);
    s.push(points[0]);
    s.push(points[1]);
    s.push(points[2]);
    for (int i = 3; i < m; ++i) {
        while (orientation(s.nextToTop(), s.top(), points[i]) != 2)
            s.pop();
        s.push(points[i]);
    }
    return s;
}


int main(int argc, char *argv[]) {
    string inputPath, outputPath, style, order;
    order = argv[1];
    style = argv[2];
    inputPath = argv[3];
    outputPath = argv[4];
    int n, x, y;
    ifstream inputFS;
    inputFS.open(inputPath);
    inputFS >> n;
    vector<Point> points;
    for (int i = 0; i < n; ++i) {
        inputFS >> x >> y;
        points.emplace_back(Point(x, y));
    }
    inputFS.close();
    vector<Point> data = points;
    stack res = GrahamScan(points, n);
    if (style == "plain")
        res.plain(outputPath, order);
    else if (style == "wkt")
        res.wkt(data, n, outputPath, order);
    else
        cout << "No format given";

    return 0;
}
