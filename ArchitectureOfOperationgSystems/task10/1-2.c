#include <signal.h>
#include <stdio.h>

void handler(int nsig) {
    switch (nsig) {
        case SIGINT:
            printf("Signal %d (Ctrl+C pressed) was received and handled\n", nsig);
            return;
        case SIGQUIT:
            printf("Signal %d (Ctrl+4 pressed) was received and handled\n", nsig);
            return;
        default:
            printf("Unknown signal %d was received\n", nsig);
    }
}

int main() {
    signal(SIGINT, handler);
    signal(SIGQUIT, handler);
    while (1);
}