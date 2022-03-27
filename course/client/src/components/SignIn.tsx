import React from 'react'
import { useIsAuthenticated, useSignIn } from 'react-auth-kit'
import { useNavigate, Navigate } from 'react-router-dom'
import { SignInForm } from './sign/SignInForm'
import { ShortAccountData } from '../constants/types'
import { RoutesPaths } from '../constants/constants'
import { generateUuid } from '../helpers/helpers'
import { getAccountData } from '../api/fakeApi'

export const SignIn = () => {
  const isAuthenticated = useIsAuthenticated()
  const signIn = useSignIn()
  const navigate = useNavigate()

  const onSignIn = (shortAccountData: ShortAccountData) => {
    const longAccountData = getAccountData(shortAccountData)
    if (longAccountData) {
      signIn({
        token: generateUuid(),
        tokenType: 'Bearer', // Token type set as Bearer
        authState: longAccountData.user,
        expiresIn: 120, // Token Expriration time, in minutes
      })
      navigate(RoutesPaths.catalog)
    } else {
      // eslint-disable-next-line no-alert
      alert('Error Occoured. Try Again')
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
