export enum TableNames {
  accounts = 'accounts',
  clients = 'clients',
  comments = 'comments',
  couriers = 'couriers',
  managers = 'managers',
  orders = 'orders',
  pizzas = 'pizzas',
  reports = 'reports',
  statuses = 'statuses',
}

export const TableRoutes: {
  [key in TableNames]: string
} = {
  [TableNames.accounts]: '/accounts',
  [TableNames.clients]: '/clients',
  [TableNames.comments]: '/comments',
  [TableNames.couriers]: '/couriers',
  [TableNames.managers]: '/managers',
  [TableNames.orders]: '/orders',
  [TableNames.pizzas]: '/pizzas',
  [TableNames.reports]: '/reports',
  [TableNames.statuses]: '/statuses',
}

export const SERVER_PORT = 4444
export const SERVER_URL = `127.0.0.1:${SERVER_PORT}`
export const CLIENT_ERROR_STATUS_CODE = 400

export enum ApiRouters {
  api = '/api',
  getAll = '/',
  getSingle = '/:id',
  putSingle = '/:id',
  postSingle = '/',
  deleteSingle = '/:id',
}
