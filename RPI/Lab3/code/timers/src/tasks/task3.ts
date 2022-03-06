import { asyncImmediate } from './asyncUtils'

export const task3 = async () => {
  console.time('immediate')
  await asyncImmediate(() => console.timeEnd('immediate'))
}
