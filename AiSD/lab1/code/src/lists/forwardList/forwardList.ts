import { ForwardListNode } from './forwardListNode'
import { IList } from '../IList'

export class ForwardList<T> implements IList<T>{
  root: ForwardListNode<T> | null

  length: number

  constructor(array: T[] = []) {
    this.root = null
    this.length = 0
    array.forEach(elem => this.pushBack(elem))
  }

  private getNodeByIndex = (index: number): ForwardListNode<T> | null => {
    if (index < 0 || index >= this.length) throw new Error('GET_NODE_BY_INDEX: Index is out of bound')
    let currentIndex = 0
    let currentNode: ForwardListNode<T> = this.root
    while (currentIndex != index && currentNode) {
      currentIndex += 1
      currentNode = currentNode.next
    }
    return currentNode
  }

  getValueByIndex = (index: number): T => {
    if (index < 0 || index >= this.length) throw new Error('GET_VALUE_BY_INDEX: Index is out of bound')
    return this.getNodeByIndex(index)?.value
  }

  insert = (index: number, value: T): void => {
    if (index < 0 || index > this.length) throw new Error('INSERT: Index is out of bound')
    const newNode = new ForwardListNode(value)
    if (!this.length) {
      this.root = new ForwardListNode<T>(value)
    } else {
      if (index - 1 >= 0 && index - 1 < this.length) {
        const prevNode = this.getNodeByIndex(index - 1)
        const curNode = prevNode?.next
        prevNode.next = newNode
        newNode.next = curNode
      } else {
        newNode.next = this.root
        this.root = newNode
      }
    }
    this.length += 1
  }

  erase = (index: number): void => {
    if (index < 0 || index >= this.length) throw new Error('ERASE: Index is out of bound')
    if (index - 1 >= 0 && index - 1 < this.length) {
      const prevNode = this.getNodeByIndex(index - 1)
      const curNode = prevNode?.next
      prevNode.next = curNode?.next
    } else {
      this.root = this.root?.next
    }
    this.length -= 1
  }

  swapByIndex = (firstIndex: number, secondIndex: number): void => {
    if (firstIndex < 0 || firstIndex >= this.length) throw new Error('SWAP_BY_INDEX: First index is out of bound')
    if (secondIndex < 0 || secondIndex >= this.length) throw new Error('SWAP_BY_INDEX: Second index is out of bound')
    const leftValue = this.getValueByIndex(firstIndex)
    const rightValue = this.getValueByIndex(secondIndex)
    this.erase(firstIndex)
    this.insert(firstIndex, rightValue)
    this.erase(secondIndex)
    this.insert(secondIndex, leftValue)
  }

  sort = (comparator: (a: T, b: T) => boolean = (a: T, b: T) => a < b): void => {
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

  pushBack = (value: T): void => {
    this.insert(this.length, value)
  }

  popBack = (): void => {
    if (!this.length) throw new Error('POP_BACK: Array doesn\'t contain any element')
    this.erase(this.length - 1)
  }

  toArray = (): T[] => {
    const resultArray: T[] = []
    let currentNode = this.root
    for (let i = 0; i < this.length; ++i) {
      resultArray.push(currentNode.value)
      currentNode = currentNode.next
    }
    return resultArray
  }
}
