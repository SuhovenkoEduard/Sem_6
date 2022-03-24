import { createFromToPair } from '../helpers/helpers'
import { IndexedVerConnection } from './types'

export const INPUT_JSON_PATH = './res/input.json'

export const INDEXED_CONNECTIONS: IndexedVerConnection[] = [
  createFromToPair(/B/, /S/),
  createFromToPair(/A/, /B/),
  createFromToPair(/B,A/, /B/),
  createFromToPair(/T/, /A/),
  createFromToPair(/ZT/, /A/),
  createFromToPair(/AZT/, /A/),
  createFromToPair(/U/, /T/),
  createFromToPair(/TMU/, /T/),
  createFromToPair(/H/, /U/),
  createFromToPair(/U\^H/, /U/),
  createFromToPair(/F/, /H/),
  createFromToPair(/V/, /H/),
  createFromToPair(/R/, /H/),
  createFromToPair(/\(A\)/, /H/),
  createFromToPair(/V\(B\)/, /F/),
  createFromToPair(/L/, /V/),
  createFromToPair(/VL/, /V/),
  createFromToPair(/VD/, /V/),
  createFromToPair(/I/, /R/),
  createFromToPair(/I\./, /R/),
  createFromToPair(/\.I/, /R/),
  createFromToPair(/I\.I/, /R/),
  createFromToPair(/D/, /I/),
  createFromToPair(/ID/, /I/),
  createFromToPair(/\+/, /Z/),
  createFromToPair(/-/, /Z/),
  createFromToPair(/\*/, /M/),
  createFromToPair(/\//, /M/),
  createFromToPair(/[a-z]/, /L/),
  createFromToPair(/\d/, /D/),
].map((pair, index) => ({ ...pair, index: index + 1 }))
