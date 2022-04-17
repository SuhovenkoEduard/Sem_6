import express from 'express'
import { AccountDTO, ClientDTO } from '../../constants/models'
import { AccountModel, ClientModel } from '../../models/models'
import { AccountSchema, ClientSchema } from '../../constants/schemas'
import stringHash from 'string-hash'
import { CLIENT_ERROR_STATUS_CODE, RoutesPaths } from '../../constants/constants'

export const signUpRouter = express.Router()

type SignUpData = {
  name: string
  phoneNumber: string
  description: string
  email: string
  password: string
}

signUpRouter.post(RoutesPaths.root, async (req: express.Request, res: express.Response) => {
  try {
    const signUpData: SignUpData = { ...req.body }
    const account: AccountDTO = await AccountModel.create({
      [AccountSchema.email]: signUpData.email,
      [AccountSchema.password]: stringHash(signUpData.password).toString(),
    })

    const client: ClientDTO = await ClientModel.create({
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
