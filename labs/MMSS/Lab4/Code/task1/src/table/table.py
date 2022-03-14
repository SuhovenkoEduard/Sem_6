from prettytable import PrettyTable


def to_table(a):
    table = PrettyTable()
    table.add_rows([[f'{round(elem, 10):.5f}' for elem in row] for row in a])
    return table
