#include <stdlib.h>
#include <stdio.h>
#include <unistd.h>
#include <fcntl.h>
#include <signal.h>
#include <sys/types.h>


int size = 0;

int main() {
    int fd[2];
    if (pipe(fd) < 0) {
        printf("can not create pipe\n");
        return -1;
    }
    fcntl(fd[1], F_SETFL, fcntl(fd[1], F_GETFL) | O_NONBLOCK);
    while (write(fd[1], "1", 1) == 1) size += 1;
    printf("размер пайпа - %d килобайт\n", size / 1024);
    return 0;
}
