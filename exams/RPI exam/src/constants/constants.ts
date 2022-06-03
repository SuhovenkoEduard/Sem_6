export const PATH_TO_DATABASE_DIR = './db'
export const PATH_TO_DATABASE = `${PATH_TO_DATABASE_DIR}/factory.db`

export const SERVER_PORT = 3000
export const CLIENT_ERROR_STATUS_CODE = 400

export enum ApiRouters {
  api = '/api',
  getAll = '/',
  getSingle = '/:id',
  putSingle = '/:id',
  postSingle = '/',
  deleteSingle = '/:id',
}

export enum SpecialRouters {
  special = '/special',
  getFullWorkersInfo = '/getFullWorkersInfo',
  getFullClientInfo = '/getFullClientInfo',
}
