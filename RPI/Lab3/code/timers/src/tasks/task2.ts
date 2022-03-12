import { asyncReadFile } from './asyncUtils'

export const task2 = async () => {
  // fs.writeFileSync('./res/out.json', JSON.stringify(Array(15).fill(null).map((x, i) => i), null, '  '))
  console.time('file reading')
  console.log(JSON.parse(await asyncReadFile('./res/out.json')))
  console.timeEnd('file reading')
}
