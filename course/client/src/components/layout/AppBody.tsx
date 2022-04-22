import React from 'react'

import { Navigate, Route, Routes } from 'react-router-dom'
import { RequireAuth } from 'react-auth-kit'
import { RoutesPaths } from '../../constants/constants'
import { HomePage } from '../pages/HomePage'
import { Catalog } from '../pages/Catalog'
import { SignIn } from '../sign/in/SignIn'
import { SignUp } from '../sign/up/SignUp'
import { Profile } from '../pages/Profile'

import '../../scss/components/layout/app-body.scss'

export const AppBody = () => {
  return (
    <main className="app-body">
      <Routes>
        <Route path={RoutesPaths.home} element={<HomePage />} />
        <Route path={RoutesPaths.catalog} element={<Catalog />} />
        <Route path={RoutesPaths.signIn} element={<SignIn />} />
        <Route path={RoutesPaths.signUp} element={<SignUp />} />
        <Route
          path={RoutesPaths.profile}
          element={(
            <RequireAuth loginPath={RoutesPaths.signIn}>
              <Profile />
            </RequireAuth>
          )}
        />
        <Route path={RoutesPaths.any} element={<Navigate to={RoutesPaths.home} replace />} />
      </Routes>
    </main>
  )
}
