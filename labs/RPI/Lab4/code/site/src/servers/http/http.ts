import * as fs from 'fs'
import * as http from 'http'
import { IncomingMessage } from 'http'
import { getFilePathByExtension } from '../../helpers/helpers'
import { FILE_PATHS, FileExtension, FileRoute, LogPath, Route } from '../../constants/constants'

let currentRoute = Route.home

const getResolvers: { [key: string]: () => string } = {
  [FileRoute.indexCss]: () => fs.readFileSync(getFilePathByExtension(FILE_PATHS[currentRoute], FileExtension.css)).toString(),
  [FileRoute.indexJs]: () => fs.readFileSync(getFilePathByExtension(FILE_PATHS[currentRoute], FileExtension.js)).toString(),
  [Route.first]: () => {
    currentRoute = Route.first
    fs.appendFileSync(LogPath.http, `FIRST --- ${new Date().toUTCString()}\n`)
    return fs.readFileSync(getFilePathByExtension(FILE_PATHS[currentRoute], FileExtension.html)).toString()
  },
  [Route.second]: () => {
    currentRoute = Route.second
    fs.appendFileSync(LogPath.http, `SECOND --- ${new Date().toUTCString()}\n`)
    return fs.readFileSync(getFilePathByExtension(FILE_PATHS[currentRoute], FileExtension.html)).toString()
  },
  [Route.home]: () => {
    currentRoute = Route.home
    fs.appendFileSync(LogPath.http, `HOME --- ${new Date().toUTCString()}\n`)
    return fs.readFileSync(getFilePathByExtension(FILE_PATHS[currentRoute], FileExtension.html)).toString()
  },
}

const process = (req: IncomingMessage, res: http.ServerResponse, jsonString: string) => {
  const parsedData = JSON.parse(jsonString)
  console.log(parsedData)
  res.end(JSON.stringify({
    receivedData: parsedData,
    message: 'success',
  }))
}

const handlePOSTRequest = (req: IncomingMessage, res: http.ServerResponse) => {
  let jsonString = ''

  req.on('data', (chunk: string) => jsonString += chunk)
  req.on('end', () => process(req, res, jsonString))
}

const requestListener = (req: IncomingMessage, res: http.ServerResponse) => {
  if (req.method === 'POST') {
    handlePOSTRequest(req, res)
  } else if (req.method === 'GET' && getResolvers[req.url]) {
    res.end(getResolvers[req.url]())
  } else {
    res.end('Wrong url, try "/"!')
  }
}

export const httpServer = http.createServer(requestListener)
