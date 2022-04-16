import React from 'react'
import { useAuthUser, useSignOut } from 'react-auth-kit'

export const Catalog = () => {
  const signOut = useSignOut()
  const authUser = useAuthUser()

  const authedUser = authUser()
  return (
    <div>
      <p>{JSON.stringify(authedUser, null, '  ')}</p>
      <button type="button" onClick={() => signOut()}>Sign Out!</button>
    </div>
  )
}
