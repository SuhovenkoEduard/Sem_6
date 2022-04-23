import React, { useCallback, useEffect, useState } from 'react'
import { useAuthUser } from 'react-auth-kit'
import { Button, Form } from 'react-bootstrap'
import { useFetch } from '../../../../hooks/useFetch'
import { AcceptOrderRequestType, FullOrder, UserType } from '../../../../constants/types'
import {
  createAcceptOrderRequest,
  createGetOrdersByCourierIdRequest,
} from '../../../../api/api'
import { CourierOrdersTable } from './CourierOrdersTable'
import { PizzaModal } from '../../../../common/PizzaModal'
import { FormInput } from '../../../../common/FormInput'
import { FormText } from '../../../../common/FormText'

type AcceptState = {
  description: string
  date: string
}

const getDefaultAcceptState = (): AcceptState => ({
  description: '',
  date: new Date().toUTCString(),
})

export const CourierMenu = () => {
  const {
    error, clearError, loading, request,
  } = useFetch()

  const authData = useAuthUser()
  const userData = authData() as UserType

  const [isHistoryShown, setIsHistoryShown] = useState<boolean>(false)
  const [orders, setOrders] = useState<FullOrder[]>([])
  const [selectedOrder, setSelectedOrder] = useState<FullOrder | null>(null)

  const getOrdersAsync = useCallback(async (isRestoreNeeded?: boolean) => {
    clearError()
    try {
      // eslint-disable-next-line max-len
      const orders: FullOrder[] = await request(createGetOrdersByCourierIdRequest(userData.courier!.id, !isHistoryShown))
      setOrders(orders)
      return Promise.resolve()
    } catch (e: any) {
      console.log(e.message)
      if (isRestoreNeeded) setIsHistoryShown(!isHistoryShown)
      return Promise.reject()
    }
  }, [isHistoryShown])

  const acceptOrderAsync = async (state: AcceptOrderRequestType) => {
    try {
      await request(createAcceptOrderRequest(state))
      return Promise.resolve()
    } catch (e: any) {
      console.log(e.message)
      return Promise.reject()
    }
  }

  useEffect(() => { if (!error) getOrdersAsync() }, [isHistoryShown, error])

  // accept state
  const [isAcceptOrderModalShown, setIsAcceptOrderModalShown] = useState<boolean>(false)
  const [acceptState, setAcceptState] = useState<AcceptState | null>(null)

  const onAcceptFormChange = (propName: string, value: string) => {
    setAcceptState({ ...acceptState!, [propName]: value })
  }

  const onAcceptModalCancel = () => {
    setIsAcceptOrderModalShown(false)
  }

  const onSubmit = (e: React.SyntheticEvent) => {
    e.preventDefault()
    const requestState: AcceptOrderRequestType = {
      orderId: selectedOrder!.id,
      courierId: userData.courier!.id,
      description: acceptState!.description,
      date: acceptState!.date,
    }
    acceptOrderAsync(requestState).then(() => {
      getOrdersAsync(false)
      setIsAcceptOrderModalShown(false)
      setAcceptState(null)
      setSelectedOrder(null)
    })
  }

  const acceptOrder = (orderId: number) => {
    setAcceptState(getDefaultAcceptState())
    setSelectedOrder(orders.find((order) => order.id === orderId)!)
    setIsAcceptOrderModalShown(true)
  }

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
                variant="outline-primary"
                disabled={!!error}
                onClick={() => {
                  setIsHistoryShown(false)
                }}
              >
                Get pending orders
              </Button>
            ) : (
              <Button
                variant="outline-primary"
                disabled={!!error}
                onClick={() => {
                  setIsHistoryShown(true)
                }}
              >
                Get history
              </Button>
            )}
          </div>
          {!error && (
            <CourierOrdersTable
              orders={orders}
              isHistoryShown={isHistoryShown}
              acceptOrder={acceptOrder}
            />
          )}
        </>
      )}
      {acceptState && selectedOrder && (
        <PizzaModal
          isModalShown={isAcceptOrderModalShown}
          onCancel={onAcceptModalCancel}
          modalTitle="Accept order and write report."
        >
          <Form onSubmit={onSubmit}>
            <FormText label="Pizza Name" value={selectedOrder!.pizza.name} />
            <FormText label="Client Name" value={selectedOrder!.client.name} />
            <FormText label="Courier Name" value={selectedOrder!.courier.name} />
            <FormText label="Status" value={selectedOrder!.status.type} />
            <FormText label="Address" value={selectedOrder!.address} />
            <FormText label="Start Date" value={selectedOrder!.startDate} />
            <FormText label="End Date" value={selectedOrder!.endDate} />
            <FormInput
              name="description"
              label="Description"
              value={acceptState!.description}
              onChange={onAcceptFormChange}
            />
            <FormText
              label="Report Date"
              value={acceptState!.date}
            />
            {error && (
              <>
                <FormText
                  label="Error"
                  value="Something went wrong..."
                />
                <Button type="submit" className="mt-2 mx-3" variant="outline-danger" onClick={onSubmit}>
                  Try again!
                </Button>
              </>
            )}
            <Button disabled={loading || !!error} variant="outline-primary" className="mt-2" type="submit">
              Save
            </Button>
          </Form>
        </PizzaModal>
      )}
    </div>
  )
}
