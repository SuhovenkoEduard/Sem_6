#include "Func.h"

int Task(int* arr,int size)
{
	int res = 1;
	for(int i=0;i<size;i+=2){
		if(arr[i]<0)
		{
			res*=arr[i];
		}
                  }
	return res;
}