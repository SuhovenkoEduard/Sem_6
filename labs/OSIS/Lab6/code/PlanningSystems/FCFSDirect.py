from Entities.BasePlanningEntity import BasePlanningEntity
import copy


class FCFSDirect(BasePlanningEntity):
    __title__ = "FIRST-COME, FIRST-SERVED, direct"

    def __init__(self, processes: list):
        super().__init__(processes)

    def __make_plan__(self) -> None:
        super().__make_plan__()

        # sorted_processes - objects which will lose their full completing time,
        # but they will have latency and timing
        sorted_processes = sorted(copy.deepcopy(
            self.__processes__), key=lambda x: x.appearance_time)
        start = min(process.appearance_time for process in sorted_processes)

        for i, process in enumerate(sorted_processes, start=0):
            sorted_processes[i] = self.__lil_beast__(
                process, start, start + process.full_completing_time)
            start += process.full_completing_time
            sorted_processes = sorted(sorted_processes, key=lambda x: x.title)
            for i in range(len(sorted_processes)):
                self.__processes__[i].timing = sorted_processes[i].timing
                self.__processes__[i].latency = sorted_processes[i].latency

    def __lil_beast__(self, process, *args):
        """
        See description in an abstract class file.
        :param process: the process itself.
        :param args: start and end of timing (in MAIN FLOW)
        :return: sophisticated lil beast itself...
        """
        start, end = args
        process.timing[process.appearance_time:end] = [
            "Г" for i in range(process.appearance_time, end)]
        process.timing[start:end] = ['И' for i in range(start, end)]
        process.latency = process.timing.count('Г')
        return process
