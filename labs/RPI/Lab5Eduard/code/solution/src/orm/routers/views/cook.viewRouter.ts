import express from 'express'
import { CookController } from '../../controllers/cook.controller'
import { ViewRoutes } from '../../../constants/constants'

export const cookViewRouter = express.Router()
cookViewRouter.get(ViewRoutes.getAll, CookController.getAll)
cookViewRouter.get(ViewRoutes.getSingle, CookController.getOne)

