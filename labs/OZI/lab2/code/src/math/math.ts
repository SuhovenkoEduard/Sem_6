export const gcd = (a: number, b: number): [number, [number, number][]] => {
  if (!b) return [a, [[a, 0]]]
  const [res, history] = gcd(b, a % b)
  return [res, [...history, [a, b]]]
}

export const getAllFactors = (a: number) => {
  let current = a
  const factors = []
  for (let i = 2; i < Math.sqrt(a); ++i) {
    while (current % i === 0) {
      factors.push(i)
      current /= i
    }
  }
  if (current !== 1) {
    factors.push(current)
  }
  return factors
}
