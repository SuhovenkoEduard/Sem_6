import express from 'express'
import cors from 'cors'
import { apiRouter } from './routers/api/routers.api'
import { messages } from './constants/messages'
import {
  ApiRouters,
  SERVER_PORT, SpecialRouters,
} from './constants/constants'
import { specialRouter } from './routers/special/routers.special'

const app = express()

app.use(cors())
app.use(express.json())
app.use(express.urlencoded({ extended: true }))

app.use(ApiRouters.api, apiRouter)
app.use(SpecialRouters.special, specialRouter)

app.listen(SERVER_PORT, () => {
  console.log(messages.SERVER_LISTENING(SERVER_PORT))
})
