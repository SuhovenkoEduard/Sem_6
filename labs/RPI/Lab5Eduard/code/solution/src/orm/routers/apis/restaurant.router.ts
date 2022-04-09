import express, { Request, Response } from 'express'
import { RestaurantModel } from '../../models/restaurant.model'
import { ApiRoutes } from '../../../constants/constants'
import { RestaurantPropNames } from '../../../constants/types'

export const restaurantApiRouter = express.Router()

restaurantApiRouter.get(ApiRoutes.getAll, (req: Request, res: Response) => {
  RestaurantModel.findAll({}).then(data => res.json(data))
})

restaurantApiRouter.get(ApiRoutes.getSingle, (req: Request, res: Response) => {
  RestaurantModel.findOne({
    where: { [RestaurantPropNames.id]: +req.params.id },
  }).then(data => res.json(data))
})

restaurantApiRouter.post(ApiRoutes.postSingle, (req: Request, res: Response) => {
  RestaurantModel.create({ ...req.body }).then(data => res.json(data))
})

restaurantApiRouter.put(ApiRoutes.putSingle, (req: Request, res: Response) => {
  RestaurantModel.update({ ...req.body }, { where: { [RestaurantPropNames.id]: +req.params.id } })
    .then(data => res.json(data))
})

restaurantApiRouter.delete(ApiRoutes.deleteSingle, (req: Request, res: Response) => {
  RestaurantModel.destroy({ where: { [RestaurantPropNames.id]: +req.params.id } })
    .then(data => res.json(data))
})
