import express from 'express'
import { PizzaPropNames, TableNames } from '../../constants/types'
import { tablesPropNames } from '../../constants/constants'
import { PizzaModel } from '../models/pizza.model'

export class PizzaController {
  static getAll(req: express.Request, res: express.Response) {
    PizzaModel.findAll({ raw: true }).then(pizzas => {
      res.render('tables/pizzas/pizzas.hbs', {
        tableName: TableNames.pizzas,
        propNames: tablesPropNames[TableNames.pizzas],
        entities: pizzas,
      })
    })
  }

  static getOne(req: express.Request, res: express.Response) {
    PizzaModel.findOne({
      where: {
        [PizzaPropNames.id]: +req.params.id,
      },
      raw: true,
    }).then(pizza => {
      res.render('tables/pizzas/pizzas.hbs', {
        tableName: TableNames.pizzas,
        propNames: tablesPropNames[TableNames.pizzas],
        entities: [pizza],
      })
    })
  }

  static openAddPage(req: express.Request, res: express.Response) {
    res.render('tables/pizzas/add.hbs', {})
  }

  static addOne(req: express.Request, res: express.Response) {
    PizzaModel.create({ ...req.body }).then(() => {
      res.redirect('/view/pizzas')
    })
  }

  static updateOne(req: express.Request, res: express.Response) {
    PizzaModel.update({ ...req.body }, {
      where: {
        [PizzaPropNames.id]: +req.params.id,
      },
    }).then(() => {
      res.redirect('/view/pizzas')
    })
  }

  static deleteOne(req: express.Request, res: express.Response) {
    PizzaModel.destroy({
      where: {
        [PizzaPropNames.id]: +req.params.id,
      },
    }).then(() => {
      res.redirect('/view/pizzas')
    })
  }
}
