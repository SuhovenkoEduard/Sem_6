import { useState, useCallback } from 'react'

export const useFetch = () => {
  const [loading, setLoading] = useState<boolean>(false)
  const [error, setError] = useState<string>('')

  const clearError = () => setError('')

  const request = useCallback(async (
    url: string,
    method: 'GET' | 'POST' | 'PUT' | 'DELETE' = 'GET',
    body: object | null = null,
    headers: { [key: string]: string } = {},
  ) => {
    const handleError = (message: string) => {
      setLoading(false)
      setError(message)
      throw new Error(message)
    }

    setLoading(true)
    clearError()
    try {
      const processedBody = body ? JSON.stringify(body) : null
      const processedHeaders = body ? { ...headers, 'Content-Type': 'application/json' } : { ...headers }

      const response = await fetch(url, { method, body: processedBody, headers: processedHeaders })
      const data = await response.json()

      if (!response.ok) {
        return handleError(data.message || 'Something went wrong (fetch-hook).')
      }

      setLoading(false)
      return data
    } catch (e: any) {
      return handleError(e.message)
    }
  }, [])

  return {
    loading,
    request,
    error,
    clearError,
  }
}
