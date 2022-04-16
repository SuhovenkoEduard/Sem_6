import Sequelize from 'sequelize'
import { sequelize } from '../dbConnection/dbConnection'
import { TableNames } from '../constants/types'
import { AccountSchema, ClientSchema } from '../constants/schemas'
import { AccountModel } from './account.model'

export const ClientModel = sequelize.define(TableNames.clients, {
  [ClientSchema.id]: {
    type: Sequelize.INTEGER,
    primaryKey: true,
    autoIncrement: true,
    unique: true,
    allowNull: false,
  },
  [ClientSchema.accountId]: {
    type: Sequelize.INTEGER,
    allowNull: false,
    references: {
      model: AccountModel,
      key: AccountSchema.id,
    },
    unique: true,
  },
  [ClientSchema.name]: {
    type: Sequelize.STRING,
    allowNull: false,
  },
  [ClientSchema.phone]: {
    type: Sequelize.STRING,
    allowNull: false,
  },
  [ClientSchema.description]: {
    type: Sequelize.STRING,
    allowNull: false,
  },
}, {
  tableName: TableNames.clients,
  timestamps: false,
})
