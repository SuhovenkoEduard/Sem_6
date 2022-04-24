import express from 'express'
import { CLIENT_ERROR_STATUS_CODE, RoutesPaths } from '../../../constants/constants'
import { ClientDTO, CourierDTO, OrderDTO, PizzaDTO, ReportDTO, StatusDTO } from '../../../constants/models'
import { ClientModel, CourierModel, OrderModel, PizzaModel, ReportModel, StatusModel } from '../../../models/models'
import { CourierSchema } from '../../../constants/schemas'

export const managerMenuRouter = express.Router()

managerMenuRouter.get(RoutesPaths.getGroupedReports, async (req: express.Request, res: express.Response) => {
  try {
    const reports: ReportDTO[] = await ReportModel.findAll({})
    const orders: OrderDTO[] = await OrderModel.findAll({})
    const pizzas: PizzaDTO[] = await PizzaModel.findAll({})
    const couriers: CourierDTO[] = await CourierModel.findAll({})
    const statuses: StatusDTO[] = await StatusModel.findAll({})
    const clients: ClientDTO[] = await ClientModel.findAll({})

    const mapShortOrderToFull = (shortOrder: OrderDTO) => ({
      ...shortOrder,
      pizza: pizzas.find(pizza => pizza.id === shortOrder.pizzaId),
      client: clients.find(client => client.id === shortOrder.clientId),
      status: statuses.find(status => status.id === shortOrder.statusId),
    })

    const groupedReports = couriers.map((courier) => {
      const filteredOrders = orders.filter(order => order.courierId === courier.id)
      const filteredReports = reports.filter(report => filteredOrders.some(order => order.id === report.orderId))
        .map(report => ({
          ...report,
          order: mapShortOrderToFull(orders.find(order => order.id === report.orderId)),
        }))
      return {
        courier,
        reports: filteredReports,
      }
    })

    res.json(groupedReports)
  } catch (e: any) {
    res.status(CLIENT_ERROR_STATUS_CODE).json({ message: e.message })
  }
})

managerMenuRouter.post(RoutesPaths.editCourierSalary, async (req: express.Request, res: express.Response) => {
  try {
    await CourierModel.update({
      [CourierSchema.salary]: req.body.salary,
    }, {
      where: {
        [CourierSchema.id]: req.body.courierId,
      },
    })
    res.json([])
  } catch (e: any) {
    res.status(CLIENT_ERROR_STATUS_CODE).json({ message: e.message })
  }
})
