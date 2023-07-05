#include <stdlib.h>
#include <stdio.h>
#include <stdbool.h>
#include <signal.h>
#include <unistd.h>

// sender programm

int r_pid, val;
bool flag = true;

void receiver_signal_handler(int nsig) {
	flag = true;
}

void send_value() {
	int bits_count = sizeof(int) * 8;
	for (int i = 0; i < bits_count; ++i) {
		// do not send requests until response from previous request received
		while (!flag);
		if ((val & (1 << i)) != 0) kill(r_pid, SIGUSR1);
		else kill(r_pid, SIGUSR2);
		flag = false;
	}
	// signal for end of request
	kill(r_pid, SIGCHLD);
}

int main() {
	signal(SIGUSR1, receiver_signal_handler);
	printf("sender PID: %d\n", (int)getpid());
	printf("receiver PID:\n");
	if (scanf("%d", &r_pid) < 0) {
		printf("Can't read receiver PID.\n");
		exit(-1);
	}
	printf("Input integer:\n");
	if (scanf("%d", &val) < 0) {
		printf("Can't read int\n");
		exit(-1);
	}
	send_value();
	return 0;
}