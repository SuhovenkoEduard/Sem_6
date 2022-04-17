import express from 'express'
import { Account, Client } from '../../constants/models'
import { AccountModel, ClientModel } from '../../models/models'
import { AccountSchema, ClientSchema } from '../../constants/schemas'
import stringHash from 'string-hash'
import { CLIENT_ERROR_STATUS_CODE } from '../../constants/constants'

export const signUpRouter = express.Router()

type SignUpData = {
  name: string
  phoneNumber: string
  description: string
  email: string
  password: string
}

signUpRouter.post('/', async (req: express.Request, res: express.Response) => {
  try {
    const signUpData: SignUpData = { ...req.body }
    const account: Account = await AccountModel.create({
      [AccountSchema.email]: signUpData.email,
      [AccountSchema.password]: stringHash(signUpData.password).toString(),
    })

    const client: Client = await ClientModel.create({
      [ClientSchema.name]: signUpData.name,
      [ClientSchema.accountId]: account.id,
      [ClientSchema.phone]: signUpData.phoneNumber,
      [ClientSchema.description]: signUpData.description,
    })

    res.json({ account, client })
  } catch (e: any) {
    res.status(CLIENT_ERROR_STATUS_CODE).json({ message: e.message })
  }
})
