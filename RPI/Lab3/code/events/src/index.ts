import EventEmitter from 'events'
import * as fs from 'fs'

class MyEmitter extends EventEmitter {}

const myEmitter = new MyEmitter()

myEmitter.on('event', (data: unknown[]) => {
  const currentLogs = JSON.parse(fs.readFileSync('./out/out.json').toString() || '[]')
  fs.writeFileSync('./out/out.json', JSON.stringify([
    ...currentLogs,
    {
      data: JSON.stringify(data),
      time: new Date().toUTCString(),
      author: 'Eduard',
    },
  ], null, '  '))
})

fs.truncateSync('./out/out.json')
console.log('Program started, out.json was cleared.')
myEmitter.emit('event', [0, 0, 0, 0, 0])
setTimeout(() => myEmitter.emit('event', [1]), 1000)
setTimeout(() => myEmitter.emit('event', [1, 2]), 2000)
setTimeout(() => myEmitter.emit('event', [1, 2, 3]), 3000)
