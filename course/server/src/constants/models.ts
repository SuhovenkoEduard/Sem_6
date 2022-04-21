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

export type AccountDTO = IModel & {
  email: string
  passwordHash: string
}

export type ClientDTO = IUser & {
  name: string
  phoneNumber: string
  description: string
}

export type CourierDTO = IWorker & {
  name: string
  description: string
}

export type ManagerDTO = IWorker & {
  name: string
  description: string
}

export type CommentDTO = IModel & {
  clientId: number
  content: string
  date: string
}

export type OrderDTO = IModel & {
  pizzaId: number
  clientId: number
  courierId: number
  statusId: number
  address: string
  date: string
}

export type PizzaDTO = IModel & {
  name: string
  description: string
  price: number
  imageUrl: string
}

export type ReportDTO = IModel & {
  courierId: number
  date: string
  description: string
}

export type StatusDTO = IModel & {
  type: string
}

export interface DataValues<T> {
  dataValues: T
}

