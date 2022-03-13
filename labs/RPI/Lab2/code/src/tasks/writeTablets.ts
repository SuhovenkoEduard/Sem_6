import { Tablet } from '../types'
import fs from 'fs'

export const writeTables = (filePath: string, tablets: Tablet[]) => {
  fs.writeFileSync(filePath, JSON.stringify(tablets, null, '  '))
}
