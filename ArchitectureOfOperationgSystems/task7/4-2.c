#include <stdlib.h>
#include <stdio.h>
#include <unistd.h>
#include <fcntl.h>
#include <sys/types.h>
#include <sys/stat.h>


int main() {
    int fd;
    char file[] = "test.fifo";
    size_t size;
    (void)umask(0);
    if (mknod(file, S_IFIFO | 0666, 0) < 0) {
        printf("невозможно создать файл\n");
        return -1;
    }
    if ((fd = open(file, O_WRONLY)) < 0) {
        printf("невозможно открыть файл\n");
        return -1;
    }
    size = write(fd, "Hello, world!", 14);
    if (size != 14) {
        printf("невозможно записать в файл\n");
        return -1;
    }
    if (close(fd) < 0) {
        printf("родитель не может закрыть файл\n");
        return -1;
    }
    return 0;
}