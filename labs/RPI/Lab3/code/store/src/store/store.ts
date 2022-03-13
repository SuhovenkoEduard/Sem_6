import { CPU, Diagonal, LocalMemory, OperatingSystem, RandomAccessMemory, Resolution, Tablet } from '../constants/types'
import { IClient, IStore, TabletsInfoListener } from '../constants/interfaces'

export class Store implements IStore {
  tabletInfo: Tablet

  subscribers: TabletsInfoListener[]

  constructor() {
    this.tabletInfo = {
      diagonal: Diagonal._1280x720,
      CPU: CPU.snapdragon600,
      resolution: Resolution.seven,
      operatingSystem: OperatingSystem.android,
      randomAccessMemory: RandomAccessMemory.large,
      localMemory: LocalMemory.large,
    }
    this.subscribers = []
  }

  setOperatingSystem = (operatingSystem: OperatingSystem): void => {
    this.tabletInfo = {
      ...this.tabletInfo,
      operatingSystem,
    }
    this.notifyClients()
  }

  subscribeClient = (client: IClient): void => {
    if (this.subscribers.includes(client.updateTabletsInfo)) return
    this.subscribers.push(client.updateTabletsInfo)
  }

  unsubscribeClient = (client: IClient): void => {
    if (!this.subscribers.includes(client.updateTabletsInfo)) return
    this.subscribers = this.subscribers.filter(subscriber => subscriber != client.updateTabletsInfo)
  }

  notifyClients = (): void => {
    this.subscribers.forEach(subscriber => subscriber(this.tabletInfo))
  }
}
