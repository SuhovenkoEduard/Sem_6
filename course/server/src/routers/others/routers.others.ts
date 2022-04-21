import express from 'express'
import { RoutesPaths } from '../../constants/constants'
import { signInRouter } from './signIn.router'
import { signUpRouter } from './signUp.router'
import { catalogRouter } from './catalog.router'
import { commentsRouter } from './comments.router'

export const othersRouter = express.Router()

othersRouter.use(RoutesPaths.signIn, signInRouter)
othersRouter.use(RoutesPaths.signUp, signUpRouter)
othersRouter.use(RoutesPaths.catalog, catalogRouter)
othersRouter.use(RoutesPaths.comments, commentsRouter)
