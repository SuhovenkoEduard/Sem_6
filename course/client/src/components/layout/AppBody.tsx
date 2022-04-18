import React from 'react'
import { RoutesResolver } from '../RoutesResolver'

import '../../scss/components/layout/app-body.scss'

export const AppBody = () => {
  return (
    <main className="app-body">
      <RoutesResolver />
    </main>
  )
}
