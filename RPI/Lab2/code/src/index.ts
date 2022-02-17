import { ERRORS_LOG_FILEPATH, INITIAL_TABLETS, RES_TABLETS_FILEPATH } from './constants'
import { logs } from './tasks/logs'
import { readTablets } from './tasks/readTablets'
import { writeTables } from './tasks/writeTablets'
import { inputString } from './inputUtils'

const main = async () => {
  const error = await inputString('Input error')
  const description = await inputString('Input description')
  const date = new Date().toDateString()
  logs(ERRORS_LOG_FILEPATH, {
    error,
    description,
    date,
  })
  writeTables(RES_TABLETS_FILEPATH, INITIAL_TABLETS)
  const tables = readTablets(RES_TABLETS_FILEPATH)
  console.log(tables)
}

main()

