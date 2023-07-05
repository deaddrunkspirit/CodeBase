#include <stdlib.h>
#include <stdio.h>
#include <stdbool.h>
#include <signal.h>
#include <unistd.h>

// receiver programm

int s_pid;
int cur_bit = 0;
int res = 0;
bool flag = false;

// All handlers notify sender
void sigusr1_handler_bit(int nsig) {
	res |= (1 << cur_bit++);
	kill(s_pid, SIGUSR1);
}

void sigusr2_handler_nobit(int nsig) {
	cur_bit++;
	kill(s_pid, SIGUSR1);
}

void sigchld_handler(int nsig) {
	flag = true;
}

int main() {
	printf("receiver PID: %d\n", (int)getpid());
	printf("sender PID:\n");
	scanf("%d", &s_pid);
	// Set signal handlers and a handler for the end of the stream
	signal(SIGUSR1, sigusr1_handler_bit);
	signal(SIGUSR2, sigusr2_handler_nobit);
	signal(SIGCHLD, sigchld_handler);
	while (!flag);
	printf("Received: %d\n", res);
	return 0;
}