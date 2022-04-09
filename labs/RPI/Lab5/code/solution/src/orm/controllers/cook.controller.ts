import express from 'express'
import { CookModel } from '../models/cook.model'
import { CookPropNames, TableNames } from '../../constants/types'
import { tablesPropNames } from '../../constants/constants'

export class CookController {
  static getAll(req: express.Request, res: express.Response) {
    CookModel.findAll({ raw: true }).then(cooks => {
      res.render('tables/cooks/cooks.hbs', {
        tableName: TableNames.cooks,
        propNames: tablesPropNames[TableNames.cooks],
        entities: cooks,
      })
    })
  }

  static getOne(req: express.Request, res: express.Response) {
    CookModel.findOne({
      where: {
        [CookPropNames.id]: +req.params.id,
      },
      raw: true,
    }).then(cook => {
      res.render('tables/cooks/cooks.hbs', {
        tableName: TableNames.cooks,
        propNames: tablesPropNames[TableNames.cooks],
        entities: [cook],
      })
    })
  }
}
