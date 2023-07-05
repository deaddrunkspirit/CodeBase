#include <pthread.h>
#include <stdio.h>
#include <stdlib.h>

int a = 0;

void *mythread(void *dummy) {
  pthread_t thid;
  thid = pthread_self();
  a = a + 1;
  printf("Thread %d, result = %d\n", thid, a);
  return NULL;
}

pthread_t create_and_launch_thread() {
  pthread_t thread_id;
  int       res;
  res = pthread_create(&thread_id, (pthread_attr_t *)NULL, mythread, NULL);
  if (res != 0) {
    printf ("Error on thread create, value = %d\n", res);
    exit(-1);
  }
  printf("Thread created, thid = %d\n", thread_id);
  return thread_id;
}

int main() {
  pthread_t my_thread_id, thread_1_id, thread_2_id;
  thread_1_id = create_and_launch_thread();
  thread_2_id = create_and_launch_thread();
  my_thread_id = pthread_self();
  a = a + 1;
  printf("Main thread %d, result = %d\n", my_thread_id, a);
  pthread_join(thread_1_id, (void **)NULL);
  pthread_join(thread_2_id, (void **)NULL);

  return 0;
}
