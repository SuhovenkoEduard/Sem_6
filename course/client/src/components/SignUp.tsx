import React from 'react'
import { Navigate, useNavigate } from 'react-router-dom'
import { useIsAuthenticated, useSignIn } from 'react-auth-kit'
import { RoutesPaths } from '../constants/constants'
import { SignUpForm } from './sign/SignUpForm'
import { generateUuid } from '../helpers/helpers'
import { useFetch } from '../hooks/useFetch'
import { AccountType, ClientType } from '../constants/types'
import { ApiRouters, SERVER_URL, TableRoutes } from '../constants/api'
import { Account, Client } from '../constants/models'

export const SignUp = () => {
  const isAuthenticated = useIsAuthenticated()
  const signIn = useSignIn()
  const navigate = useNavigate()

  const {
    loading,
    request,
    error,
    clearError,
  } = useFetch()

  const onSignUp = async (clientData: ClientType & AccountType) => {
    clearError()
    try {
      const account: Account = await request(
        `${ApiRouters.api}${TableRoutes.accounts}${ApiRouters.postSingle}`,
        'POST',
        {
          email: clientData.email,
          passwordHash: clientData.password,
        },
      )

      const client: Client = await request(
        `${ApiRouters.api}${TableRoutes.clients}${ApiRouters.postSingle}`,
        'POST',
        {
          accountId: account.id,
          name: clientData.name,
          phoneNumber: clientData.phoneNumber,
          description: clientData.description,
        },
      )

      signIn({
        token: generateUuid(),
        tokenType: 'Bearer', // Token type set as Bearer
        authState: {
          user: {
            account,
            client,
          },
        },
        expiresIn: 120, // Token Expriration time, in minutes
      })
      navigate(RoutesPaths.catalog)
    } catch (e: any) {
      console.log(e.message)
    }
  }

  if (isAuthenticated()) {
    return (
      <Navigate to={RoutesPaths.catalog} replace />
    )
  }
  return (
    <>
      {error ?? `Error state ${error}`}
      <SignUpForm
        goToHome={() => navigate(RoutesPaths.home)}
        goToSignIn={() => navigate(RoutesPaths.signIn)}
        onSignUp={onSignUp}
      />
    </>
  )
}
