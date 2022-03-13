import { IClient } from '../constants/interfaces'
import { Tablet } from '../constants/types'
import * as fs from 'fs'

export class Client implements IClient {
  filePath: string

  constructor(filePath: string) {
    this.filePath = filePath
  }

  updateTabletsInfo = (tabletInfo: Tablet): void => {
    const previousInfo = JSON.parse(fs.readFileSync(this.filePath).toString() || '[]')
    const newInfo = [...previousInfo, {
      tabletInfo,
      time: new Date().toUTCString(),
    }]
    fs.writeFileSync(this.filePath, JSON.stringify(newInfo, null, '  '))
  }

  clearLogs = (): void => {
    fs.truncateSync(this.filePath)
  }
}
