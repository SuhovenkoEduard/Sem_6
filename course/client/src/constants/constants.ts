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
