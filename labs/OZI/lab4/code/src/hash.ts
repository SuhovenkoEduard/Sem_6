export const generateHashBySteps = (str: string) => {
  const alphabet = 'абвгдеёжзийклмнопрстуфхцчшщъыьэюя'.split('')
  const p = 7
  const q = 23
  const n = p * q
  let H0 = 105

  const charArr: string[] = str.split('')
  for (let i = 0; i < charArr.length; i++) {
    const tempAnswer = ((H0 + alphabet.indexOf(charArr[i]) + 1) ** 2) % n
    console.log(`H${i + 1} = (H${i} + M${i + 1})^2 mod n = (${H0} + ${alphabet.indexOf(str[i]) + 1})^2 mod ${n} = ${tempAnswer}`)
    H0 = tempAnswer
  }
  console.log('-----------------------------------------')
}

