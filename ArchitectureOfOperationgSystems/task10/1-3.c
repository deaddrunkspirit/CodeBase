#include <stdlib.h>
#include <stdio.h>
#include <unistd.h>
#include <signal.h>
#include <wait.h>
#include <sys/types.h>
#include <errno.h>

void handler(int nsig) {
    int status;
    pid_t pid;
    while((pid = waitpid(-1, &status, 0)) > 0) {
        if ((status & 0xff) == 0) {
            printf("Process %d exited, status - %d\n", pid, status >> 8);
        } else if ((status & 0xff00) == 0) {
            printf("Process %d killed, status %d, %s\n", pid, status &0x7f, (status & 0x80) ? "core file" : "not core file");
        }
    }
}

int main(void) {
    int i, j;
    pid_t pid;
    (void) signal(SIGCHLD, handler);
    for (i = 0; i < 10; i++) {
        if ((pid = fork()) < 0) {
            printf("Can't fork child\n");
            exit(1);
        } else if (pid == 0) {
            for (j = 1; j < 10000000; j++);
            exit(200 + i);
        }
    }
    while (1);
    return 0;
}