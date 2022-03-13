from PlanningSystems.FCFSDirect import FCFSDirect
from PlanningSystems.FCFSReversed import FCFSReversed
from PlanningSystems.RoundRobin import RoundRobin
from PlanningSystems.ShortestJobFirstCrowdOut import ShortestJobFirstCrowdOut
from PlanningSystems.ShortestJobFirstNonCrowdOutPriority import ShortestJobFirstNonCrowdOutPriority
from PlanningSystems.ShortestJobFirstNonCrowdOut import ShortestJobFirstNonCrowdOut
from PlanningSystems.ShortestJobFirstPriority import ShortestJobFirstPriority
from Entities.ProcessEntity import ProcessEntity
import copy


def main():
    processes = [
        ProcessEntity("P0", 0, 7, 2, 1),
        ProcessEntity("P1", 0, 1, 1, 2),
        ProcessEntity("P2", 0, 4, 3, 4),
        ProcessEntity("P3", 0, 6, 4, 0),
    ]
    FCFSDirect(copy.deepcopy(processes)).show_info()
    FCFSReversed(copy.deepcopy(processes)).show_info()
    RoundRobin(copy.deepcopy(processes)).show_info()
    ShortestJobFirstNonCrowdOut(copy.deepcopy(processes)).show_info()
    ShortestJobFirstNonCrowdOutPriority(copy.deepcopy(processes)).show_info()
    ShortestJobFirstCrowdOut(copy.deepcopy(processes)).show_info()
    ShortestJobFirstPriority(copy.deepcopy(processes)).show_info()


if __name__ == "__main__":
    main()
