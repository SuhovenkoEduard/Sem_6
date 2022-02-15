#include "Sorts.h"

void Pyzirok(int* arr, int size)
{
	 for(int i = 0; i < size - 1;i++) 
   	 {            
       		 for(int j = 0; j < size - 1;j++) 
        		{     
           			 if (arr[j + 1] < arr[j]) 
           			 {
               				 int tmp = arr[j + 1]; 
              				  arr[j + 1] = arr[j]; 
              				  arr[j] = tmp;
           			 }
       		 }
    	}	
}
void Vstavka(int* arr, int size)
{
	 for (int i = 1, j; i < size;i++)
   	 {
       		 int tmp = a[i]; 
        		for (j = i - 1; j >= 0 && a[j] > tmp;j--)
		 {
           			 a[j + 1] = a[j];  
		}
        		a[j + 1] = tmp;    
    }
}