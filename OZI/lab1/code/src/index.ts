import { encryptStringByKeyWord, encryptStringByTrianlges, RUSSIAN_ALPHABET } from './encrypts'

const keyWord = 'КРИПТОГРАФИЯ'
const stringsToEncrypt = [
  'Этo лекция по алгоритмам шифрования',
  'Это лекция по шифрам',
]

const name = 'СУХОВЕНКОЭДУАРДСЕРГЕЕВИЧ'
const key1 = 13
const key2 = 7
const mod = 33
console.log(name.split('').map((letter: string) => {
  const code = RUSSIAN_ALPHABET.indexOf(letter)
  const nextCode = (key1 * code + key2) % mod
  return RUSSIAN_ALPHABET[nextCode]
}).join(''))

console.log(encryptStringByKeyWord(stringsToEncrypt[0], keyWord))
console.log(encryptStringByTrianlges(stringsToEncrypt[1]))
