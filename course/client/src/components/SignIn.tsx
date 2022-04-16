import React from 'react'
import { useIsAuthenticated, useSignIn } from 'react-auth-kit'
import { useNavigate, Navigate } from 'react-router-dom'
import { SignInForm } from './sign/SignInForm'
import { AccountType } from '../constants/types'
import { RoutesPaths } from '../constants/constants'
import { generateUuid } from '../helpers/helpers'
import { Account, Client } from '../constants/models'
import { ApiRouters, TableRoutes } from '../constants/api'
import { useFetch } from '../hooks/useFetch'

export const SignIn = () => {
  const isAuthenticated = useIsAuthenticated()
  const signIn = useSignIn()
  const navigate = useNavigate()

  const {
    loading,
    request,
    error,
    clearError,
  } = useFetch()

  const onSignIn = async (accountData: AccountType) => {
    try {
      const accounts: Account[] = await request(`${ApiRouters.api}${TableRoutes.accounts}${ApiRouters.getAll}`)
      const account = accounts.find((account) => account.email === accountData.email
        && account.passwordHash === accountData.password)
      if (account) {
        const clients: Client[] = await request(`${ApiRouters.api}${TableRoutes.clients}${ApiRouters.getAll}`)
        const client = clients.find((client) => client.accountId === account.id)

        if (!client) {
          throw Error('No such client found.')
        }

        signIn({
          token: generateUuid(),
          tokenType: 'Bearer', // Token type set as Bearer
          authState: {
            ...client, clientId: client.id, ...account, accountId: account.id,
          },
          expiresIn: 120, // Token Expriration time, in minutes
        })
        navigate(RoutesPaths.catalog)
      } else throw Error('No such account found.')
    } catch (e: any) {
      // eslint-disable-next-line no-alert
      alert(`Error Occoured. Try Again ${e.message}`)
    }
  }

  if (isAuthenticated()) {
    return (
      <Navigate to={RoutesPaths.catalog} replace />
    )
  }
  return (
    <SignInForm
      goToHome={() => navigate(RoutesPaths.home)}
      goToSignUp={() => navigate(RoutesPaths.signUp)}
      onSignIn={onSignIn}
    />
  )
}
