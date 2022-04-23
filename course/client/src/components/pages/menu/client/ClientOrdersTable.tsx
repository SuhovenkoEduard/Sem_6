import React from 'react'
import { Button, Table } from 'react-bootstrap'
import { FullOrder } from '../../../../constants/types'

type ClientOrdersTableProps = {
  orders: FullOrder[]
  isHistoryShown: boolean
  declineOrder: (orderId: number) => void
}

export const ClientOrdersTable = (props: ClientOrdersTableProps) => {
  const {
    orders,
    isHistoryShown,
    declineOrder,
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
              {!isHistoryShown && (
                <td>
                  <Button
                    className="mx-auto my-auto"
                    variant="outline-danger"
                    onClick={() => declineOrder(order.id)}
                  >
                    Decline
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
