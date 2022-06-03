import express from 'express'
import { TableRoutes } from '../../constants/types'
import {
  CategoryWrapper,
  ClientWrapper,
  OrderWrapper,
  PositionWrapper,
  ProductWrapper,
  StorageWrapper,
  WorkerWrapper,
} from '../../models/models'
import { generateApiRouter } from './generic.router'
import { ModelWrapper } from '../../models/modelWrapper'

type ModelData = {
  model: ModelWrapper
  identifierName: string
  route: TableRoutes
}

const models: ModelData[] = [
  { model: CategoryWrapper, identifierName: 'id', route: TableRoutes.categories },
  { model: ClientWrapper, identifierName: 'id', route: TableRoutes.clients },
  { model: OrderWrapper, identifierName: 'id', route: TableRoutes.orders },
  { model: PositionWrapper, identifierName: 'id', route: TableRoutes.positions },
  { model: ProductWrapper, identifierName: 'id', route: TableRoutes.products },
  { model: StorageWrapper, identifierName: 'id', route: TableRoutes.storages },
  { model: WorkerWrapper, identifierName: 'id', route: TableRoutes.workers },
]

export const apiRouter = models.reduce((router: express.Router, {
  model,
  identifierName,
  route }: ModelData) => router.use(route, generateApiRouter(model, identifierName)), express.Router())
