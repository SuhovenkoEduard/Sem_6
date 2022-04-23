import Sequelize from 'sequelize'
import { sequelize } from '../dbConnection/dbConnection'
import { TableNames } from '../constants/types'
import { CourierSchema, OrderSchema, ReportSchema } from '../constants/schemas'
import { CourierModel } from './courier.model'
import { OrderModel } from './order.model'

export const ReportModel = sequelize.define<any, any>(TableNames.reports, {
  [ReportSchema.id]: {
    type: Sequelize.INTEGER,
    primaryKey: true,
    autoIncrement: true,
    unique: true,
    allowNull: false,
  },
  [ReportSchema.courierId]: {
    type: Sequelize.INTEGER,
    allowNull: false,
    references: {
      model: CourierModel,
      key: CourierSchema.id,
    },
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
