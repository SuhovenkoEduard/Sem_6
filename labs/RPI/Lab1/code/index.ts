import { functionB } from './lib'
import * as Readline from "readline"

const calcFromConstants = () => {
  return functionB(1, 2, 3)
}

const calcFromInputData = (x: number, y: number, z: number) => {
  return functionB(x, y, z)
}

const rl = Readline.createInterface({
  input: process.stdin,
  output: process.stdout
})

const cin = async (message: string) => {
  const question = (resolve: (value: string | PromiseLike<string>) => void) => {
    rl.question(message, resolve)
  }
  return new Promise<string>(question)
}

const main = async () => {
  const x: number = +(await cin('Input x: '))
  const y: number = +(await cin('Input y: '))
  const z: number = +(await cin('Input z: '))

  console.log(x, y, z)
  console.log(`Result using constants: ${calcFromConstants()}`)
  console.log(`Result using readline: ${calcFromInputData(x, y, z)}`)
}

main()

