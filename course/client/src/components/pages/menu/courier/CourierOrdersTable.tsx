import React from 'react'
import { Button, Table } from 'react-bootstrap'
import { FullOrder } from '../../../../constants/types'

type CourierOrdersTableProps = {
  orders: FullOrder[]
  isHistoryShown: boolean
  acceptOrder: (orderId: number) => void
}

export const CourierOrdersTable = (props: CourierOrdersTableProps) => {
  const {
    orders,
    isHistoryShown,
    acceptOrder,
  } = props

  return (
    <div>
      <Table bordered>
        <thead>
          <tr>
            <th>Pizza Name</th>
            <th>Price</th>
            <th>Client Name</th>
            <th>Courier Name</th>
            <th>Status</th>
            <th>Address</th>
            <th>Start Date</th>
            <th>End Date</th>
            {isHistoryShown && (
              <>
                <th>Report Date</th>
                <th>Report Description</th>
              </>
            )}
            {!isHistoryShown && <th>Actions</th>}
          </tr>
        </thead>
        <tbody>
          {orders.map((order: FullOrder) => (
            <tr key={order.id}>
              <td>{order.pizza.name}</td>
              <td>{`${order.pizza.price}$`}</td>
              <td>{order.client.name}</td>
              <td>{order.courier.name}</td>
              <td>{order.status.type}</td>
              <td>{order.address}</td>
              <td>{order.startDate}</td>
              <td>{order.endDate}</td>
              {isHistoryShown && (
                <>
                  <td>{order.report?.date}</td>
                  <td>{order.report?.description}</td>
                </>
              )}
              {!isHistoryShown && (
                <td>
                  <Button
                    className="mx-auto my-auto"
                    variant="outline-success"
                    onClick={() => acceptOrder(order.id)}
                  >
                    Accept
                  </Button>
                </td>
              )}
            </tr>
          ))}
        </tbody>
      </Table>
    </div>
  )
}
