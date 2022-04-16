export enum AccountSchema {
  id = 'id',
  email = 'email',
  password = 'passwordHash',
}

export enum ClientSchema {
  id = 'id',
  accountId = 'accountId',
  name = 'name',
  phone = 'phoneNumber',
  description = 'description',
}

export enum CommentSchema {
  id = 'id',
  clientId = 'clientId',
  content = 'content',
  date = 'date',
}

export enum CourierSchema {
  id = 'id',
  accountId = 'accountId',
  name = 'name',
  salary = 'salary',
  description = 'description',
}

export enum ManagerSchema {
  id = 'id',
  accountId = 'accountId',
  name = 'name',
  salary = 'salary',
  description = 'description',
}

export enum OrderSchema {
  id = 'id',
  pizzaId = 'pizzaId',
  clientId = 'clientId',
  courierId = 'courierId',
  statusId = 'statusId',
  address = 'address',
  date = 'date',
}

export enum PizzaSchema {
  id = 'id',
  name = 'name',
  description = 'description',
  price = 'price',
  imageUrl = 'imageUrl',
}

export enum ReportSchema {
  id = 'id',
  courierId = 'courierId',
  date = 'date',
  description = 'description',
}

export enum StatusSchema {
  id = 'id',
  type = 'type',
}
