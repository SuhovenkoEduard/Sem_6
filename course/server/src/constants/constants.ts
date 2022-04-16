export const PATH_TO_DATABASE = './db/pizzeria.db'

export const SERVER_PORT = 4444

export enum ApiRouters {
  api = '/api',
  getAll = '/',
  getSingle = '/:id',
  putSingle = '/:id',
  postSingle = '/',
  deleteSingle = '/:id',
}
