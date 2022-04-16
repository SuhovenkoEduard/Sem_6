import express, { Request, Response } from 'express'
import Sequelize from 'sequelize'
import { ApiRouters, CLIENT_ERROR_STATUS_CODE } from '../../constants/constants'
import { messages } from '../../constants/messages'

export const errorHandler = (reason: object, errorType: string, res: Response) =>
  res.status(CLIENT_ERROR_STATUS_CODE).json({ error: {
    header: messages.DATABASE_ERROR,
    type: errorType,
    body: reason,
  } })

export const generateApiRouter = (
  model: Sequelize.ModelCtor<Sequelize.Model>,
  identifierName: string) => {
  const apiRouter = express.Router()

  apiRouter.get(ApiRouters.getAll, (req: Request, res: Response) => {
    model.findAll({})
      .then(data => res.json(data))
      .catch(reason => errorHandler(reason, messages.DATABASE_ERROR_GET_ALL, res))
  })

  apiRouter.get(ApiRouters.getSingle, (req: Request, res: Response) => {
    model.findOne({
      where: { [identifierName]: +req.params.id },
    }).then(data => res.json(data))
      .catch(reason => errorHandler(reason, messages.DATABASE_ERROR_GET_ONE, res))
  })

  apiRouter.post(ApiRouters.postSingle, (req: Request, res: Response) => {
    model.create({ ...req.body })
      .then(data => res.json(data))
      .catch(reason => errorHandler(reason, messages.DATABASE_ERROR_ADD, res))
  })

  apiRouter.put(ApiRouters.putSingle, (req: Request, res: Response) => {
    model.update({ ...req.body }, { where: { [identifierName]: +req.params.id } })
      .then(data => res.json(data))
      .catch(reason => errorHandler(reason, messages.DATABASE_ERROR_UPDATE, res))
  })

  apiRouter.delete(ApiRouters.deleteSingle, (req: Request, res: Response) => {
    model.destroy({ where: { [identifierName]: +req.params.id } })
      .then(data => res.json(data))
      .catch(reason => errorHandler(reason, messages.DATABASE_ERROR_DELETE, res))
  })

  return apiRouter
}

