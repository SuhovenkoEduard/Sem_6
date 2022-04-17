import * as fs from 'fs'
import request from 'request'
import { PATH_TO_PUBLIC_IMAGES } from '../constants/constants'

export const downloadImage = (uri: string, filePath: string, callback: () => void = () => {}) => {
  request.head(uri, function (err: any, res: request.Response) {
    console.log('content-type:', res.headers['content-type'])
    console.log('content-length:', res.headers['content-length'])

    request(uri).pipe(fs.createWriteStream(filePath)).on('close', callback)
  })
}

export const downloadAllImages = (imgInfos: { fileName: string, url: string }[], callback = () => console.log('Successfully downloaded.')) => {
  imgInfos.forEach(({ fileName, url }) => downloadImage(url, `${PATH_TO_PUBLIC_IMAGES}/${fileName}.jpg`))
  callback()
}
