import * as fs from 'fs'
import express from 'express'
import { Pizza } from './constants/types'
import { PIZZA_PATH, SERVER_PORT } from './constants/constants'

const app = express()
const pizzas: Pizza[] = JSON.parse(fs.readFileSync(PIZZA_PATH).toString())

app.get('/', (req: express.Request, res: express.Response) => {
  const maxCount = +req.query?.maxCount ?? pizzas.length
  res.json(pizzas.slice(0, maxCount))
})

app.post('/', (req: express.Request, res: express.Response) => {
  let jsonString = ''
  req.on('data', (chunk => jsonString += chunk))
  req.on('end', () => {
    try {
      const pizzaQuery: Pizza = JSON.parse(jsonString)
      res.json(pizzas.filter(pizza =>
        (pizza.size ?? pizza.size !== pizzaQuery.size) &&
        (pizza.hasMeat ?? pizza.hasMeat !== pizzaQuery.hasMeat) &&
        (pizza.hasCheese ?? pizza.hasCheese !== pizzaQuery.hasCheese)))
    } catch (error) {
      res.json({ message: 'Error', details: error.toString() })
    }
  })
})

app.listen(SERVER_PORT, () => {
  console.log(`Server is listening on port ${SERVER_PORT}`)
})
