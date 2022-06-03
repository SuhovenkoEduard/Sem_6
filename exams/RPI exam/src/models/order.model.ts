import Sequelize from 'sequelize'
import { sequelize } from '../dbConnection/dbConnection'
import { TableNames } from '../constants/types'
import { ProductModel } from './product.model'
import { WorkerModel } from './worker.model'
import { ClientModel } from './client.model'

export const OrderModel = sequelize.define<any, any>(TableNames.orders, {
  id: {
    type: Sequelize.INTEGER,
    primaryKey: true,
    autoIncrement: true,
    unique: true,
    allowNull: false,
  },
  date: {
    type: Sequelize.TEXT,
    allowNull: false,
  },
  clientId: {
    type: Sequelize.INTEGER,
    allowNull: false,
    references: {
      model: ClientModel,
      key: 'id',
    },
  },
  productId: {
    type: Sequelize.INTEGER,
    allowNull: false,
    references: {
      model: ProductModel,
      key: 'id',
    },
  },
  quantity: {
    type: Sequelize.INTEGER,
    allowNull: false,
  },
  finalPrice: {
    type: Sequelize.INTEGER,
    allowNull: false,
  },
  workerId: {
    type: Sequelize.INTEGER,
    allowNull: false,
    references: {
      model: WorkerModel,
      key: 'id',
    },
  },
}, {
  tableName: TableNames.orders,
  timestamps: false,
})
