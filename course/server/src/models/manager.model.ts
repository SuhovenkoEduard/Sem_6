import Sequelize from 'sequelize'
import { sequelize } from '../dbConnection/dbConnection'
import { TableNames } from '../constants/types'
import { AccountSchema, ManagerSchema } from '../constants/schemas'
import { AccountModel } from './account.model'

export const ManagerModel = sequelize.define<any, any>(TableNames.managers, {
  [ManagerSchema.id]: {
    type: Sequelize.INTEGER,
    primaryKey: true,
    autoIncrement: true,
    unique: true,
    allowNull: false,
  },
  [ManagerSchema.accountId]: {
    type: Sequelize.INTEGER,
    allowNull: false,
    references: {
      model: AccountModel,
      key: AccountSchema.id,
    },
    unique: true,
  },
  [ManagerSchema.name]: {
    type: Sequelize.TEXT,
    allowNull: false,
  },
  [ManagerSchema.salary]: {
    type: Sequelize.INTEGER,
    allowNull: false,
  },
  [ManagerSchema.description]: {
    type: Sequelize.TEXT,
    allowNull: false,
  },
}, {
  tableName: TableNames.managers,
  timestamps: false,
})
