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
  comments = '/comments',
  getAll = '/get-all',
  addOne = '/add-one',
  deleteOne = '/delete-one',
  // client
  clientMenu = '/menu/client',
  getOrdersByClientId = '/get-orders-by-client-id',
  declineOrder = '/decline-order',
  // courier
  courierMenu = '/menu/courier',
  getOrdersByCourierId = '/get-orders-by-courier-id',
  acceptOrder = '/accept-order',
  // manager
  managerMenu = '/menu/manager',
  getGroupedReports = '/get-grouped-reports',
  editCourierSalary = '/edit-courier-salary',
}


export enum ApiRouters {
  api = '/api',
  getAll = '/',
  getSingle = '/:id',
  putSingle = '/:id',
  postSingle = '/',
  deleteSingle = '/:id',
}
