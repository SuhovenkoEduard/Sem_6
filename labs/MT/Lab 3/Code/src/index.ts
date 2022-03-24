import * as fs from 'fs'
import { INDEXED_CONNECTIONS, INPUT_JSON_PATH } from './constants/constants'
import { IndexedVerConnection, StringInterval } from './constants/types'

const stringsToCheck = JSON.parse(fs.readFileSync(INPUT_JSON_PATH).toString()).stringsToCheck

const [target]: [string] = stringsToCheck

console.log({ target })

const replace = (s: string, value: string, l: number, r: number) => {
  return `${s.slice(0, l)}${value}${s.slice(r + 1)}`
}

// translate
const translate = (s: string, connections: IndexedVerConnection[]): string => {
  const chars: string[] = s.split('')
  const translatedChars = chars.map((char) => {
    const filteredConnections = connections.filter(connection => connection.from.test(char))
    return filteredConnections.length ? filteredConnections[0].to.source : char
  })

  return translatedChars.join('')
}

const replaceAll = (s: string, regExp: RegExp, to: string): string => {
  const intervals = Array.from(s.matchAll(regExp))
    .map(elem => ({ str: elem[0], l: elem.index, r: elem.index + elem[0].length - 1 }))
    .reverse()
  return intervals
    .reduce((acc: string, { l, r }: StringInterval) => {
      return replace(acc, to, l, r)
    }, s)
}

const findBrackets = (s: string, isIdentifier = false): StringInterval[] | null => {
  const result: StringInterval[] = []
  const stack = []
  let bracketCounter = 0
  for (let i = 0; i < s.length; ++i) {
    if (s[i] === '(') {
      stack.push(i)
      bracketCounter += 1
    }
    if (s[i] === ')') {
      const l = stack.pop()
      const r = i
      result.push({ str: s.slice(l, r + 1), l, r })
      bracketCounter -= 1
    }
  }
  return !bracketCounter
    ? isIdentifier
      ? result.filter(interval => (interval.l ? s[interval.l - 1] : '') === 'V')
        .map(({ str, l, r }) => ({ str: 'V' + str, l: l - 1, r }))
      : result.filter(interval => (interval.l ? s[interval.l - 1] : '') !== 'V')
    : null
}

const repeatStr = (s: string, length: number) => {
  let repeated = s
  while (repeated.length < length) repeated += s
  return repeated
}

const removeBrackets = (s: string, to: string): string => {
  const brackets: StringInterval[] | null = findBrackets(s)
  return brackets
    ? replaceAll(brackets.reduce((acc: string, { l, r }: StringInterval) => {
      return replace(acc, repeatStr(to, r - l + 1), l, r)
    }, s), /H+/g, to)
    : s
}

const removeFunctions = (s: string, to: string): string => {
  const brackets: StringInterval[] | null = findBrackets(s, true)
  return brackets
    ? replaceAll(brackets.reduce((acc: string, { l, r }: StringInterval) => {
      return replace(acc, repeatStr(to, r - l + 1), l, r)
    }, s), /F+/g, 'F')
    : s
}

const REGEXPS = {
  identifier: /L+D*/g,
  realNumber: /D*\.?D+/g,
}

// (+) 0.1-0.4
const translated = translate(target, INDEXED_CONNECTIONS)
// (+) 3
const removedIdentifiers = replaceAll(translated, REGEXPS.identifier, 'V')
// (+) 1-2
const removedNumbers = replaceAll(removedIdentifiers, REGEXPS.realNumber, 'R')
// (-) 4-5
const removedBrackets = removeBrackets(removedNumbers, 'H')
const removedFunctions = removeFunctions(removedBrackets, 'F')
const replacedH = replaceAll(removedFunctions, /[FVR]/g, 'H')

const steps = [
  { step: 'translate', translated, length: translated.length },
  { step: 'identifiers', removedIdentifiers, length: removedIdentifiers.length },
  { step: 'numbers', removedNumbers, length: removedNumbers.length },
  { step: 'brackets', removedBrackets, length: removedBrackets.length },
  { step: 'functions', removedFunctions, length: removedFunctions.length },
  { step: 'replace-to-H', replacedH, length: replacedH.length },
]

console.log(steps)

// console.log(findConnections('TMU', INDEXED_CONNECTIONS))
// console.log(INDEXED_CONNECTIONS.map(
//   (pair) => pair.from.source))

