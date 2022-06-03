import express, { Request, Response } from 'express'
import { SpecialRouters } from '../../constants/constants'
import { messages } from '../../constants/messages'
import { errorHandler } from '../api/generic.router'
import { CategoryWrapper, PositionWrapper, WorkerWrapper } from '../../models/models'

export const workerRouter = express.Router()

workerRouter.get(SpecialRouters.getFullWorkersInfo, async (req: Request, res: Response) => {
  try {
    const workers = await WorkerWrapper.findAll({})
    const positions = await PositionWrapper.findAll({})
    const categories = await CategoryWrapper.findAll({})
    res.json(workers.map((worker: any) => ({
      ...worker,
      position: positions.find((position: any) => position.id === worker.positionId),
      category: categories.find((category: any) => category.id === worker.categoryId),
    })))
  } catch (e: any) {
    errorHandler(e.message, messages.DATABASE_ERROR_GET_ALL, res)
  }
})
