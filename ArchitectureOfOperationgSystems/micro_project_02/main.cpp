#include <string>
#include <iostream>
#include <mutex>

using namespace std;

mutex mtx;
static bool flowerBeds[40];
const int gardenerSleepTime = 500;
const int gardenManagerSleepTime = 1000;

void changeFlowerBeds(int count);

void water(int i, int thread);

void findUnfilledFlowerBed(int unfilledFlowerBeds, int thread);

int main(int argc, char** argv) {
    if (argc != 2) {
        cout << "Invalid number of arguments given";
        return -1;
    }
    int actions = stoi(argv[1]);
    if (actions <= 0) {
        cout << "Invalid number of actions";
        return -1;
    }
    // This thread changes some flower beds status to unfilled
    thread gardenManager(changeFlowerBeds, actions * 2);
    // Threads which checks flowed beds and water flowers if flower bed is unfilled
    thread firstGardener(findUnfilledFlowerBed, actions, 1);
    thread secondGardener(findUnfilledFlowerBed, actions, 2);
    gardenManager.join();
    firstGardener.join();
    secondGardener.join();
    return 0;
}

/// This function change status of specific count of flower beds to unfilled.
/// Works in parallel with gardeners
/// \param count - count of flower beds to change
void changeFlowerBeds(int count) {
    for (int j = 0; j < count; ++j) {
        this_thread::sleep_for(chrono::milliseconds(gardenManagerSleepTime));
        int i = rand() % 40;
        flowerBeds[i] = false;
        cout << to_string(i) + " flower bed is not watered\n";
    }
}

/// This function distributes tasks among gardeners
/// \param unfilledFlowerBeds - the amount of flower beds which are not filled
/// \param thread - thread id
void findUnfilledFlowerBed(int unfilledFlowerBeds, int thread) {
    for (int j = 0; j < unfilledFlowerBeds; j++ ) {
        this_thread::sleep_for(chrono::milliseconds(gardenerSleepTime));
        mtx.lock();
        for (int i = 0; i < 40; ++i) {
            if (!flowerBeds[i]) {
                water(i, thread);
                break;
            }
            if (i == 39) {
                cout << "All flower beds are filled\n";
            }
        }
        mtx.unlock();
    }
}

/// This function water specific flower bed
/// \param i - index of flower bed to water
/// \param thread - thread id
void water(int i, int thread) {
    if (flowerBeds[i]) return;
    this_thread::sleep_for(chrono::milliseconds(gardenerSleepTime));
    flowerBeds[i] = true;
    cout << to_string(i + 1) + " was watered by " + to_string(thread) + " gardener\n";
}
