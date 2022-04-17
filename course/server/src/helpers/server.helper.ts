import express from 'express'
import { CLIENT_ERROR_STATUS_CODE } from '../constants/constants'

export const sendError = (errorMessage: string, res: express.Response) => res.status(CLIENT_ERROR_STATUS_CODE).json({ message: errorMessage })
