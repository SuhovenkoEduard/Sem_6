import React from 'react'

type ErrorWrapperProps = {
  loading: boolean
  error: string
  children?: React.ReactChild | React.ReactChild[]
}

export const ErrorWrapper = (props: ErrorWrapperProps) => {
  const {
    loading,
    error,
    children,
  } = props

  return (
    <div className="error-wrapper">
      {loading ? (
        <div className="loading-label">Loading...</div>
      ) : (
        <div className="loaded-container">
          {error ? (
            <div className="error-container">
              <div className="error-label">Error</div>
              <div className="error-body">{error}</div>
            </div>
          ) : (
            <div className="content-container">
              {children}
            </div>
          )}
        </div>
      )}
    </div>
  )
}
