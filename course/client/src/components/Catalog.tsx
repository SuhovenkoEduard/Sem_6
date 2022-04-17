import React from 'react'
import { useAuthUser, useSignOut } from 'react-auth-kit'
import { UserType } from '../constants/types'

export const Catalog = () => {
  const signOut = useSignOut()
  const authUser = useAuthUser()

  const authedUser = authUser() as UserType
  return (
    <div>
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
      <button type="button" onClick={() => signOut()}>Sign Out!</button>
    </div>
  )
}
