import { ModelWrapper } from './modelWrapper'
import { AccountModel as AccountM } from './account.model'
import { ClientModel as ClientM } from './client.model'
import { CommentModel as CommentM } from './comment.model'
import { CourierModel as CourierM } from './courier.model'
import { ManagerModel as ManagerM } from './manager.model'
import { OrderModel as OrderM } from './order.model'
import { PizzaModel as PizzaM } from './pizza.model'
import { ReportModel as ReportM } from './report.model'
import { StatusModel as StatusM } from './status.model'

export const AccountModel = new ModelWrapper(AccountM)
export const ClientModel = new ModelWrapper(ClientM)
export const CommentModel = new ModelWrapper(CommentM)
export const CourierModel = new ModelWrapper(CourierM)
export const ManagerModel = new ModelWrapper(ManagerM)
export const OrderModel = new ModelWrapper(OrderM)
export const PizzaModel = new ModelWrapper(PizzaM)
export const ReportModel = new ModelWrapper(ReportM)
export const StatusModel = new ModelWrapper(StatusM)

