import fs from 'fs'
import { Tablet } from '../types'

export const readTablets = (filePath: string): Tablet[] => {
  const fileData: string = fs.readFileSync(filePath).toString()
  return JSON.parse(fileData)
}
