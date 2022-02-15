#include <iostream>
#include <mutex>
#include <thread>
#include <chrono>
#include <fstream>
#include <string>

using namespace std;

void addValueOne();
void addValueTwo();

mutex coolMutex;
int x = 0;

int main() {

	thread t1(addValueOne);
	thread t2(addValueTwo);

	t1.join();
	t2.join();

	return 0;
}


void addValueOne() {
	int i = 0;
	while (i < 7)
	{
		coolMutex.lock();
		clock_t start, end;
		start = clock();
		printf("Function_1 start working: %d ms\n", start);
		x += 1;
		printf("x = %d\n", x);
		this_thread::sleep_for(std::chrono::seconds(rand() % 3));
		coolMutex.unlock();
		end = clock();

		printf("Function_1 finish working: %d ms \n Time work is %d ms\n\n", end, ((double)end - start));

		i++;

	}

}

void addValueTwo() {
	int i = 0;
	while (i < 13)
	{
		coolMutex.lock();
		clock_t start, end;
		start = clock();
		printf("Function_2 start working: %d ms\n", start);
		x += 2;
		printf("x = %d\n", x);
		this_thread::sleep_for(std::chrono::seconds(rand() % 3));

		coolMutex.unlock();
		end = clock();
		printf("Function_2 finish working: %d ms \n Time work is %d ms\n\n", end, ((double)end - start));
			
		i++;

	}
}
