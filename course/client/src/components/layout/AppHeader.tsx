import React from 'react'
import { useIsAuthenticated, useSignOut } from 'react-auth-kit'
import { useNavigate } from 'react-router-dom'
import { RoutesPaths } from '../../constants/constants'

import '../../scss/components/layout/app-header.scss'

export const AppHeader = () => {
  const signOut = useSignOut()
  const navigate = useNavigate()
  const isAuthenticated = useIsAuthenticated()

  return (
    <header className="app-header">
      <button type="button" className="btn btn-lg btn-primary" onClick={() => navigate(RoutesPaths.home)}>Home</button>
      <button type="button" className="btn btn-lg btn-primary" onClick={() => navigate(RoutesPaths.catalog)}>Catalog</button>
      {!isAuthenticated() && (
        <>
          <button type="button" className="btn btn-lg btn-primary" onClick={() => navigate(RoutesPaths.signIn)}>Sign In</button>
          <button type="button" className="btn btn-lg btn-primary" onClick={() => navigate(RoutesPaths.signUp)}>Sign Up</button>
        </>
      )}
      {isAuthenticated() && (
        <>
          <button type="button" className="btn btn-lg btn-primary" onClick={() => navigate(RoutesPaths.profile)}>Profile</button>
          <button type="button" className="btn btn-lg btn-primary" onClick={() => signOut()}>Sign Out</button>
        </>
      )}
    </header>
  )
}
