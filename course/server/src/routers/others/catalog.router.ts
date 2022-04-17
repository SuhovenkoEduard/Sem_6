import express from 'express'
import { CLIENT_ERROR_STATUS_CODE, RoutesPaths } from '../../constants/constants'
import { PizzaModel } from '../../models/models'

export const catalogRouter = express.Router()

catalogRouter.get(RoutesPaths.root, async (req: express.Request, res: express.Response) => {
  try {
    const pizzas = await PizzaModel.findAll({})
    res.json(pizzas)
  } catch (e: any) {
    res.status(CLIENT_ERROR_STATUS_CODE).json({ message: e.message })
  }
})
