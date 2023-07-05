#include "ReadWriter.h"
//vector, string, iostream included in "ReadWriter.h"

using namespace std;

//Можно добавлять любые вспомогательные методы и классы для решения задачи.

bool compare(pair<int, int> x, pair<int, int> y){
    double a = (double) x.second / x.first, b = (double) y.second / y.first;

    return a == b ? x.first > y.first : a > b;
}

vector<pair<int, int>> arrayToVector(pair<int, int>* items, int size) {
    vector<pair<int, int>> sorted_items;
    sorted_items.reserve(size);
    for (int i = 0; i < size; ++i) {
        sorted_items.push_back(items[i]);
    }
    sort(sorted_items.begin(), sorted_items.end(), compare);
    return sorted_items;
}

//Задача реализовать этот метод
//param N - количество предметов
//param W - ограничения на вес рюкзака
//param items - массив размера N, с предметами - first = вес, second = стоимость
//param res - вектор результатов (предметы, которые надо взять)
void solve(int N, int W, pair<int, int>* items, vector<pair<int, int>>& res) {
    int current = 0, i;
    vector<pair<int, int>> sorted_items = arrayToVector(items, N);
    for (i = 0; i < N; i++) {
        if ((current + sorted_items[i].first) <= W) {
            res.push_back(sorted_items[i]);
            current += sorted_items[i].first;
        }
    }
}

int main() {
    ReadWriter rw;
    int N = rw.readInt(); //количество предметов
    int W = rw.readInt(); //ограничения на вес рюкзака

    //структура массив pair выбрана, так как известно количество и у объекта всего 2 характеристики
    //first = вес(weight), second = стоимость (cost)
    //Можно переложить данные в любую другую удобную струтуру
    //Внимание(!) данные не упорядочены, но можно это сделать если вам требуется
    pair<int, int>* arr = new pair<int, int>[N];
    rw.readArr(arr, N);

    //структура вектор pair выбрана, так как неизвестно количество элементов, и у объекта всего 2 характеристики
    //результат, также first = вес(weight), second = стоимость (cost)
    vector<pair<int, int>> res;
    solve(N, W, arr, res);

    int sumCost = 0, sumWeight = 0;
    for (int i = 0; i < res.size(); i++) {
        sumWeight += res[i].first;
        sumCost += res[i].second;
    }
    //записываем ответ в файл
    rw.writeInt(sumCost);
    rw.writeInt(sumWeight);
    rw.writeInt(res.size());
    rw.writeVector(res);

    delete[] arr;
    return 0;
}