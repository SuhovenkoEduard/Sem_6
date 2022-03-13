import copy
from Entities.BasePlanningEntity import BasePlanningEntity


class ShortestJobFirstPriority(BasePlanningEntity):
    __title__ = "Shortest Job First Priority"

    def __init__(self, processes: list):
        super().__init__(processes)

    def __make_plan__(self) -> None:
        super().__make_plan__()
        processes_copy = copy.deepcopy(self.__processes__)
        time = 0
        while time < self.__whole_time__:
            active_processes = [
                process for process in processes_copy
                if
                process.full_completing_time != 0 and process.appearance_time <= time
            ]
            active_processes.sort(key=lambda x: x.priority)
            if len(active_processes) > 0:
                active_processes[0] = self.__lil_beast__(
                    active_processes[0], time)
            time += 1
        self.__point_ready_moments__(processes_copy)
        for i, process in enumerate(processes_copy, start=0):
            self.__processes__[i].latency = process.latency
            self.__processes__[i].timing = process.timing

    def __lil_beast__(self, process, *args):
        """
        Lil beast itself.
        :param process: process
        :param args: time
        :return: updated process
        """
        time = args[0]
        process.timing[time:time + 1] = ['И' for i in range(time, time + 1)]
        process.full_completing_time -= 1
        return process
        
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
