import React from 'react'
import { Button } from 'react-bootstrap'

type ErrorWrapperProps = {
  loading: boolean
  error: string
  children?: React.ReactChild | React.ReactChild[]
  onRefresh: () => void
}

export const ErrorWrapper = (props: ErrorWrapperProps) => {
  const {
    loading,
    error,
    onRefresh,
    children,
  } = props

  return (
    <div className="error-wrapper w-100">
      {loading ? (
        <div className="loading-label">Loading...</div>
      ) : (
        <div className="loaded-container">
          {error ? (
            <div className="error-container w-100">
              <div className="error-label">Error</div>
              <div className="error-body">{error}</div>
              <div className="error-button-container">
                <Button
                  className="error-button mt-3"
                  variant="outline-danger"
                  onClick={onRefresh}
                >
                  Try again!
                </Button>
              </div>
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
