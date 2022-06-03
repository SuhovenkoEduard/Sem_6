import express from 'express'
import { workerRouter } from './worker.router'
import { clientRouter } from './client.router'

export const specialRouter = express.Router()

specialRouter.use('/', workerRouter)
specialRouter.use('/', clientRouter)
