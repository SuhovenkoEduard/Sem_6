import React from 'react'

import { Navigate, Route, Routes } from 'react-router-dom'
import { RequireAuth, useAuthUser, useIsAuthenticated } from 'react-auth-kit'
import { RoutesPaths } from '../../constants/constants'
import { HomePage } from '../pages/HomePage'
import { Catalog } from '../pages/Catalog'
import { SignIn } from '../sign/in/SignIn'
import { SignUp } from '../sign/up/SignUp'
import { Profile } from '../pages/Profile'
import { ClientMenu } from '../pages/menu/client/ClientMenu'
import { CourierMenu } from '../pages/menu/courier/CourierMenu'
import { ManagerMenu } from '../pages/menu/manager/ManagerMenu'

import '../../scss/components/layout/app-body.scss'
import { UserType } from '../../constants/types'

const securedRoute = (path: string, element: JSX.Element) => (
  <Route
    path={path}
    element={(<RequireAuth loginPath={RoutesPaths.signIn}>{element}</RequireAuth>)}
  />
)

export const AppBody = () => {
  const isAuthenticated = useIsAuthenticated()
  const authData = useAuthUser()
  const userData = authData() as UserType

  const isLogged = isAuthenticated()
  const isClient = isLogged && !!userData.client
  const isCourier = isLogged && !!userData.courier
  const isManager = isLogged && !!userData.manager

  return (
    <main className="app-body p-3">
      <Routes>
        <Route path={RoutesPaths.home} element={<HomePage />} />
        <Route path={RoutesPaths.catalog} element={<Catalog />} />
        <Route path={RoutesPaths.signIn} element={<SignIn />} />
        <Route path={RoutesPaths.signUp} element={<SignUp />} />
        {isLogged && securedRoute(RoutesPaths.profile, <Profile />)}
        {isClient && securedRoute(RoutesPaths.clientMenu, <ClientMenu />)}
        {isCourier && securedRoute(RoutesPaths.courierMenu, <CourierMenu />)}
        {isManager && securedRoute(RoutesPaths.managerMenu, <ManagerMenu />)}
        <Route path={RoutesPaths.any} element={<Navigate to={RoutesPaths.home} replace />} />
      </Routes>
    </main>
  )
}
