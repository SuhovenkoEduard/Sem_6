import { CookPropNames, PizzaPropNames, RestaurantPropNames, TableNames, TablesPropNames } from './types'

export const PATH_TO_DATABASE = '../db/pizza.db'

export enum Routes {
  api = '/api',
  getAll = '/',
  getSingle = '/:id',
  putSingle = '/:id',
  postSingle = '/',
  deleteSingle = '/:id',
}

export const tablesPropNames: TablesPropNames = {
  [TableNames.pizzas]: Object.values(PizzaPropNames),
  [TableNames.cooks]: Object.values(CookPropNames),
  [TableNames.restaurants]: Object.values(RestaurantPropNames),
}
