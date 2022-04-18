import React from 'react'
import { useNavigate } from 'react-router-dom'
import { useIsAuthenticated, useSignOut } from 'react-auth-kit'
import { RoutesPaths } from '../../constants/constants'

export const Home = () => {
  const signOut = useSignOut()
  const navigate = useNavigate()
  const isAuthenticated = useIsAuthenticated()

  return (
    <div>
      <div>Home</div>
      {!isAuthenticated() && (
        <>
          <button type="button" onClick={() => navigate(RoutesPaths.signIn)}>Login</button>
          <button type="button" onClick={() => navigate(RoutesPaths.signUp)}>Register</button>
        </>
      )}
      <button type="button" onClick={() => navigate(RoutesPaths.catalog)}>Catalog</button>
      {isAuthenticated() && (
        <>
          <button type="button" onClick={() => navigate(RoutesPaths.profile)}>Profile</button>
          <button type="button" onClick={() => signOut()}>Sign Out!</button>
        </>
      )}
    </div>
  )
}
