export enum TableNames {
  pizzas = 'Pizzas',
  cooks = 'Cooks',
  restaurants = 'Restaurants',
}

export enum PizzaPropNames {
  id = 'pizzaId',
  name = 'name',
  caloric = 'caloric',
}

export enum CookPropNames {
  id = 'cookId',
  name = 'name',
  age = 'age',
  pizzaId = 'pizzaId',
  restaurantId = 'restaurantId',
}

export enum RestaurantPropNames {
  id = 'restaurantId',
  address = 'address',
  revenue = 'revenue',
}

export type Pizza = {
  [PizzaPropNames.id]: number
  [PizzaPropNames.name]: string
  [PizzaPropNames.caloric]: number
}

export type Cook = {
  [CookPropNames.id]: number
  [CookPropNames.name]: string
  [CookPropNames.age]: number
  [CookPropNames.pizzaId]: number
  [CookPropNames.restaurantId]: number
}

export type Restaurant = {
  [RestaurantPropNames.id]: number
  [RestaurantPropNames.address]: string
  [RestaurantPropNames.revenue]: number
}

export type TablesPropNames = {
  [key in TableNames]: string[]
}

export enum ResponseStatuses {
  error = 500,
  success = 200,
}
