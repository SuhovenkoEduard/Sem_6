export class HashTable {
  public data: string[][] = []
  public size = 100

  constructor() {
    for (let i = 0; i < this.size; ++i) {
      this.data[i] = []
    }
  }

  getHash = (s: string) => s.split('').reduce((hash: number, s) => (hash * s.charCodeAt(0)) % this.size, 1)

  addString = (s: string) => this.data[this.getHash(s)].push(s)

  includes = (s: string) => this.data[this.getHash(s)].includes(s)

  indexOf = (s: string) => this.includes(s) ? this.getHash(s) : -1
}
