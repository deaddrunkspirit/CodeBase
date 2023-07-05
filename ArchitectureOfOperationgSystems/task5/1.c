#include <unistd.h>
#include <stdio.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/ipc.h>
#include <sys/sem.h>

/* В начале семафор с = 0
    1. родитель запускает ребенка, выполняется d(с, 1), записывает данные в пайп, 
    сообщает ребенку через a(с, 2) о записи, блокируется через z(c)
    2. запускается ребенок, при этом c = 1, читает данные из пайпа, 
    записывает данные в пайа, выполняется d(с, 1) для запуска 
    и d(c,1) для блокировки до след. итерации
    3. z(c) запускает родителя, читает данные ребенка
    4. новая итерация 
*/
void block(int sem) {
    struct sembuf buf;
    buf.sem_num = 0;
    buf.sem_op  = 0;
    buf.sem_flg = 0;
    if (semop(sem, &buf, 1) < 0) {
        printf("Cannot block\n");
        exit(-1);
    }
}

void d(int sem, int n) {
    struct sembuf buf;
    buf.sem_num = 0;
    buf.sem_op  = -n;
    buf.sem_flg = 0;
    if (semop(sem, &buf, 1) < 0) {
        printf("Failed D\n");
        exit(-1);
    }
}

void a(int sem, int n) {
    struct sembuf buf;
    buf.sem_num = 0;
    buf.sem_op  = n;
    buf.sem_flg = 0;
    if (semop(sem, &buf, 1) < 0) {
        printf("Failed A\n");
        exit(-1);
    }
}

int main() { 
    int fd[2];
    int res;
    int N;
    int id;
    char  str[12] = "Some Message";
    size_t size;
    printf("N=");
    if (scanf("%d", &N) != 1) {
        printf("Failed to read N\n");
        return -1;
    } 
    
    if (N < 2) {
        printf("n should be >= 2");
        return -1;
    } 
    
    if (pipe(fd) < 0) {
        printf("Failed to open pipe\n");
        return -1;
    }
    
    if ((id = semget(IPC_PRIVATE, 1, 0666 | IPC_CREAT)) < 0) {
        printf("Failed to create semaphore\n");
        return -1;
    }
    
    res = fork();
    if (res < 0) {
        printf("Failed to fork child\n");
        return -1;
    } 
    else if (res > 0) {
        /* Parent proccess */
        for (int i = 0; i < N; i++) {
            size = write(fd[1], str, 12);
            if (size != 12) {
                printf("Failed to write to pipe\n");
                return -1;
            }
            
            printf("Parent %d write: %s\n", i + 1, str);
            a(id, 2);
            block(id);
            size = read(fd[0], str, 12);
            if (size < 0) {
                printf("cannot read from pipe\n");
                return -1;
            }
        }
        if (close(fd[0]) < 0 || close(fd[1]) < 0) {
            printf("cannot close pipe\n"); 
            return -1;
        }
        printf("End of parent process\n");
    } else {
        /* Child proccess */
        for (int i = 0; i < N; i++) {
            d(id, 1);
            size = read(fd[0], str, 12);
            if (size < 0) {
                printf("Failed to read from pipe\n");
                return -1;
            }
            printf("Child %d read: %s\n", i + 1, str);
            size = write(fd[1], str, 12);
            
            if (size != 12) {
                printf("Failed to write in pipe\n");
                return -1;
            }
            d(id, 1);
        }

        if (close(fd[0]) < 0 || close(fd[1]) < 0) {
            printf("Failed to close pipe\n"); 
            return -1;
        }
        printf("End of child process\n");
    }

    return 0;
}