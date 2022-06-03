import { ModelWrapper } from './modelWrapper'
import { CategoryModel } from './category.model'
import { ClientModel } from './client.model'
import { OrderModel } from './order.model'
import { PositionModel } from './position.model'
import { ProductModel } from './product.model'
import { StorageModel } from './storage.model'
import { WorkerModel } from './worker.model'

export const CategoryWrapper = new ModelWrapper(CategoryModel)
export const ClientWrapper = new ModelWrapper(ClientModel)
export const OrderWrapper = new ModelWrapper(OrderModel)
export const PositionWrapper = new ModelWrapper(PositionModel)
export const ProductWrapper = new ModelWrapper(ProductModel)
export const StorageWrapper = new ModelWrapper(StorageModel)
export const WorkerWrapper = new ModelWrapper(WorkerModel)
