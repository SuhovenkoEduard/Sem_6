import { RoutesPaths } from '../constants/constants'
import {
  AccountType, ClientType, FetchRequest, RequestMethod,
} from '../constants/types'

export const api = () => {}

export const createSignInRequest = (accountType: AccountType): FetchRequest => ({
  url: RoutesPaths.signIn,
  method: RequestMethod.post,
  body: accountType,
})

export const createSignUpRequest = (clientData: ClientType & AccountType): FetchRequest => ({
  url: RoutesPaths.signUp,
  method: RequestMethod.post,
  body: clientData,
})
