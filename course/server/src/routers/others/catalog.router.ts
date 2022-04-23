import express from 'express'
import { CLIENT_ERROR_STATUS_CODE, RoutesPaths } from '../../constants/constants'
import { CourierModel, OrderModel, PizzaModel, StatusModel } from '../../models/models'
import { CourierDTO, OrderDTO, StatusDTO } from '../../constants/models'

export const catalogRouter = express.Router()

catalogRouter.get(RoutesPaths.root, async (req: express.Request, res: express.Response) => {
  try {
    const pizzas = await PizzaModel.findAll({})
    res.json(pizzas)
  } catch (e: any) {
    res.status(CLIENT_ERROR_STATUS_CODE).json({ message: e.message })
  }
})

catalogRouter.post(RoutesPaths.addOne, async (req: express.Request, res: express.Response) => {
  try {
    const couriers: CourierDTO[] = await CourierModel.findAll({})
    const randomCourier = couriers[Math.floor(Math.random() * couriers.length)]
    const pendingStatus: StatusDTO = await StatusModel.findOne({ where: { id: 1 } })
    const createdOrder: OrderDTO = await OrderModel.create({
      pizzaId: req.body.pizzaId,
      clientId: req.body.clientId,
      courierId: randomCourier.id,
      statusId: pendingStatus.id,
      address: req.body.address,
      startDate: req.body.startDate,
      endDate: new Date(req.body.endDate).toUTCString(),
    })
    res.json(createdOrder)
  } catch (e: any) {
    res.status(CLIENT_ERROR_STATUS_CODE).json({ message: e.message })
  }
})
