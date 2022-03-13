from Entities.BasePlanningEntity import BasePlanningEntity
import copy


class RoundRobin(BasePlanningEntity):
    __title__ = "ROUND ROBIN (RR)"
    portion = 3

    def __init__(self, processes: list):
        super().__init__(processes)

    def __make_plan__(self) -> None:
        super().__make_plan__()
        sorted_processes = sorted(copy.deepcopy(
            self.__processes__), key=lambda x: x.appearance_time)
        start = min(process.appearance_time for process in sorted_processes)
        while start < self.__whole_time__:
            for i in range(0, len(sorted_processes)):
                sorted_processes[i], start = self.__lil_beast__(
                    sorted_processes[i], start)
        sorted_processes = self.__point_ready_moments__(sorted_processes)
        sorted_processes = sorted(sorted_processes, key=lambda x: x.title)
        for i in range(len(sorted_processes)):
            self.__processes__[i].timing = sorted_processes[i].timing
            self.__processes__[i].latency = sorted_processes[i].latency

    def __lil_beast__(self, process, *args):
        """
        See description in an abstract class file.
        :param process: the process itself.
        :param args: current time.
        :return: process, time.
        """
        time = args[0]
        process.timing[time:time + min(self.portion, process.full_completing_time)] \
            = ['И' for i in range(min(self.portion, process.full_completing_time))]
        time += min(self.portion, process.full_completing_time)
        process.full_completing_time -= min(self.portion,
                                            process.full_completing_time)
        return process, time

    @staticmethod
    def __point_ready_moments__(processes):
        """
        It should be used after __lil_beast__.
        :param processes: processes
        :return: modified processes
        """
        for i, process in enumerate(processes, start=0):
            start = process.appearance_time
            end = ''.join(process.timing).rfind('И')
            for j in range(start, end + 1):
                if process.timing[j] != 'И':
                    process.timing[j] = 'Г'
                    process.latency += 1
        return processes
