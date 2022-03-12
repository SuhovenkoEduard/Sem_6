import { Client } from './store/client'
import { Store } from './store/store'
import { OperatingSystem } from './constants/types'

const generateFilePath = (index: number, baseFilePath = './out/') => (`${baseFilePath}out${index}.json`)

const total = 3
const clients: Client[] = Array(total).fill(null).map((client, index) => new Client(generateFilePath(index + 1)))
const store: Store = new Store()

clients.forEach(client => {
  store.subscribeClient(client)
  client.clearLogs()
})

store.notifyClients()                               // 1. android
store.setOperatingSystem(OperatingSystem.ios)       // 2. ios
store.unsubscribeClient(clients[2])                 // unsubscribe second client
store.setOperatingSystem(OperatingSystem.windows)   // 3. windows
store.unsubscribeClient(clients[1])                 // unsubscribe third client
store.setOperatingSystem(OperatingSystem.android)   // 4. android
