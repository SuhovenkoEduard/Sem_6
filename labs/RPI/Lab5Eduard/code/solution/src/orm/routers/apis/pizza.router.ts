import express, { Request, Response } from 'express'
import { PizzaModel } from '../../models/pizza.model'
import { ApiRoutes } from '../../../constants/constants'
import { PizzaPropNames } from '../../../constants/types'

export const pizzaApiRouter = express.Router()

pizzaApiRouter.get(ApiRoutes.getAll, (req: Request, res: Response) => {
  PizzaModel.findAll({}).then(data => res.json(data))
})

pizzaApiRouter.get(ApiRoutes.getSingle, (req: Request, res: Response) => {
  PizzaModel.findOne({
    where: { [PizzaPropNames.id]: +req.params.id },
  }).then(data => res.json(data))
})

pizzaApiRouter.post(ApiRoutes.postSingle, (req: Request, res: Response) => {
  PizzaModel.create({ ...req.body }).then(data => res.json(data))
})

pizzaApiRouter.put(ApiRoutes.putSingle, (req: Request, res: Response) => {
  PizzaModel.update({ ...req.body }, { where: { [PizzaPropNames.id]: +req.params.id } })
    .then(data => res.json(data))
})

pizzaApiRouter.delete(ApiRoutes.deleteSingle, (req: Request, res: Response) => {
  PizzaModel.destroy({ where: { [PizzaPropNames.id]: +req.params.id } })
    .then(data => res.json(data))
})
