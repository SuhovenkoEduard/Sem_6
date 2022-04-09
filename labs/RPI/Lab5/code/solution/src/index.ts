import express from 'express'
import { ApiRoutes, ViewRoutes } from './constants/constants'
import { sqlGlobalRouter } from './sql/routers/routers'
import { messages } from './constants/messages'
import { ormApiRouter } from './orm/routers/apis/routers.api'
import { ormViewRouter } from './orm/routers/views/routers.view'
import { engine } from 'express-handlebars'

const isOrm = true
const port = 3000

export const app = express()
app.use(express.json())
app.use(express.urlencoded({ extended: true }))

if (isOrm) {
  app.set('view engine', 'hbs')
  app.engine('hbs', engine({
    layoutsDir: 'views/layouts',
    defaultLayout: 'layout',
    extname: 'hbs',
  }))

  app.use(ViewRoutes.view, ormViewRouter)
  app.use(ApiRoutes.api, ormApiRouter)
} else {
  app.use(ApiRoutes.api, sqlGlobalRouter)
}

app.listen(port, () => {
  console.log(messages.SERVER_LISTENING(port))
})
