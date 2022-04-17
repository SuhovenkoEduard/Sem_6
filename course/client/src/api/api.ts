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
