import { RoutesPaths } from '../constants/constants'
import {
  AccountType, ClientType, FetchRequest, RequestMethod,
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
