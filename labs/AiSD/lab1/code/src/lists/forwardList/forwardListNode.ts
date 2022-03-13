export class ForwardListNode<T> {
  public  value: T | null

  public next: ForwardListNode<T> | null

  constructor(value: T, next: ForwardListNode<T> = null) {
    this.value = value
    this.next = next
  }
}
