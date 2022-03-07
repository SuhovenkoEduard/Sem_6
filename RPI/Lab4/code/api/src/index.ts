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
      const filteredPizzas: Pizza[] = pizzas
        .filter(pizza => pizzaQuery.size === undefined || pizza.size === pizzaQuery.size)
        .filter(pizza => pizzaQuery.hasMeat === undefined || pizza.hasMeat === pizzaQuery.hasMeat)
        .filter(pizza => pizzaQuery.hasCheese === undefined || pizza.hasCheese === pizzaQuery.hasCheese)
      res.json(filteredPizzas)
    } catch (error) {
      res.json({ message: 'Error', details: error.toString() })
    }
  })
})

app.listen(SERVER_PORT, () => {
  console.log(`Server is listening on port ${SERVER_PORT}`)
})
