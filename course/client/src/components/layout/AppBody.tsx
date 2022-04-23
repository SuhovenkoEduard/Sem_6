import React from 'react'

import { Navigate, Route, Routes } from 'react-router-dom'
import { RequireAuth } from 'react-auth-kit'
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

const securedRoute = (path: string, element: JSX.Element) => (
  <Route
    path={path}
    element={(<RequireAuth loginPath={RoutesPaths.signIn}>{element}</RequireAuth>)}
  />
)

export const AppBody = () => {
  return (
    <main className="app-body p-3">
      <Routes>
        <Route path={RoutesPaths.home} element={<HomePage />} />
        <Route path={RoutesPaths.catalog} element={<Catalog />} />
        <Route path={RoutesPaths.signIn} element={<SignIn />} />
        <Route path={RoutesPaths.signUp} element={<SignUp />} />
        {securedRoute(RoutesPaths.profile, <Profile />)}
        {securedRoute(RoutesPaths.clientMenu, <ClientMenu />)}
        {securedRoute(RoutesPaths.courierMenu, <CourierMenu />)}
        {securedRoute(RoutesPaths.managerMenu, <ManagerMenu />)}
        <Route path={RoutesPaths.any} element={<Navigate to={RoutesPaths.home} replace />} />
      </Routes>
    </main>
  )
}
