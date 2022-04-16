import Sequelize from 'sequelize'
import { sequelize } from '../dbConnection/dbConnection'
import { TableNames } from '../constants/types'
import { AccountSchema, CourierSchema } from '../constants/schemas'
import { AccountModel } from './account.model'

export const CourierModel = sequelize.define(TableNames.couriers, {
  [CourierSchema.id]: {
    type: Sequelize.INTEGER,
    primaryKey: true,
    autoIncrement: true,
    unique: true,
    allowNull: false,
  },
  [CourierSchema.accountId]: {
    type: Sequelize.INTEGER,
    allowNull: false,
    references: {
      model: AccountModel,
      key: AccountSchema.id,
    },
    unique: true,
  },
  [CourierSchema.name]: {
    type: Sequelize.TEXT,
    allowNull: false,
  },
  [CourierSchema.salary]: {
    type: Sequelize.INTEGER,
    allowNull: false,
  },
  [CourierSchema.description]: {
    type: Sequelize.TEXT,
    allowNull: false,
  },
}, {
  tableName: TableNames.couriers,
  timestamps: false,
})
