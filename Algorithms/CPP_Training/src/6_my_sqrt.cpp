#include <gtest/gtest.h>
#include <cmath>

using namespace std;

/* (**) Написать реализацию функции вычисления корня из числа без использования встроенной функции корня
 *      с точностью до 6 знаков после запятой */
double mySqrt(double);

#pragma region mySqrt tests

const static double ABS_ERROR = 1e-6;

TEST(mySqrt, case1) {
    const auto x = 2;
    EXPECT_NEAR(sqrt(x), mySqrt(x), ABS_ERROR);
}

TEST(mySqrt, case2) {
    const auto x = 9;
    EXPECT_NEAR(sqrt(x), mySqrt(x), ABS_ERROR);
}

TEST(mySqrt, case3) {
    const auto x = 100;
    EXPECT_NEAR(sqrt(x), mySqrt(x), ABS_ERROR);
}

TEST(mySqrt, case4) {
    const auto x = 12345678;
    EXPECT_NEAR(sqrt(x), mySqrt(x), ABS_ERROR);
}

TEST(mySqrt, case5) {
    const auto x = 1000000007;
    EXPECT_NEAR(sqrt(x), mySqrt(x), ABS_ERROR);
}

#pragma endregion

// todo
double mySqrt(double number) {
    double high = number,
    mid = 0,
    low = 0;
    while (high - low > ABS_ERROR)
    {
        mid = low + (high - low) / 2;
        if (mid * mid > number)
            high = mid;
        else
            low = mid;
    }
    return mid;
}