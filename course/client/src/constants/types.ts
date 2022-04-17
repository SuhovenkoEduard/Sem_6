import {
  Account, Client, Courier, Manager,
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
  account: Account
  client?: Client
  courier?: Courier
  manager?: Manager
}
