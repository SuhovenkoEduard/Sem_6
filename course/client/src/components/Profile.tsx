import React from 'react'
import { useAuthUser, useSignOut } from 'react-auth-kit'
import { useNavigate } from 'react-router-dom'
import { UserType } from '../constants/types'
import { RoutesPaths } from '../constants/constants'

export const Profile = () => {
  const navigate = useNavigate()
  const signOut = useSignOut()
  const authUser = useAuthUser()
  const authedUser = authUser() as UserType

  return (
    <>
      <div>Account</div>
      <div>{JSON.stringify(authedUser.account, null, '  ')}</div>
      {authedUser?.client && (
        <>
          <div>Client</div>
          <div>{JSON.stringify(authedUser.client, null, '  ')}</div>
        </>
      )}
      {authedUser?.courier && (
        <>
          <div>Courier</div>
          <div>{JSON.stringify(authedUser.courier, null, '  ')}</div>
        </>
      )}
      {authedUser?.manager && (
        <>
          <div>Manager</div>
          <div>{JSON.stringify(authedUser.manager, null, '  ')}</div>
        </>
      )}
      <button type="button" onClick={() => navigate(RoutesPaths.catalog)}>Catalog</button>
      <button type="button" onClick={() => navigate(RoutesPaths.home)}>Home</button>
      <button type="button" onClick={() => signOut()}>Sign Out!</button>
    </>
  )
}
