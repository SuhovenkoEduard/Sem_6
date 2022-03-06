import { asyncTimeout } from './asyncUtils'

export const task1 = async () => {
  console.time('timer1')
  console.time('timer2')
  console.time('timer3')

  await Promise.all([
    asyncTimeout(() => console.timeEnd('timer1'), 100),
    asyncTimeout(() => console.timeEnd('timer2'), 200),
    asyncTimeout(() => console.timeEnd('timer3'), 300),
  ])
}
