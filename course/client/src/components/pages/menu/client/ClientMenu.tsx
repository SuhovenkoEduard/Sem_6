import React, { useCallback, useEffect, useState } from 'react'
import { Button } from 'react-bootstrap'
import { useAuthUser } from 'react-auth-kit'
import { useFetch } from '../../../../hooks/useFetch'
import {
  createDeclineOrderRequest,
  createGetOrdersByClientIdRequest,
} from '../../../../api/api'
import { FullOrder, UserType } from '../../../../constants/types'
import { ClientOrdersTable } from './ClientOrdersTable'

export const ClientMenu = () => {
  const {
    error, clearError, loading, request,
  } = useFetch()

  const authData = useAuthUser()
  const userData = authData() as UserType

  const [isHistoryShown, setIsHistoryShown] = useState<boolean>(false)
  const [orders, setOrders] = useState<FullOrder[]>([])

  const getOrdersAsync = useCallback(async (isRestoreNeeded?: boolean) => {
    clearError()
    try {
      // eslint-disable-next-line max-len
      const orders: FullOrder[] = await request(createGetOrdersByClientIdRequest(userData.client!.id, !isHistoryShown))
      setOrders(orders)
      return Promise.resolve()
    } catch (e: any) {
      console.log(e.message)
      if (isRestoreNeeded) setIsHistoryShown(!isHistoryShown)
      return Promise.reject()
    }
  }, [isHistoryShown])

  const declineOrderAsync = async (orderId: number) => {
    try {
      await request(createDeclineOrderRequest(orderId))
      return Promise.resolve()
    } catch (e: any) {
      console.log(e.message)
      return Promise.reject()
    }
  }

  const declineOrder = (orderId: number) => {
    declineOrderAsync(orderId).then(() => getOrdersAsync(false))
  }

  useEffect(() => { if (!error) getOrdersAsync() }, [isHistoryShown, error])

  return (
    <div>
      <div>
        {isHistoryShown
          ? <div>History</div>
          : <div>Pending orders</div>}
      </div>
      {loading && <div>Loading...</div>}
      {!loading && (
        <>
          {error && (
            <>
              <div>Something went wrong...</div>
              <Button variant="outline-danger" onClick={() => getOrdersAsync(false)}>Try again!</Button>
            </>
          )}
          <div>
            {isHistoryShown ? (
              <Button
                className="my-3"
                variant="outline-primary"
                disabled={!!error}
                onClick={() => setIsHistoryShown(false)}
              >
                Get pending orders
              </Button>
            ) : (
              <Button
                className="my-3"
                variant="outline-primary"
                disabled={!!error}
                onClick={() => setIsHistoryShown(true)}
              >
                Get history
              </Button>
            )}
          </div>
          {!error && (
            <ClientOrdersTable
              orders={orders}
              isHistoryShown={isHistoryShown}
              declineOrder={declineOrder}
            />
          )}
        </>
      )}
    </div>
  )
}
