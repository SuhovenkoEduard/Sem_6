import express from 'express'
import { apiRouter } from './routers/api/routers.api'
import { messages } from './constants/messages'
import { ApiRouters, SERVER_PORT } from './constants/constants'

const app = express()

app.use(express.json())
app.use(express.urlencoded({ extended: true }))

app.use(ApiRouters.api, apiRouter)

app.listen(SERVER_PORT, () => {
  console.log(messages.SERVER_LISTENING(SERVER_PORT))
})
