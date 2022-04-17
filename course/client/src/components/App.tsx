import React from 'react'
import { AuthProvider } from 'react-auth-kit'
import { RoutesResolver } from './RoutesResolver'
import { AppHeader } from './AppHeader'

export const App = () => {
  return (
    <AuthProvider
      authName="_auth"
      authType="cookie"
    >
      <AppHeader />
      <RoutesResolver />
    </AuthProvider>
  )
}
