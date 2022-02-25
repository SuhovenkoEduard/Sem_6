import fs from 'fs'
import { ERRORS_LOG_DIRPATH } from '../constants'

export const logs = (filePath: string, options: object) => {
  if (!fs.existsSync(filePath)) {
    fs.mkdirSync(ERRORS_LOG_DIRPATH)
  }
  fs.writeFileSync(filePath, JSON.stringify(options, null, '  '))
}
