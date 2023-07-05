#include <stdio.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/ipc.h>
#include <sys/sem.h>

int main(int argc, char *argv[], char *envp[]) 
{
    int id;
    char filePath[] = "2-1.c";
    key_t  key;
    struct sembuf buf;

    if ((key = ftok(filePath,0)) < 0) 
    {
        printf("Failed to create key\n");
        return -1;
    }

    if ((id = semget(key, 1, 0666 | IPC_CREAT)) < 0) 
    {
        printf("Failed to create semaphore\n");
        return -1;
    }

    buf.sem_num = 0;
    buf.sem_op  = -5;
    buf.sem_flg = 0;

    if (semop(id, &buf, 1) < 0) 
    {
        printf("Failed to wait condition\n");
        return -1;
    }

    printf("Success 1\n");

    return 0;
}