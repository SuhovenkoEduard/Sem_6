import threading
import datetime

lock = threading.RLock()
quantity_records = 10000000


def first_thread_func(isLockUsed: bool):
    print(f'{datetime.datetime.now()} <---> First thread started!')
    if isLockUsed:
        lock.acquire()
        print(f'{datetime.datetime.now()} <---> First thread locked critical section!')
    try:
        with open('hallow.txt', 'w') as file:
            for i in range(quantity_records):
                file.write('first\n')
        print(f'First thread had written {quantity_records} records!')
    finally:
        if isLockUsed:
            lock.release()
            print(f'{datetime.datetime.now()} <---> First unlocked critical section!')


def second_thread_func(isLockUsed: bool):
    print(f'{datetime.datetime.now()} <---> Second thread started!')
    if isLockUsed:
        lock.acquire()
        print(f'{datetime.datetime.now()} <---> Second thread locked critical section!')
    try:
        with open('hallow.txt', 'r') as file:
            print(f'Records quantity is {sum(1 for _ in file)}')
    finally:
        if isLockUsed:
            lock.release()
            print(f'{datetime.datetime.now()} <---> Second unlocked critical section!')


def main():
    with open('hallow.txt', 'w') as file:
        pass

    isLockUsed = False

    thread1 = threading.Thread(target=first_thread_func, args=([isLockUsed]))
    thread2 = threading.Thread(target=second_thread_func, args=([isLockUsed]))

    thread1.start()
    thread2.start()
    thread2.join()
    thread1.join()


if __name__ == "__main__":
    main()
