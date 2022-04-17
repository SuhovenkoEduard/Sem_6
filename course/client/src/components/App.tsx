import React from 'react'
import { AuthProvider } from 'react-auth-kit'
import { RoutesResolver } from './RoutesResolver'

export const App = () => {
  return (
    <AuthProvider
      authName="_auth"
      authType="cookie"
    >
      <RoutesResolver />
    </AuthProvider>
  )
}
