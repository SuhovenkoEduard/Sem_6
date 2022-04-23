import React from 'react'
import { useAuthUser, useIsAuthenticated, useSignOut } from 'react-auth-kit'
import { useNavigate } from 'react-router-dom'
import { Button } from 'react-bootstrap'
import { RoutesPaths } from '../../constants/constants'
import { UserType } from '../../constants/types'

import '../../scss/components/layout/app-header.scss'

export const AppHeader = () => {
  const signOut = useSignOut()
  const navigate = useNavigate()
  const isAuthenticated = useIsAuthenticated()

  // menu
  const authData = useAuthUser()
  const userData = authData() as UserType
  const isLoggedIn = isAuthenticated()
  const isClientLogged = userData?.client
  const isCourierLogged = userData?.courier
  const isManagerLogged = userData?.manager

  return (
    <header className="app-header">
      {isLoggedIn && (
        <Button
          variant="outline-light"
          className="mx-5"
          onClick={() => {
            if (isClientLogged) navigate(RoutesPaths.clientMenu)
            if (isCourierLogged) navigate(RoutesPaths.courierMenu)
            if (isManagerLogged) navigate(RoutesPaths.managerMenu)
          }}
        >
          Menu
        </Button>
      )}
      <button type="button" className="btn btn-lg btn-primary" onClick={() => navigate(RoutesPaths.home)}>Home</button>
      <button type="button" className="btn btn-lg btn-primary" onClick={() => navigate(RoutesPaths.catalog)}>Catalog</button>
      {!isLoggedIn && (
        <>
          <button type="button" className="btn btn-lg btn-primary" onClick={() => navigate(RoutesPaths.signIn)}>Sign In</button>
          <button type="button" className="btn btn-lg btn-primary" onClick={() => navigate(RoutesPaths.signUp)}>Sign Up</button>
        </>
      )}
      {isLoggedIn && (
        <>
          <button type="button" className="btn btn-lg btn-primary" onClick={() => navigate(RoutesPaths.profile)}>Profile</button>
          <button type="button" className="btn btn-lg btn-primary" onClick={() => signOut()}>Sign Out</button>
        </>
      )}
    </header>
  )
}
