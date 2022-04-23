import express from 'express'
import { CLIENT_ERROR_STATUS_CODE, RoutesPaths } from '../../constants/constants'
import { ClientModel, CourierModel, OrderModel, PizzaModel, StatusModel } from '../../models/models'
import { CourierDTO, OrderDTO, PizzaDTO, StatusDTO } from '../../constants/models'
import { ClientSchema, OrderSchema } from '../../constants/schemas'
import { Op } from 'sequelize'

export const clientMenuRouter = express.Router()

clientMenuRouter.post(RoutesPaths.getOrders, async (req: express.Request, res: express.Response) => {
  try {
    const filter = req.body.isFilterApplied ?
      { [OrderSchema.statusId]: { [Op.eq]: 1 } }
      : { [OrderSchema.statusId]: { [Op.not]: 1 } }
    const filteredOrders: OrderDTO[] = await OrderModel.findAll({
      where: {
        [OrderSchema.clientId]: req.body.clientId,
        ...filter,
      },
    })
    const statuses: StatusDTO[] = await StatusModel.findAll({})
    const pizzas: PizzaDTO[] = await PizzaModel.findAll({})
    const couriers: CourierDTO[] = await CourierModel.findAll({})
    const client: CourierDTO = await ClientModel.findOne({
      where: {
        [ClientSchema.id]: req.body.clientId,
      },
    })

    const fullFilteredOrders = filteredOrders.map(order => ({
      ...order,
      pizza: pizzas.find(pizza => pizza.id === order.pizzaId),
      status: statuses.find(status => status.id === order.statusId),
      courier: couriers.find(courier => courier.id === order.courierId),
      client: client,
    }))
    res.json(fullFilteredOrders)
  } catch (e: any) {
    res.status(CLIENT_ERROR_STATUS_CODE).json({ message: e.message })
  }
})

clientMenuRouter.post(RoutesPaths.declineOrder, async (req: express.Request, res: express.Response) => {
  try {
    await OrderModel.update({
      [OrderSchema.statusId]: 2,
    }, {
      where: {
        id: req.body.id,
      },
    })
    res.json([])
  } catch (e: any) {
    res.status(CLIENT_ERROR_STATUS_CODE).json({ message: e.message })
  }
})
