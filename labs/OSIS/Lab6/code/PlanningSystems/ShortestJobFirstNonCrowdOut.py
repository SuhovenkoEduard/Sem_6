from Entities.BasePlanningEntity import BasePlanningEntity
import copy


class ShortestJobFirstNonCrowdOut(BasePlanningEntity):
    __title__ = "Shortest Job First Non Crowd Out"

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
            active_processes.sort(key=lambda x: x.full_completing_time)
            if len(active_processes) > 0:
                active_processes[0], time = self.__lil_beast__(
                    active_processes[0], time)
            else:
                time += 1
        for i, process in enumerate(processes_copy, start=0):
            self.__processes__[i].latency = process.latency
            self.__processes__[i].timing = process.timing

    def __lil_beast__(self, process, *args):
        """
        Lil beast itself.:param process: process
        :param args: time
        :return: updated process, time
        """
        time = args[0]
        process.timing[process.appearance_time:time + process.full_completing_time] = \
            ['Г' for i in range(process.appearance_time,
                                time + process.full_completing_time)]
        process.timing[time:time + process.full_completing_time] = \
            ['И' for i in range(time, time + process.full_completing_time)]
        process.latency = process.timing.count('Г')
        time += process.full_completing_time
        process.full_completing_time = 0
        return process, time
