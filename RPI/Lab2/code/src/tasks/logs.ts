import fs from 'fs'

export const logs = (filePath: string, options: object) => {
  fs.writeFileSync(filePath, JSON.stringify(options, null, '  '))
}
