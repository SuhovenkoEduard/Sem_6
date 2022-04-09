import { CookPropNames, PizzaPropNames, RestaurantPropNames, TableNames, TablesPropNames } from './types'

export const PATH_TO_DATABASE = '../db/pizza.db'

export enum ViewRoutes {
  view = '/view',
  add = '/add',
  getAll = '/',
  getSingle = '/single/:id',
  postSingle = '/',
  cooks = '/cooks',
  pizzas = '/pizzas',
  restaurants = '/view/restaurants',
}

export enum ApiRoutes {
  api = '/api',
  getAll = '/',
  getSingle = '/:id',
  putSingle = '/:id',
  postSingle = '/',
  deleteSingle = '/:id',
}

export enum TableRoutes {
  pizzas = '/pizzas',
  cooks = '/cooks',
  restaurants = '/restaurants',
}

export const tablesPropNames: TablesPropNames = {
  [TableNames.pizzas]: Object.values(PizzaPropNames),
  [TableNames.cooks]: Object.values(CookPropNames),
  [TableNames.restaurants]: Object.values(RestaurantPropNames),
}
