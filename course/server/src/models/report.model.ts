import Sequelize from 'sequelize'
import { sequelize } from '../dbConnection/dbConnection'
import { TableNames } from '../constants/types'
import { OrderSchema, ReportSchema } from '../constants/schemas'
import { OrderModel } from './order.model'

export const ReportModel = sequelize.define<any, any>(TableNames.reports, {
  [ReportSchema.id]: {
    type: Sequelize.INTEGER,
    primaryKey: true,
    autoIncrement: true,
    unique: true,
    allowNull: false,
  },
  [ReportSchema.orderId]: {
    type: Sequelize.INTEGER,
    allowNull: false,
    references: {
      model: OrderModel,
      key: OrderSchema.id,
    },
    unique: true,
  },
  [ReportSchema.date]: {
    type: Sequelize.TEXT,
    allowNull: false,
  },
  [ReportSchema.description]: {
    type: Sequelize.TEXT,
    allowNull: false,
  },
}, {
  tableName: TableNames.reports,
  timestamps: false,
})
