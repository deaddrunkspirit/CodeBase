#include <sys/ipc.h>
#include <sys/shm.h>
#include <unistd.h>
#include <stdio.h>
#include <stdlib.h>
#include <errno.h>
#include <fcntl.h>


int main() {
    char buffer[8096];
    char *text = buffer;
    char *shm;   
    char file[] = "1-1.c";
    int id;      
    int fd;

    if ((fd = open(file, O_RDONLY)) < 0) {
        printf("Failed to read %s\n", file);
        return -1;
    }
    int l = 0;
    char s;
    int reader;
    while (1) {
        reader = read(fd, &s, 1);
        if (reader < 0) {
            printf("Failed to read %s\n", file);
            return -1;
        }
        if (reader == 0) {
            break;
	}
        buffer[l] = s;
        l += 1;
    }
    if (close(fd) < 0) {
        printf("Failed to close file");
        return -1;
    }
    key_t key;        
    if ((key = ftok(file, 0)) < 0) {
        printf("Failed to generate key\n");
        return -1;
    }
    if ((id = shmget(key, l * sizeof(char), 0666 | IPC_CREAT | IPC_EXCL)) < 0) {
        if (errno != EEXIST) {
            printf("Failed to create shared memory\n");
            return -1;
        } 
        else {
            if ((id = shmget(key, l * sizeof(char), 0)) < 0) {
                printf("Can't find any shared memory\n");
                return -1;
            }
        }
    }
    if ((shm = (char * ) shmat(id, 0, 0)) == (char * ) (-1)) {
        printf("Failed to attach shared memory\n");
        return -1;
    }
    for (int i = 0; i < l; i++) {
        shm[i] = text[i];
    }
    if (shmdt(shm) < 0) {
        printf("Failed to detach shared memory\n");
        return -1;
    }
    return 0;
}