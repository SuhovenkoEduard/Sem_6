import { ViewRoutes } from '../../../constants/constants'
import { cookViewRouter } from './cook.viewRouter'
import { pizzaViewRouter } from './pizza.viewRouter'
import express from 'express'

export const ormViewRouter = express.Router()

ormViewRouter.use(ViewRoutes.cooks, cookViewRouter)
ormViewRouter.use(ViewRoutes.pizzas, pizzaViewRouter)
