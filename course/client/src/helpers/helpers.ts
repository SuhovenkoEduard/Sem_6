import { v4 as uuidv4 } from 'uuid'

export const generateUuid = () => uuidv4()

export const parseDate = (date: string) => new Date(Date.parse(date))
