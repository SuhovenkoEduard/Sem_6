import express from 'express'
import { FILE_PATHS, FileExtension, FileRoute, LogPath, Route } from '../../constants/constants'
import { getFilePathByExtension } from '../../helpers/helpers'
import path from 'path'
import fs from 'fs'

let currentRoute = Route.home

export const expressServer = express()

expressServer.get(FileRoute.indexCss, (req: express.Request, res: express.Response) => {
  res.sendFile(path.resolve(getFilePathByExtension(FILE_PATHS[currentRoute], FileExtension.css)))
})

expressServer.get(FileRoute.indexJs, (req: express.Request, res: express.Response) => {
  res.sendFile(path.resolve(getFilePathByExtension(FILE_PATHS[currentRoute], FileExtension.js)))
})

expressServer.get(Route.home, (req: express.Request, res: express.Response) => {
  currentRoute = Route.home
  fs.appendFileSync(LogPath.express, `HOME --- ${new Date().toUTCString()}\n`)
  res.sendFile(path.resolve(getFilePathByExtension(FILE_PATHS[currentRoute], FileExtension.html)))
})

expressServer.get(Route.first, (req: express.Request, res: express.Response) => {
  currentRoute = Route.first
  fs.appendFileSync(LogPath.express, `FIRST --- ${new Date().toUTCString()}\n`)
  res.sendFile(path.resolve(getFilePathByExtension(FILE_PATHS[currentRoute], FileExtension.html)))
})

expressServer.get(Route.second, (req: express.Request, res: express.Response) => {
  currentRoute = Route.second
  fs.appendFileSync(LogPath.express, `SECOND --- ${new Date().toUTCString()}\n`)
  res.sendFile(path.resolve(getFilePathByExtension(FILE_PATHS[currentRoute], FileExtension.html)))
})

expressServer.get('*', (req: express.Request, res: express.Response) => {
  res.send('Wrong url, try "/"!')
})
