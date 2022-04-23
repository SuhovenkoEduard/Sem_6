import express from 'express'
import { CLIENT_ERROR_STATUS_CODE, RoutesPaths } from '../../../constants/constants'
import { ClientModel, CourierModel, OrderModel, PizzaModel, ReportModel, StatusModel } from '../../../models/models'
import { ClientDTO, CourierDTO, OrderDTO, PizzaDTO, ReportDTO, StatusDTO } from '../../../constants/models'
import { CourierSchema, OrderSchema } from '../../../constants/schemas'
import { Op } from 'sequelize'

export const courierMenuRouter = express.Router()

courierMenuRouter.post(RoutesPaths.getOrdersByCourierId, async (req: express.Request, res: express.Response) => {
  try {
    const filter = req.body.isFilterApplied ?
      { [OrderSchema.statusId]: { [Op.eq]: 1 } }
      : { [OrderSchema.statusId]: { [Op.not]: 1 } }
    const filteredOrders: OrderDTO[] = await OrderModel.findAll({
      where: {
        [OrderSchema.courierId]: req.body.courierId,
        ...filter,
      },
    })
    const statuses: StatusDTO[] = await StatusModel.findAll({})
    const pizzas: PizzaDTO[] = await PizzaModel.findAll({})
    const clients: ClientDTO[] = await ClientModel.findAll({})
    const reports: ReportDTO[] = await ReportModel.findAll({})
    const courier: CourierDTO = await CourierModel.findOne({
      where: {
        [CourierSchema.id]: req.body.courierId,
      },
    })

    const fullFilteredOrders = filteredOrders.map(order => ({
      ...order,
      pizza: pizzas.find(pizza => pizza.id === order.pizzaId),
      status: statuses.find(status => status.id === order.statusId),
      courier: courier,
      client: clients.find(client => client.id === order.clientId),
      report: reports.find(report => report.orderId === order.id),
    }))
    res.json(fullFilteredOrders)
  } catch (e: any) {
    res.status(CLIENT_ERROR_STATUS_CODE).json({ message: e.message })
  }
})

courierMenuRouter.post(RoutesPaths.acceptOrder, async (req: express.Request, res: express.Response) => {
  try {
    await OrderModel.update({
      [OrderSchema.statusId]: 3,
    }, {
      where: {
        id: req.body.orderId,
      },
    })
    await ReportModel.create({ ...req.body })
    res.json([])
  } catch (e: any) {
    res.status(CLIENT_ERROR_STATUS_CODE).json({ message: e.message })
  }
})
