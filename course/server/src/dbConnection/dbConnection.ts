import { Sequelize } from 'sequelize'
import { PATH_TO_DATABASE } from '../constants/constants'

export const sequelize = new Sequelize('sqlite::memory:', {
  host: 'localhost', dialect: 'sqlite', pool: {
    max: 5, min: 0, idle: 10000,
  }, storage: PATH_TO_DATABASE,
})
