import abc


class IBasePlanning(abc.ABC):
    @abc.abstractmethod
    def __show_tables__(self) -> None:
        pass

    @abc.abstractmethod
    def __show_data_table__(self) -> None:
        pass

    @abc.abstractmethod
    def __show_time_table__(self) -> None:
        pass

    @abc.abstractmethod
    def __make_plan__(self) -> None:
        pass

    @abc.abstractmethod
    def __lil_beast__(self, process, *args):
        """
        This creature is needed to eat full_completing_time and provide timing with latency.
        Wonderful and cruel it is a part of the great mechanism...
        Laurent...
        """
        pass

    @abc.abstractmethod
    def show_info(self):
        pass

    @abc.abstractmethod
    def __calculate_statistic__(self):
        pass
