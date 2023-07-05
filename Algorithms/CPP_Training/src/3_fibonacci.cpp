#include <gtest/gtest.h>

using namespace std;

// Написать реализацию функции получения N-го числа Фибоначчи
long long fibonacci(int);

#pragma region fibonacci tests

TEST(fibonacci, case1) {
    EXPECT_EQ(8, fibonacci(6));
}

TEST(fibonacci, case2) {
    EXPECT_EQ(1, fibonacci(2));
}

TEST(fibonacci, case3) {
    EXPECT_EQ(2, fibonacci(3));
}

TEST(fibonacci, case4) {
    EXPECT_EQ(55, fibonacci(10));
}

TEST(fibonacci, case5) {
    EXPECT_EQ(12586269025, fibonacci(50));
}

#pragma endregion

// todo
long long fibonacci(int count) {
    if (count == 1 || count == 2) return 1;
    long long first = 0, second = 1, last = 1;
    for (int i = 2; i < count; ++i) {
        first = second;
        second = last;
        last = first + second;
    }
    return last;
}