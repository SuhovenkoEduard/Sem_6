// import { generateHashBySteps } from './hash'

// generateHashBySteps('суховенко')
// generateHashBySteps('суховенка')
// generateHashBySteps('суховенок')

const isCoPrime = (a: number, b: number) => {
  if (a < b) [a, b] = [b, a]
  let flag = false
  for (let j = 2; j <= b; ++j) {
    if (a % j === 0 && b % j === 0) {
      flag = true
      break
    }
  }
  return !flag
}

const target = 132
for (let i = 2; i < target; ++i) {
  if (isCoPrime(i, target)) {
    let ans = -1
    for (let j = 2; j < target; ++j) {
      if (j === i) continue
      if ((j * i) % target === 1) {
        ans = j
        break
      }
    }
    if (ans !== -1) {
      console.log(ans, i)
    }
  }
}
