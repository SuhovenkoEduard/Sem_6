import express from 'express'
import sqlite3 from 'sqlite3'
import { ApiRoutes, PATH_TO_DATABASE } from '../constants/constants'
import {
  createDeleteQuery,
  createGetAllQuery,
  createGetByIdQuery,
  createPostQuery,
  createPutQuery,
} from '../helpers/dbQueries.helpers'
import { ResponseStatuses } from '../constants/types'
import { messages } from '../constants/messages'

const requestHandler = (res: express.Response, message?: string) => (err: object, data: object) => {
  if (err) {
    res.status(ResponseStatuses.error).send(err)
  } else {
    res.status(ResponseStatuses.success).json(message ? { message } : data)
  }
}

export const createRouter = (tableName: string, propNames: string[]) => {
  const router = express.Router()
  const db = new sqlite3.Database(PATH_TO_DATABASE)

  const [propNameId] = propNames

  router.get(ApiRoutes.getAll, (req: express.Request, res: express.Response) => {
    db.all(createGetAllQuery(tableName), requestHandler(res))
  })

  router.get(ApiRoutes.getSingle, (req: express.Request, res: express.Response) => {
    const id = +req.params.id
    db.all(createGetByIdQuery(tableName, propNameId), [id], requestHandler(res))
  })

  router.put(ApiRoutes.putSingle, (req: express.Request, res: express.Response) => {
    const id = +req.params.id
    db.all(createPutQuery(tableName, Object.keys(req.body), propNameId), [...Object.values(req.body), id],
      requestHandler(res, messages.SUCCESSFULLY_UPDATED))
  })

  router.post(ApiRoutes.postSingle, (req: express.Request, res: express.Response) => {
    db.all(createPostQuery(tableName, Object.keys(req.body)), Object.values(req.body),
      requestHandler(res, messages.SUCCESSFULLY_ADDED))
  })

  router.delete(ApiRoutes.deleteSingle, (req: express.Request, res: express.Response) => {
    const id = +req.params.id
    db.all(createDeleteQuery(tableName, propNameId), [id],
      requestHandler(res, messages.SUCCESSFULLY_DELETED))
  })

  return router
}

