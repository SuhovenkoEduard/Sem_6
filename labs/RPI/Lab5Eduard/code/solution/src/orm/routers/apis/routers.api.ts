import express from 'express'
import { pizzaApiRouter } from './pizza.router'
import { cookApiRouter } from './cook.router'
import { TableRoutes } from '../../../constants/constants'
import { restaurantApiRouter } from './restaurant.router'

export const ormApiRouter = express.Router()

ormApiRouter.use(TableRoutes.pizzas, pizzaApiRouter)
ormApiRouter.use(TableRoutes.cooks, cookApiRouter)
ormApiRouter.use(TableRoutes.restaurants, restaurantApiRouter)
