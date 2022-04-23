import {
  AccountDTO, ClientDTO, CourierDTO, ManagerDTO, OrderDTO, PizzaDTO, StatusDTO,
} from './models'

export enum RequestMethod {
  get = 'GET',
  post = 'POST',
  put = 'PUT',
  delete = 'DELETE',
}

export type FetchRequest = {
  url: string
  method: RequestMethod
  body?: object | null
  headers?: { [key: string]: string }
}

export type AccountType = {
  email: string
  password: string
}

export type ClientType = {
  name: string
  phoneNumber: string
  description: string
}

export type UserType = {
  account: AccountDTO
  client?: ClientDTO
  courier?: CourierDTO
  manager?: ManagerDTO
}

export type CommentType = {
  id: number
  content: string
  date: string
  clientId: number
  clientName: string
}

export type OrderType = {
  clientId: number
  pizzaId: number
  address: string
  startDate: string
  endDate: string
}

export type FullOrder = OrderDTO & {
  client: ClientDTO
  courier: CourierDTO
  pizza: PizzaDTO
  status: StatusDTO
}
