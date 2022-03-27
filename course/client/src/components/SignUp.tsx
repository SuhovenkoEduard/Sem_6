import React from 'react'
import { Navigate, useNavigate } from 'react-router-dom'
import { useIsAuthenticated, useSignIn } from 'react-auth-kit'
import { RoutesPaths } from '../constants/constants'
import { SignUpForm } from './sign/SignUpForm'
import { LongAccountData } from '../constants/types'
import { signUpAccount } from '../api/fakeApi'
import { generateUuid } from '../helpers/helpers'

export const SignUp = () => {
  const isAuthenticated = useIsAuthenticated()
  const signIn = useSignIn()
  const navigate = useNavigate()

  const onSignUp = (longAccountData: LongAccountData) => {
    signUpAccount(longAccountData)
    signIn({
      token: generateUuid(),
      tokenType: 'Bearer', // Token type set as Bearer
      authState: longAccountData.user,
      expiresIn: 120, // Token Expriration time, in minutes
    })
    navigate(RoutesPaths.catalog)
  }
  if (isAuthenticated()) {
    return (
      <Navigate to={RoutesPaths.catalog} replace />
    )
  }
  return (
    <SignUpForm
      goToHome={() => navigate(RoutesPaths.home)}
      goToSignIn={() => navigate(RoutesPaths.signIn)}
      onSignUp={onSignUp}
    />
  )
}
