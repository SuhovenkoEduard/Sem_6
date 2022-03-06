import { OperatingSystem, Tablet } from './types'

export type TabletsInfoListener = (tabletInfo: Tablet) => void

export interface IClient {
  updateTabletsInfo: TabletsInfoListener
  clearLogs: () => void
}

export interface IStore {
  notifyClients: () => void
  subscribeClient: (client: IClient) => void
  unsubscribeClient: (client: IClient) => void

  setOperatingSystem: (operatingSystem: OperatingSystem) => void
}
