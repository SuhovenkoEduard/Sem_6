type IndexedLetter = {
  letter: string
  index: number
}

type PositionedLetter = {
  indexedLetter: IndexedLetter
  value: number
}

const RUSSIAN_ALPHABET = 'АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ'

const findPositions = (keyWord: string): number[] => keyWord.split('')
  .map((letter: string, index: number): IndexedLetter => ({ letter, index }))
  .sort((a: IndexedLetter, b: IndexedLetter) => RUSSIAN_ALPHABET.indexOf(a.letter) - RUSSIAN_ALPHABET.indexOf(b.letter))
  .map((indexedLetter: IndexedLetter, index: number) => ({
    indexedLetter,
    value: index + 1,
  })).sort((a: PositionedLetter, b: PositionedLetter) => a.indexedLetter.index - b.indexedLetter.index)
  .map((positionedLetter: PositionedLetter) => positionedLetter.value)

export const toValidString = (stringToEncrypt: string) => {
  return stringToEncrypt.replace(/[ ]/g, '').toUpperCase()
}

export const encryptStringByKeyWord = (stringToEncrypt: string, keyWord: string) => {
  const positions = findPositions(keyWord).map((x, i) => [x, i]).sort((a, b) => a[0] - b[0]).map(x => x[1])
  const validString = toValidString(stringToEncrypt)
  const matrix = validString.split('').reduce((acc: string[][], cur: string, index: number) => {
    acc[Math.floor(index / keyWord.length)][index % keyWord.length] = cur
    return acc
  }, Array.from(Array(Math.ceil(validString.length / keyWord.length)), (): string[] => new Array(keyWord.length).fill('')))
  let result = ''
  for (let i = 0; i < positions.length; ++i) {
    for (let j = 0; j < matrix.length; ++j) {
      result += matrix[j][positions[i]]
    }
  }
  return result
}

export const encryptStringByTrianlges = (stringToEncrypt: string) => {
  const validString = toValidString(stringToEncrypt)
  const letterArray = validString.split('')
  const each41 = letterArray.reduce((acc: string[], x: string, index: number) => {
    return index % 4 === 0 ? [...acc, x] : acc
  }, [])
  const eachEven = letterArray.reduce((acc: string[], x: string, index: number) => {
    return index && index % 2 === 1 ? [...acc, x] : acc
  }, [])
  const each43 = letterArray.reduce((acc: string[], x: string, index: number) => {
    return index && index % 4 === 2 ? [...acc, x] : acc
  }, [])
  return each41.join('') + eachEven.join('') + each43.join('')
}
