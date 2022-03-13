import { IList } from '../IList'

export class ArrayList<T> implements IList<T>{
  array: Array<T>

  length: number

  constructor(array: T[] = []) {
    this.array = [...array]
    this.length = this.array.length
  }

  erase(index: number): void {
    if (index < 0 || index >= this.length) throw new Error('ERASE: Index is out of bound')
    this.array = [...this.array.slice(0, index), ...this.array.slice(index + 1)]
    this.length -= 1
  }

  getValueByIndex(index: number): T {
    if (index < 0 || index >= this.length) throw new Error('GET_VALUE_BY_INDEX: Index is out of bound')
    return this.array[index]
  }

  insert(index: number, value: T): void {
    if (index < 0 || index > this.length) throw new Error('INSERT: Index is out of bound')
    this.array = [...this.array.slice(0, index), value, ...this.array.slice(index)]
    this.length += 1
  }

  popBack(): void {
    if (!this.length) throw new Error('POP_BACK: Array doesn\'t contain any element')
    this.erase(this.length - 1)
  }

  pushBack(value: T): void {
    this.insert(this.length, value)
  }

  sort(comparator: (a: T, b: T) => boolean = (a: T, b: T) => a < b): void {
    for (let i = 0; i < this.length; ++i) {
      let minIndex = i
      let minValue: T = this.getValueByIndex(i)
      for (let j = i + 1; j < this.length; ++j) {
        if (comparator(this.getValueByIndex(j), minValue)) {
          minValue = this.getValueByIndex(j)
          minIndex = j
        }
      }
      this.swapByIndex(i, minIndex)
    }
  }

  swapByIndex(firstIndex: number, secondIndex: number): void {
    if (firstIndex < 0 || firstIndex >= this.length) throw new Error('SWAP_BY_INDEX: First index is out of bound')
    if (secondIndex < 0 || secondIndex >= this.length) throw new Error('SWAP_BY_INDEX: Second index is out of bound');
    [this.array[firstIndex], this.array[secondIndex]] = [this.array[secondIndex], this.array[firstIndex]]
  }

  toArray(): T[] {
    return [...this.array.slice(0, this.length)]
  }
}
