export const PATH_TO_DATABASE = './db/pizzeria.db'

export const SERVER_PORT = 4444
export const CLIENT_ERROR_STATUS_CODE = 400

export enum ApiRouters {
  api = '/api',
  getAll = '/',
  getSingle = '/:id',
  putSingle = '/:id',
  postSingle = '/',
  deleteSingle = '/:id',
}
