#include <stdio.h>
#include <errno.h>
#include <stdlib.h>
#include <sys/ipc.h>
#include <sys/shm.h>
#include <sys/types.h>
#include <sys/sem.h>

void setbuf(struct sembuf *buf, int op, int num, int flg) 
{
    buf -> sem_op = op;
    buf -> sem_num = num;
    buf -> sem_flg = flg;
}

int main() 
{
    int *data;
    int shmid;
    int semId;
    int n = 1;
    char fileName[] = "1-1.c";
    struct sembuf buf;
    key_t key;
    long i;

    if ((key = ftok(fileName, 0)) < 0) 
    {
        printf("Failed generate key\n");
        return -1;
    }

    if ((shmid = shmget(key, 3 * sizeof(int), 0666 | IPC_CREAT | IPC_EXCL)) < 0) {
        if (errno != EEXIST) 
        {
            printf("Failed create shared memory\n");
            return -1;
        } else 
        {
            if ((shmid = shmget(key, 3 * sizeof(int), 0)) < 0) 
            {
                printf("No shared memory found\n");
                return -1;
            }
            n = 0;
        }
    }

    if ((data = (int *) shmat(shmid, NULL, 0)) == (int *) (-1)) 
    {
        printf("No shared memory attached\n");
        return -1;
    }

    if ((semId = semget(key, 1, 0666)) < 0) 
    {
        printf("No semafore found\n");
        if ((semId = semget(key, 1, 0666 | IPC_CREAT)) < 0) 
        {
            printf("Failed get semafore\n");
            exit(-1);
        }

        printf("Seamfore created\n");

        setbuf(&buf, 1, 0, 0);
        semop(semId, &buf, 1);
    }

    if (n) 
    {
        data[0] = 1;
        data[1] = 0;
        data[2] = 1;
    } 
    else 
    {
        setbuf(&buf, -1, 0, 0);
        semop(semId, &buf, 1);
        data[0] += 1;
        for (i = 0; i < 2000000000L; i++);
        data[2] += 1;
        setbuf(&buf, 1, 0, 0);
        semop(semId, &buf, 1);
    }

    printf("First program runs = %d\n", data[0]);
    printf("Second program runs = %d\n", data[1]);
    printf("Total runs = %d\n", data[2]);

    if (shmdt(data) < 0) 
    {
        printf("Failed to detach shared memory\n");
        exit(-1);
    }

    return 0;
}
