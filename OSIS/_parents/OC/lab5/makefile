path_to_src:=src
path_to_bin:=bin/
path_to_base:=./
name_program:=task
main_function: create_o_files create_program_with_buble_sort
	
create_o_files: main.o auxiliaryFunction.o searchMaxInForwardList.o bubleSort.o

create_program_with_buble_sort:
	g++ ${path_to_bin}main.o ${path_to_bin}auxiliaryFunction.o ${path_to_bin}searchMaxInForwardList.o ${path_to_bin}bubleSort.o -o ${name_program} -lm
	sudo mv ${name_program} ${path_to_bin}

create_program_with_quick_sort:
	g++ ${path_to_bin}main.o ${path_to_bin}auxiliaryFunction.o ${path_to_bin}searchMaxInForwardList.o ${path_to_bin}quickSort.o -o ${name_program} -lm
	sudo mv ${name_program} ${path_to_bin}

change_sort_quick_sort: delete_buble_sort quickSort.o create_program_with_quick_sort

change_sort_buble_sort: delete_quick_sort bubleSort.o create_program_with_buble_sort

delete_buble_sort:
	sudo rm ${path_to_bin}bubleSort.o

delete_quick_sort:
	sudo rm ${path_to_bin}quickSort.o

main.o:
	g++ -c ${path_to_src}/main.cpp
	sudo mv main.o ${path_to_bin}
auxiliaryFunction.o:
	g++ -c ${path_to_src}/auxiliaryFunction.cpp
	sudo mv auxiliaryFunction.o ${path_to_bin}
searchMaxInForwardList.o:
	g++ -c ${path_to_src}/searchMaxInForwardList.cpp
	sudo mv searchMaxInForwardList.o ${path_to_bin}
bubleSort.o:
	g++ -c ${path_to_src}/bubleSort.cpp
	sudo mv bubleSort.o ${path_to_bin}
quickSort.o:
	g++ -c ${path_to_src}/quickSort.cpp
	sudo mv quickSort.o ${path_to_bin}
clean: 
	sudo rm ${path_to_bin}*.o
	sudo rm ${path_to_bin}task
