import { encryptStringByKeyWord, encryptStringByTrianlges } from './encrypts'

const keyWord = 'КРИПТОГРАФИЯ'
const stringsToEncrypt = [
  'Этo лекция по алгоритмам шифрования',
  'Это лекция по шифрам',
]

console.log(encryptStringByKeyWord(stringsToEncrypt[0], keyWord))
console.log(encryptStringByTrianlges(stringsToEncrypt[1]))
