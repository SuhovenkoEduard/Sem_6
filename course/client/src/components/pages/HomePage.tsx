import React from 'react'
import { Comments } from './Comments'

import '../../scss/components/pages/home-page.scss'

export const HomePage = () => {
  return (
    <div className="home-page-container">
      <div className="home-page-container__header mx-auto">Home</div>
      <Comments />
    </div>
  )
}
