export const PATH_TO_DATABASE_DIR = './db'
export const PATH_TO_DATABASE = `${PATH_TO_DATABASE_DIR}/pizzeria.db`
export const PATH_TO_PUBLIC = './public'
export const PATH_TO_PUBLIC_IMAGES = `${PATH_TO_PUBLIC}/images`

export const SERVER_PORT = 4444
export const CLIENT_ERROR_STATUS_CODE = 400

export enum RoutesPaths {
  any = '*',
  root = '/',
  backend = '/backend',
  static = '/static',
  images = '/images',
  home = '/home',
  signIn = '/sign-in',
  signUp = '/sign-up',
  catalog = '/catalog',
  profile = '/profile',
}

export enum ApiRouters {
  api = '/api',
  getAll = '/',
  getSingle = '/:id',
  putSingle = '/:id',
  postSingle = '/',
  deleteSingle = '/:id',
}
