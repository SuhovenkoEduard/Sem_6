class ProcessEntity:
    def __init__(self, title, latency, full_completing_time, priority, appearance_time, timing=None):
        self.__title = title
        self.__timing = timing
        self.__latency = latency
        self.__full_completing_time = full_completing_time
        self.__priority = priority
        self.__appearance_time = appearance_time

    @property
    def title(self):
        return self.__title

    @property
    def latency(self):
        return self.__latency

    @property
    def full_completing_time(self):
        return self.__full_completing_time

    @property
    def priority(self):
        return self.__priority

    @property
    def appearance_time(self):
        return self.__appearance_time

    @property
    def timing(self):
        return self.__timing

    @title.setter
    def title(self, title):
        self.__title = title

    @latency.setter
    def latency(self, latency):
        self.__latency = latency

    @full_completing_time.setter
    def full_completing_time(self, full_completing_time):
        self.__full_completing_time = full_completing_time

    @priority.setter
    def priority(self, priority):
        self.__priority = priority

    @appearance_time.setter
    def appearance_time(self, appearance_time):
        self.__appearance_time = appearance_time

    @timing.setter
    def timing(self, timing):
        self.__timing = timing
