import express from 'express'
import { PizzaController } from '../../controllers/pizza.controller'
import { ViewRoutes } from '../../../constants/constants'

export const pizzaViewRouter = express.Router()
pizzaViewRouter.get(ViewRoutes.getAll, PizzaController.getAll)
pizzaViewRouter.get(ViewRoutes.getSingle, PizzaController.getOne)
pizzaViewRouter.get(ViewRoutes.add, PizzaController.openAddPage)
pizzaViewRouter.post(ViewRoutes.postSingle, PizzaController.addOne)

