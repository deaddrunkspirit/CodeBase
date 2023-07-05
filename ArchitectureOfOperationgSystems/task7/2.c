#include <stdlib.h>
#include <stdio.h>
#include <unistd.h>
#include <fcntl.h>
#include <string.h>


char* s = "привет";
char buf[128] = { 0 };

int main() {
    size_t size;
    int pi1[2];
    int pi2[2];
    if (pipe(pi1) || pipe(pi2)) {
        printf("Пайп закончен\n");
        return -1;
    }
    int result = fork();
    if (result < 0) {
        printf("Форк отменен\n");
        return -1;
    }
    else if (result > 0) {
        printf("Родитель\n");
        if (close(pi1[0]) || close(pi2[1])) {
            printf("\tневозможно закрыть пайпы\n");
            return -1;
        }
        size_t l = strlen(s) + 1;
        if (write(pi1[1], s, l) != l) {
            printf("\tчто-то пошло не так при записи\n");
            return -1;
        }
        printf("\tписьмо не отправленно\n");
        if (read(pi2[0], buf, 128) < 0) {
            printf("\tу нас проблемы\n");
            return -1;
        }
        if (strcmp(s, buf)) {
            printf("\tнеожиданное сообщение - '%s'\n", buf);
        }
        else {
            printf("\tполучено сообщение - '%s'\n", buf);
        }
        printf("родитель завершил работу\n");
    }
    else {
        printf("Ребенок\n");
        if (close(pi1[1]) || close(pi2[0])) {
             printf("невозможно закрыть пайпы\n");
             return -1;
        }
        size_t len = strlen(s) + 1;
        if (write(pi2[1], s, len) != len) {
             printf("\tчто-то пошло не так при записи\n");
             return -1;
        }
        printf("\tписьмо не отправленно\n");
        if (read(pi1[0], buf, 128) < 0) {
              printf("\tу нас проблемы");
              return -1;
        }
        if (strcmp(s, buf)) {
              printf("\tнеожиданное сообщение - '%s'\n", buf); 
        }
        else {
              printf("\tполучено сообщение - '%s'\n", buf);
        }
        printf("ребенок завершил работу\n");
    }
    return 0;
}