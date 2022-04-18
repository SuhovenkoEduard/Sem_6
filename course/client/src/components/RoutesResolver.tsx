import React from 'react'
import { RequireAuth } from 'react-auth-kit'
import {
  BrowserRouter, Route, Routes, Navigate,
} from 'react-router-dom'
import { Home } from './pages/Home'
import { SignIn } from './sign/in/SignIn'
import { SignUp } from './sign/up/SignUp'
import { Catalog } from './pages/Catalog'
import { RoutesPaths } from '../constants/constants'
import { Profile } from './pages/Profile'

export const RoutesResolver = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route path={RoutesPaths.home} element={<Home />} />
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
    </BrowserRouter>
  )
}
