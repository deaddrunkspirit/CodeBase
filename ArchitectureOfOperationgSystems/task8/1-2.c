#include <fcntl.h>
#include <errno.h>
#include <sys/ipc.h>
#include <sys/shm.h>
#include <stdio.h>
#include <stdlib.h>


int main() {
    char *shm;
    int id;
    char file[] = "1-1.c";
    key_t key;
    if ((key = ftok(file, 0)) < 0) {
        printf("Failed to generate key\n");
        return -1;
    }
    int n = 1512;
    if ((id = shmget(key, n * sizeof(char), 0666 | IPC_EXCL)) < 0) {
        if (errno != EEXIST) {
            printf("Shared memory not found\n");
            return -1;
        } 
        else {
            if ((id = shmget(key, n * sizeof(char), 0)) < 0) {
                printf("Failed to obtain shared memory\n");
                return -1;
            }
        }
    }
    if ((shm = (char*)shmat(id, 0, 0)) == (char*)(-1)) {
        printf("Failed to attach shared memory\r\n");
        return -1;
    }
    printf("Reading finished\n%s\n", shm);
    if (shmdt(shm) < 0) {
        printf("Failed to detach shared memory\n");
        return -1;
    }
    if (shmctl(id, IPC_RMID, 0)) {
        printf("Failed delete shared memory\n");
        return -1;
    }

    return 0;
}