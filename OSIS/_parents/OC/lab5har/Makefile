СС=gсс
CFLAGS=-Wall -c
FinalName=lab5
IshKat=src
BinKat=bin

all: $(FinalName)

$(FinalName): main.o Sorts.o Func.o
	$(CC) main.o Sorts.o Func.o -lstdc++ -o $(BinKat)/$(FinalName)

Sorts.o: $(IshKat)/Sorts.cpp
	$(CC) $(CFLAGS) $(IshKat)/Sorts.cpp
	
Func.o: $(IshKat)/Func.cpp
	$(CC) $(CFLAGS) $(IshKat)/Func.cpp

main.o: $(IshKat)/main.cpp
	$(CC) $(CFLAGS) $(IshKat)/main.cpp

clean:
	rm -rf *.o 