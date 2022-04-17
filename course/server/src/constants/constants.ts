export const PATH_TO_DATABASE_DIR = './db'
export const PATH_TO_DATABASE = `${PATH_TO_DATABASE_DIR}/pizzeria.db`

export const SERVER_PORT = 4444
export const CLIENT_ERROR_STATUS_CODE = 400

export enum RoutesPaths {
  any = '*',
  base = '/',
  home = '/home',
  signIn = '/sign-in',
  signUp = '/sign-up',
  catalog = '/catalog',
}

export enum ApiRouters {
  api = '/api',
  getAll = '/',
  getSingle = '/:id',
  putSingle = '/:id',
  postSingle = '/',
  deleteSingle = '/:id',
}
