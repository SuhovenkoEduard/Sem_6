import { ForwardList } from './lists/forwardList/forwardList'
import { ArrayList } from './lists/arrayList/arrayList'
import { IList } from './lists/IList'

const sizeA = 4
const a = new Array(sizeA).fill(null).map((x, index) => [-index - 1, index + 1]).flat()
const b = [-5, 5, -6, 6, -7, 7]

const mergeLists = <T>(listClass: { new(): IList<T> }, first: IList<T>, second: IList<T>): IList<T> => {
  const resultList = new listClass()
  for (let i = 1; i < first.length; i += 2) {
    resultList.pushBack(first.getValueByIndex(i))
  }
  for (let i = 1; i < second.length; i += 2) {
    resultList.pushBack(second.getValueByIndex(i))
  }
  return resultList
}

console.log(`Size of first array: ${sizeA}`)
console.time('forward list')
const mergedForwardList = mergeLists(ForwardList, new ForwardList(a), new ForwardList(b))
console.timeEnd('forward list')
console.log(JSON.stringify(mergedForwardList.toArray()))

console.time('array list')
const mergedArrayList = mergeLists(ArrayList, new ArrayList(a), new ArrayList(b))
console.timeEnd('array list')
console.log(JSON.stringify(mergedArrayList.toArray()))
