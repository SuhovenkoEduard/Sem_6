import * as fs from 'fs'
import { PATH_TO_DATABASE_DIR } from '../constants/constants'
import { ACCOUNTS } from '../constants/accounts'

export const generateAccountsJson = () =>
  fs.writeFileSync(`${PATH_TO_DATABASE_DIR}/accounts.json`, JSON.stringify(ACCOUNTS, null, '  '))

