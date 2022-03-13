import { httpServer } from './servers/http/http'
import { expressServer } from './servers/express/express'
import { LogPath, Port } from './constants/constants'
import * as fs from 'fs'

fs.truncateSync(LogPath.http)
fs.truncateSync(LogPath.express)

httpServer.listen(Port.http, () => {
  console.log(`Http server listening on port ${Port.http}!`)
})

expressServer.listen(Port.express, () => {
  console.log(`Express server listening on port ${Port.express}!`)
})
