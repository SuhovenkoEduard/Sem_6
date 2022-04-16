import Sequelize from 'sequelize'
import { sequelize } from '../dbConnection/dbConnection'
import { TableNames } from '../constants/types'
import { AccountSchema } from '../constants/schemas'

export const AccountModel = sequelize.define(TableNames.accounts, {
  [AccountSchema.id]: {
    type: Sequelize.INTEGER,
    primaryKey: true,
    autoIncrement: true,
    unique: true,
    allowNull: false,
  },
  [AccountSchema.email]: {
    type: Sequelize.STRING,
    allowNull: false,
  },
  [AccountSchema.password]: {
    type: Sequelize.STRING,
    allowNull: false,
  },
}, {
  tableName: TableNames.accounts,
  timestamps: false,
})
