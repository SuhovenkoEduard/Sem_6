from PlanningSystems.Interfaces.IBasePlanning import IBasePlanning
from prettytable import PrettyTable


class BasePlanningEntity(IBasePlanning):
    __title__ = None
    __fields__ = ['Processes', 'Latency',
                  'Full completing time', 'Appearance time', 'Priority']

    def __init__(self, processes: list):
        self.__processes__ = sorted(processes, key=lambda x: x.title)

        self.__whole_time__ = sum(
            process.full_completing_time for process in self.__processes__)

        self.__average_completing_time__ = None
        self.__average_latency_time__ = None

    def __show_tables__(self) -> None:
        self.__make_plan__()
        self.__show_data_table__()
        self.__show_time_table__()

    def __show_data_table__(self) -> None:
        table = PrettyTable()
        table.title = self.__title__
        table.field_names = self.__fields__
        data_rows = [(process.title, process.latency, process.full_completing_time,
                      process.appearance_time, process.priority) for process in self.__processes__]
        table.add_rows(data_rows)
        print(table)

    def __show_time_table__(self) -> None:
        table = PrettyTable()
        table.title = self.__title__
        table.field_names = ['Time'] + \
            [str(i) for i in range(1, self.__whole_time__ + 1)]
        data_rows = [[process.title] +
                     process.timing for process in self.__processes__]
        table.add_rows(data_rows)
        print(table)

    def __make_plan__(self) -> None:
        for process in self.__processes__:
            process.timing = [" " for i in range(self.__whole_time__)]

    def show_info(self):
        self.__show_tables__()
        self.__calculate_statistic__()
        print(f'Full completing time: {self.__whole_time__}')
        print(f'Average completing time: {self.__average_completing_time__}')
        print(f'Average latency time: {self.__average_latency_time__}')
        print('-' * 50, '\n\n')

    def __calculate_statistic__(self):
        self.__average_completing_time__ = sum(
            [process.full_completing_time for process in self.__processes__]) / len(self.__processes__)
        self.__average_latency_time__ = sum(
            [process.latency for process in self.__processes__]) / len(self.__processes__)

    def __lil_beast__(self, process, *args):
        pass
