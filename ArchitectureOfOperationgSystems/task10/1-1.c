#include <signal.h>

int main() {
    signal(SIGINT, SIG_IGN);
    signal(SIGQUIT, SIG_IGN);
    while (1);
}