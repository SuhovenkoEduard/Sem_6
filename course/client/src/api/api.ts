import { RoutesPaths } from '../constants/constants'
import {
  AcceptOrderRequestType,
  AccountType,
  ClientType,
  FetchRequest,
  OrderType,
  RequestMethod,
} from '../constants/types'

export const api = () => {}

export const createSignInRequest = (accountType: AccountType): FetchRequest => ({
  url: `${RoutesPaths.backend}${RoutesPaths.signIn}`,
  method: RequestMethod.post,
  body: accountType,
})

export const createSignUpRequest = (clientData: ClientType & AccountType): FetchRequest => ({
  url: `${RoutesPaths.backend}${RoutesPaths.signUp}`,
  method: RequestMethod.post,
  body: clientData,
})

export const createGetCatalogRequest = (): FetchRequest => ({
  url: `${RoutesPaths.backend}${RoutesPaths.catalog}`,
  method: RequestMethod.get,
})

export const createGetCommentsRequest = (): FetchRequest => ({
  url: `${RoutesPaths.backend}${RoutesPaths.comments}${RoutesPaths.getAll}`,
  method: RequestMethod.get,
})

export const createAddCommentsRequest = (comment: object): FetchRequest => ({
  url: `${RoutesPaths.backend}${RoutesPaths.comments}${RoutesPaths.addOne}`,
  method: RequestMethod.post,
  body: comment,
})

export const createDeleteCommentsRequest = (id: number): FetchRequest => ({
  url: `${RoutesPaths.backend}${RoutesPaths.comments}${RoutesPaths.deleteOne}`,
  method: RequestMethod.delete,
  body: { id },
})

export const createAddOrderRequest = (state: OrderType): FetchRequest => ({
  url: `${RoutesPaths.backend}${RoutesPaths.catalog}${RoutesPaths.addOne}`,
  method: RequestMethod.post,
  body: state,
})

// eslint-disable-next-line max-len
export const createGetOrdersByClientIdRequest = (clientId: number, isFilterApplied: boolean): FetchRequest => ({
  url: `${RoutesPaths.backend}${RoutesPaths.clientMenu}${RoutesPaths.getOrdersByClientId}`,
  method: RequestMethod.post,
  body: { clientId, isFilterApplied },
})

export const createDeclineOrderRequest = (orderId: number): FetchRequest => ({
  url: `${RoutesPaths.backend}${RoutesPaths.clientMenu}${RoutesPaths.declineOrder}`,
  method: RequestMethod.post,
  body: { id: orderId },
})

// eslint-disable-next-line max-len
export const createGetOrdersByCourierIdRequest = (courierId: number, isFilterApplied: boolean): FetchRequest => ({
  url: `${RoutesPaths.backend}${RoutesPaths.courierMenu}${RoutesPaths.getOrdersByCourierId}`,
  method: RequestMethod.post,
  body: { courierId, isFilterApplied },
})

export const createAcceptOrderRequest = (state: AcceptOrderRequestType): FetchRequest => ({
  url: `${RoutesPaths.backend}${RoutesPaths.courierMenu}${RoutesPaths.acceptOrder}`,
  method: RequestMethod.post,
  body: state,
})

export const createGetGroupedReportsRequest = (): FetchRequest => ({
  url: `${RoutesPaths.backend}${RoutesPaths.managerMenu}${RoutesPaths.getGroupedReports}`,
  method: RequestMethod.get,
})

// eslint-disable-next-line max-len
export const createEditCourierSalaryRequest = (courierId: number, salary: number): FetchRequest => ({
  url: `${RoutesPaths.backend}${RoutesPaths.managerMenu}${RoutesPaths.editCourierSalary}`,
  method: RequestMethod.post,
  body: { courierId, salary },
})
