export type VerConnection = {
  from: RegExp
  to: RegExp
}

export type IndexedVerConnection = VerConnection & {
  index: number
}

export type StringInterval = {
  str: string
  l: number
  r: number
}
