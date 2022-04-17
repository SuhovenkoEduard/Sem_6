import express from 'express'
import { AccountModel, ClientModel, CourierModel, ManagerModel } from '../../models/models'
import { AccountSchema, ClientSchema, CourierSchema, ManagerSchema } from '../../constants/schemas'
import stringHash from 'string-hash'
import { Account, Client, Courier, Manager } from '../../constants/models'
import { messages } from '../../constants/messages'
import { sendError } from '../../helpers/server.helper'

export const signInRouter = express.Router()

type SignInData = {
  email: string
  password: string
}

signInRouter.post('/', async (req: express.Request, res: express.Response) => {
  try {
    const signInData: SignInData = { ...req.body }
    const account: Account | null  = await AccountModel.findOne({
      where: {
        [AccountSchema.email]: signInData.email,
        [AccountSchema.password]: stringHash(signInData.password).toString(),
      },
    })

    if (!account) {
      return sendError(messages.NO_SUCH_ACCOUNT_FOUND, res)
    }

    const client: Client | null = await ClientModel.findOne({
      where: {
        [ClientSchema.accountId]: account.id,
      },
    })

    if (client) {
      return res.json({ account, client })
    }

    const courier: Courier | null = await CourierModel.findOne({
      where: {
        [CourierSchema.accountId]: account.id,
      },
    })

    if (courier) {
      return res.json({ account, courier })
    }

    const manager: Manager | null = await ManagerModel.findOne({
      where: {
        [ManagerSchema.accountId]: account.id,
      },
    })

    if (manager) {
      return res.json({ account, manager })
    }

    sendError(messages.NO_SUCH_USER_FOUND, res)
  } catch (e: any) {
    sendError(messages.NO_SUCH_USER_FOUND, res)
  }
})
