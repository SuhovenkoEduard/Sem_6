import express from 'express'
import { CLIENT_ERROR_STATUS_CODE } from '../constants/constants'
import { DataValues } from '../constants/models'

export const sendError = (errorMessage: string, res: express.Response) => res.status(CLIENT_ERROR_STATUS_CODE).json({ message: errorMessage })

export const convertModelResponse = <T>(response: DataValues<T>[]) => response.map(x => x.dataValues)
