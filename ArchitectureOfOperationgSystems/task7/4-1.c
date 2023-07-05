#include <stdlib.h>
#include <stdio.h>
#include <unistd.h>
#include <fcntl.h>
#include <sys/types.h>
#include <sys/stat.h>


int main() {
    int fd;
    char file[] = "test.fifo";
    char res[14];
    size_t size;
    (void)umask(0);
    if ((fd = open(file, O_RDONLY)) < 0) {
        printf("невозможно открыть файл\n");
        return -1;
    }
    size = read(fd, res, 14);
    if (size < 0) {
        printf("невозможно прочитать файл\n");
        return -1;
    }
    printf("результат чтения - %s\n", res);
    if (close(fd) < 0) {
        printf("ребенок не может закрыть файл\n");
        return -1;
    }
    return 0;
}