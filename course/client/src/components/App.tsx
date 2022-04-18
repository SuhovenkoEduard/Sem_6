import React from 'react'
import { AuthProvider } from 'react-auth-kit'
import { AppHeader } from './layout/AppHeader'
import { AppBody } from './layout/AppBody'
import { AppFooter } from './layout/AppFooter'

import '../scss/components/app.scss'

export const App = () => {
  return (
    <AuthProvider
      authName="_auth"
      authType="cookie"
    >
      <div className="app-container">
        <AppHeader />
        <AppBody />
        <AppFooter />
      </div>
    </AuthProvider>
  )
}
