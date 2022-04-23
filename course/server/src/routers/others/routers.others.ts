import express from 'express'
import { RoutesPaths } from '../../constants/constants'
import { signInRouter } from './signIn.router'
import { signUpRouter } from './signUp.router'
import { catalogRouter } from './catalog.router'
import { commentsRouter } from './comments.router'
import { clientMenuRouter } from './menu/clientMenu.router'
import { courierMenuRouter } from './menu/courierMenu.router'
import { managerMenuRouter } from './menu/managerMenu.router'

export const othersRouter = express.Router()

othersRouter.use(RoutesPaths.signIn, signInRouter)
othersRouter.use(RoutesPaths.signUp, signUpRouter)
othersRouter.use(RoutesPaths.catalog, catalogRouter)
othersRouter.use(RoutesPaths.comments, commentsRouter)
othersRouter.use(RoutesPaths.clientMenu, clientMenuRouter)
othersRouter.use(RoutesPaths.courierMenu, courierMenuRouter)
othersRouter.use(RoutesPaths.managerMenu, managerMenuRouter)
