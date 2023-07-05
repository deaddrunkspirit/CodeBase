#include <iostream>
#include <vector>

using namespace std;

int main() {
    int n, a, b, c, res, i;
    cin >> n;
    cin >> a >> b >> c;
    vector<int> arr(n, 0);
    arr[0] = 1;
    for (i = 0; i < n; ++i) {
        if (arr[i] == 1) {
            if (a + i < n) {
                arr[a + i] = 1;
            } if (b + i < n) {
                arr[b + i] = 1;
            } if (c + i < n) {
                arr[c + i] = 1;
            }
        }
    }
    for (i = 0, res = 0; i < n; ++i) {
        if (arr[i] == 1) {
            res++;
        }
    }
    cout << res;
    
    return 0;
}
