import React from 'react'
import { RequireAuth } from 'react-auth-kit'
import {
  BrowserRouter, Route, Routes, Navigate,
} from 'react-router-dom'
import { Home } from './Home'
import { SignIn } from './SignIn'
import { SignUp } from './SignUp'
import { Catalog } from './Catalog'
import { RoutesPaths } from '../constants/constants'

export const RoutesResolver = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route path={RoutesPaths.home} element={<Home />} />
        <Route path={RoutesPaths.signIn} element={<SignIn />} />
        <Route path={RoutesPaths.signUp} element={<SignUp />} />
        <Route
          path={RoutesPaths.catalog}
          element={(
            <RequireAuth loginPath={RoutesPaths.signIn}>
              <Catalog />
            </RequireAuth>
        )}
        />
        <Route path={RoutesPaths.any} element={<Navigate to={RoutesPaths.home} replace />} />
      </Routes>
    </BrowserRouter>
  )
}
