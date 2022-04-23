import React from 'react'
import { Navigate, useNavigate } from 'react-router-dom'
import { useIsAuthenticated, useSignIn } from 'react-auth-kit'
import { Button } from 'react-bootstrap'
import { RoutesPaths } from '../../../constants/constants'
import { SignUpForm } from './SignUpForm'
import { generateUuid } from '../../../helpers/helpers'
import { useFetch } from '../../../hooks/useFetch'
import { AccountType, ClientType, UserType } from '../../../constants/types'
import { createSignUpRequest } from '../../../api/api'

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
      const user: UserType = await request(createSignUpRequest(clientData))
      signIn({
        token: generateUuid(),
        tokenType: 'Bearer', // Token type set as Bearer
        authState: user,
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
    loading ? (<div>Loading...</div>) : (
      error ? (
        <div className="mx-auto my-auto">
          <div>{`Error: ${error}`}</div>
          <Button variant="outline-danger" onClick={clearError}>
            Try Again
          </Button>
        </div>
      ) : (
        <SignUpForm
          goToHome={() => navigate(RoutesPaths.home)}
          goToSignIn={() => navigate(RoutesPaths.signIn)}
          onSignUp={onSignUp}
        />
      )
    )
  )
}
