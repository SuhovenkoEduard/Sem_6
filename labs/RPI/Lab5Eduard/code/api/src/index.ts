import express from 'express'
import { Routes } from './constants/constants'
import { globalRouter } from './routers/routers'
import { messages } from './constants/messages'

const port = 3000

const app = express()
app.use(express.json())
app.use(Routes.api, globalRouter)

app.listen(port, () => {
  console.log(messages.SERVER_LISTENING(port))
})
