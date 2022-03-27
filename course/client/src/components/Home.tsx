import React from 'react'
import { useNavigate } from 'react-router-dom'
import { RoutesPaths } from '../constants/constants'

export const Home = () => {
  const navigate = useNavigate()
  return (
    <div>
      <button type="button" onClick={() => navigate(RoutesPaths.signIn)}>Go to Login</button>
      <button type="button" onClick={() => navigate(RoutesPaths.catalog)}>GO to Secure Dashboard</button>
    </div>
  )
}
