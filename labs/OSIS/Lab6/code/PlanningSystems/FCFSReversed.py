from PlanningSystems.FCFSDirect import FCFSDirect


class FCFSReversed(FCFSDirect):
    __title__ = "FIRST-COME, FIRST-SERVED, reversed"

    def __init__(self, processes: list):
        super().__init__(processes)
        self.__reverse_appearance_time__()

    def __reverse_appearance_time__(self):
        self.__processes__ = sorted(
            self.__processes__, key=lambda x: x.appearance_time)
        appearance_time = [
            process.appearance_time for process in self.__processes__]
        appearance_time.reverse()
        for i in range(len(self.__processes__)):
            self.__processes__[i].appearance_time = appearance_time[i]
            self.__processes__ = sorted(
                self.__processes__, key=lambda x: x.title)
