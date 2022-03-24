import { VerConnection } from '../constants/types'

export const createFromToPair: (from: RegExp, to: RegExp) => VerConnection
  = (from: RegExp, to: RegExp) => ({ from, to })
