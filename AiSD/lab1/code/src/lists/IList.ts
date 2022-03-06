export interface IList<T> {
  length: number
  getValueByIndex: (index: number) => T
  insert: (index: number, value: T) => void
  erase: (index: number) => void
  swapByIndex: (firstIndex: number, secondIndex: number) => void
  sort: (comparator: (a: T, b: T) => boolean) => void
  pushBack: (value: T) => void
  popBack: () => void
  toArray: () => T[]
}
