import express, { Request, Response } from 'express'
import { CookModel } from '../../models/cook.model'
import { ApiRoutes } from '../../../constants/constants'
import { CookPropNames } from '../../../constants/types'

export const cookApiRouter = express.Router()

cookApiRouter.get(ApiRoutes.getAll, (req: Request, res: Response) => {
  CookModel.findAll({}).then(data => res.json(data))
})

cookApiRouter.get(ApiRoutes.getSingle, (req: Request, res: Response) => {
  CookModel.findOne({
    where: { [CookPropNames.id]: +req.params.id },
  }).then(data => res.json(data))
})

cookApiRouter.post(ApiRoutes.postSingle, (req: Request, res: Response) => {
  CookModel.create({ ...req.body }).then(data => res.json(data))
})

cookApiRouter.put(ApiRoutes.putSingle, (req: Request, res: Response) => {
  CookModel.update({ ...req.body }, { where: { [CookPropNames.id]: +req.params.id } })
    .then(data => res.json(data))
})

cookApiRouter.delete(ApiRoutes.deleteSingle, (req: Request, res: Response) => {
  CookModel.destroy({ where: { [CookPropNames.id]: +req.params.id } })
    .then(data => res.json(data))
})
