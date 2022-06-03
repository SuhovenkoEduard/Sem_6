import express, { Request, Response } from 'express'
import { SpecialRouters } from '../../constants/constants'
import { ClientWrapper, OrderWrapper, ProductWrapper } from '../../models/models'
import { errorHandler } from '../api/generic.router'
import { messages } from '../../constants/messages'

export const clientRouter = express.Router()

clientRouter.get(SpecialRouters.getFullClientInfo, async (req: Request, res: Response) => {
  try {
    const clients = await ClientWrapper.findAll({})
    const orders = await OrderWrapper.findAll({})
    const products = await ProductWrapper.findAll({})
    res.json(clients.map((client: any) => ({
      ...client,
      products: orders.filter((order: any) => order.clientId === client.id)
        .map((order: any) => ({
          productTitle: products.find((product: any) => product.id === order.productId).title,
          productCount: order.quantity,
          totalPrice: order.finalPrice,
        })),
    })))
  } catch (e: any) {
    errorHandler(e.message, messages.DATABASE_ERROR_GET_ALL, res)
  }
})
