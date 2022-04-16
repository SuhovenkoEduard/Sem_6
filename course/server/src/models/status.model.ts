import Sequelize from 'sequelize'
import { sequelize } from '../dbConnection/dbConnection'
import { TableNames } from '../constants/types'
import { StatusSchema } from '../constants/schemas'

export const StatusModel = sequelize.define(TableNames.statuses, {
  [StatusSchema.id]: {
    type: Sequelize.INTEGER,
    primaryKey: true,
    autoIncrement: true,
    unique: true,
    allowNull: false,
  },
  [StatusSchema.type]: {
    type: Sequelize.STRING,
    allowNull: false,
  },
}, {
  tableName: TableNames.statuses,
  timestamps: false,
})
