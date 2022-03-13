import { task1 } from './tasks/task1'
import { task2 } from './tasks/task2'
import { task3 } from './tasks/task3'

const main = async () => {
  const tasks = [task1, task2, task3]
  for (let i = 0; i < tasks.length; ++i) {
    console.log(`---TASK [${i + 1}]---`)
    await tasks[i]()
  }
}

main()

