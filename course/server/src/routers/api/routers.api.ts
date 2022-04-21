import express from 'express'
import { TableRoutes } from '../../constants/types'
import {
  AccountSchema,
  ClientSchema,
  CommentSchema,
  CourierSchema,
  ManagerSchema,
  OrderSchema,
  PizzaSchema,
  ReportSchema,
  StatusSchema,
} from '../../constants/schemas'
import {
  AccountModel,
  ClientModel,
  CommentModel,
  CourierModel,
  ManagerModel,
  OrderModel,
  PizzaModel,
  ReportModel,
  StatusModel,
} from '../../models/models'
import { generateApiRouter } from './generic.router'
import { ModelWrapper } from '../../models/modelWrapper'

type ModelData = {
  model: ModelWrapper
  identifierName: string
  route: TableRoutes
}

const models: ModelData[] = [
  { model: AccountModel, identifierName: AccountSchema.id, route: TableRoutes.accounts },
  { model: ClientModel, identifierName: ClientSchema.id, route: TableRoutes.clients },
  { model: CommentModel, identifierName: CommentSchema.id, route: TableRoutes.comments },
  { model: CourierModel, identifierName: CourierSchema.id, route: TableRoutes.couriers },
  { model: ManagerModel, identifierName: ManagerSchema.id, route: TableRoutes.managers },
  { model: OrderModel, identifierName: OrderSchema.id, route: TableRoutes.orders },
  { model: PizzaModel, identifierName: PizzaSchema.id, route: TableRoutes.pizzas },
  { model: ReportModel, identifierName: ReportSchema.id, route: TableRoutes.reports },
  { model: StatusModel, identifierName: StatusSchema.id, route: TableRoutes.statuses },
]

export const apiRouter = models.reduce((router: express.Router, {
  model,
  identifierName,
  route }: ModelData) => router.use(route, generateApiRouter(model, identifierName)), express.Router())
