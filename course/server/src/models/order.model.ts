import Sequelize from 'sequelize'
import { sequelize } from '../dbConnection/dbConnection'
import { TableNames } from '../constants/types'
import { ClientSchema, CourierSchema, OrderSchema, PizzaSchema, StatusSchema } from '../constants/schemas'
import { PizzaModel } from './pizza.model'
import { ClientModel } from './client.model'
import { CourierModel } from './courier.model'
import { StatusModel } from './status.model'

export const OrderModel = sequelize.define<any, any>(TableNames.orders, {
  [OrderSchema.id]: {
    type: Sequelize.INTEGER,
    primaryKey: true,
    autoIncrement: true,
    allowNull: false,
    unique: true,
  },
  [OrderSchema.pizzaId]: {
    type: Sequelize.INTEGER,
    allowNull: false,
    references: {
      model: PizzaModel,
      key: PizzaSchema.id,
    },
  },
  [OrderSchema.clientId]: {
    type: Sequelize.INTEGER,
    allowNull: false,
    references: {
      model: ClientModel,
      key: ClientSchema.id,
    },
  },
  [OrderSchema.courierId]: {
    type: Sequelize.INTEGER,
    allowNull: false,
    references: {
      model: CourierModel,
      key: CourierSchema.id,
    },
  },
  [OrderSchema.statusId]: {
    type: Sequelize.INTEGER,
    allowNull: false,
    references: {
      model: StatusModel,
      key: StatusSchema.id,
    },
  },
  [OrderSchema.address]: {
    type: Sequelize.TEXT,
    allowNull: false,
  },
  [OrderSchema.date]: {
    type: Sequelize.TEXT,
    allowNull: false,
  },
}, {
  tableName: TableNames.orders,
  timestamps: false,
})
