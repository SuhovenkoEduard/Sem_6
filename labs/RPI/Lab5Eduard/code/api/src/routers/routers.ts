import express, { Router } from 'express'
import { createRouter } from './generic.router'
import { TableNames } from '../constants/types'
import { tablesPropNames } from '../constants/constants'

export const globalRouter = Object.values(TableNames)
  .reduce(
    (router: Router, tableName: TableNames) =>
      router.use(
        `/${tableName}`,
        createRouter(tableName, tablesPropNames[tableName]),
      ),
    express.Router(),
  )
