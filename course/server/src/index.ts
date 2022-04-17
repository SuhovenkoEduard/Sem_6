import express from 'express'
import cors from 'cors'
import { apiRouter } from './routers/api/routers.api'
import { messages } from './constants/messages'
import { ApiRouters, RoutesPaths, SERVER_PORT } from './constants/constants'
import { generateAccountsJson } from './helpers/accounts.helper'
import { othersRouter } from './routers/others/routers.others'

const isGenerateAccountsJson = false
if (isGenerateAccountsJson) generateAccountsJson()

const app = express()

app.use(cors())
app.use(express.json())
app.use(express.urlencoded({ extended: true }))

app.use(ApiRouters.api, apiRouter)
app.use(RoutesPaths.base, othersRouter)

app.listen(SERVER_PORT, () => {
  console.log(messages.SERVER_LISTENING(SERVER_PORT))
})
