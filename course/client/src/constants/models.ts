export interface IModel {
  id: number
}

export interface IUser extends IModel {
  accountId: number
}

export interface IWorker extends IUser {
  name: string
  salary: number
}

export type Account = IModel & {
  email: string
  passwordHash: string
}

export type Client = IUser & {
  phoneNumber: string
  description: string
}

export type Courier = IWorker & {
  description: string
}

export type Manager = IWorker & {
  description: string
}

export type Comment = IModel & {
  clientId: number
  content: string
  date: string
}

export type Order = IModel & {
  pizzaId: number
  clientId: number
  courierId: number
  statusId: number
  address: string
  date: string
}

export type Pizza = IModel & {
  name: string
  description: string
  price: number
  imageUrl: string
}

export type Report = IModel & {
  courierId: number
  date: string
  description: string
}

export type Status = IModel & {
  type: string
}
