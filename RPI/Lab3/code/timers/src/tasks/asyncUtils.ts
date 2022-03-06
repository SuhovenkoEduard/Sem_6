import fs from 'fs'
import ErrnoException = NodeJS.ErrnoException

export const asyncTimeout = async (callback: () => void, time: number) => {
  return new Promise((resolve: (value: unknown) => void) => setTimeout(() => {
    callback()
    resolve(null)
  }, time))
}

export const asyncImmediate = async (callback: () => void) => {
  return new Promise((resolve: (value: unknown) => void) => setImmediate(() => {
    callback()
    resolve(null)
  }))
}

export const asyncReadFile = async (filePath: string) => {
  return new Promise((resolve: (value: string) => void) => {
    fs.readFile(filePath, (err: ErrnoException, data: Buffer) => {
      resolve(data.toString())
    })
  })
}
