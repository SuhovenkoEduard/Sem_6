import React from 'react'
import { useIsAuthenticated, useSignIn } from 'react-auth-kit'
import { useNavigate, Navigate } from 'react-router-dom'
import { Button } from 'react-bootstrap'
import { SignInForm } from './SignInForm'
import { AccountType, UserType } from '../../../constants/types'
import { RoutesPaths } from '../../../constants/constants'
import { generateUuid } from '../../../helpers/helpers'
import { useFetch } from '../../../hooks/useFetch'
import { createSignInRequest } from '../../../api/api'

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
      const user: UserType = await request(createSignInRequest(accountData))
      signIn({
        token: generateUuid(),
        tokenType: 'Bearer', // Token type set as Bearer
        authState: user,
        expiresIn: 120, // Token Expriration time, in minutes
      })
      navigate(RoutesPaths.home)
    } catch (e: any) {
      console.log(e.message)
    }
  }

  if (isAuthenticated()) {
    return (
      <Navigate to={RoutesPaths.home} replace />
    )
  }

  return (
    loading ? (<div>Loading...</div>) : (
      error ? (
        <div className="mx-auto my-auto">
          <div>{`Error: ${error}`}</div>
          <Button variant="outline-danger" onClick={clearError}>
            Try Again
          </Button>
        </div>
      ) : (
        <SignInForm
          goToHome={() => navigate(RoutesPaths.home)}
          goToSignUp={() => navigate(RoutesPaths.signUp)}
          onSignIn={onSignIn}
        />
      )
    )
  )
}
