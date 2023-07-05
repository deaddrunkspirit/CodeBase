#include <stdlib.h>
#include <stdio.h>
#include <unistd.h>
#include <sys/stat.h>


int main() {
    int fd;
    size_t size = 1;
    if ((fd = open("myfile.txt", O_RDONLY)) < 0) {
         printf("something wrong with file\n");
         return -1;
    }
    char buffer[550];
    while (size) {
        size = read(fd, buffer, 550);
        if (size < 0) {
              printf("Ошибка чтения файла\n");
              return -1;
        }
        if (write(1, buffer, size) != size) {
               printf("Ошибка записи в файл\n");
               return -1;
        }
    }
    if (close(fd) < 0) {
          printf("Невозможно закрыть файл\n");
          return -1;
    }

    return 0;
}