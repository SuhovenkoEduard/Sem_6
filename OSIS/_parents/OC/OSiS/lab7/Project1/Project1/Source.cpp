#include <iostream>
#include <fstream>
#include <stdlib.h>
#include <process.h>
#include <time.h>
#include <inttypes.h>
#include <unistd.h>
#include <pthread.h>


pthread_mutex_t cs = PTHREAD_MUTEX_INITIALIZER;

using namespace std;
int main() {
	system("pause");
}

// int readWrite() {
// 	system("cls");
// 	char mline[75];
// 	int lc = 0;
// 	ofstream fout("out.txt", ios::out);
// 	ifstream fin("data.txt", ios::in);
// 	if (!fin) {
// 		cerr << "Failed to open file !";
// 		exit(1);
// 	}
// 	while (1) {
// 		fin.getline(mline, 75, '.');
// 		if (fin.eof()) { break; }
// 		lc++;
// 		fout << lc << ". " << mline << "\n";
// 	}
// 	fin.close();
// 	fout.close();
// 	cout << "Output " << lc << " records" << endl;
// 	return 0;
// }