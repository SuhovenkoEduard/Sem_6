import Sequelize from 'sequelize'
import { sequelize } from '../dbConnection/dbConnection'
import { TableNames } from '../constants/types'
import { ProductModel } from './product.model'

export const StorageModel = sequelize.define<any, any>(TableNames.storages, {
  id: {
    type: Sequelize.INTEGER,
    primaryKey: true,
    autoIncrement: true,
    unique: true,
    allowNull: false,
  },
  productId: {
    type: Sequelize.INTEGER,
    allowNull: false,
    references: {
      model: ProductModel,
      key: 'id',
    },
  },
  creationDate: {
    type: Sequelize.TEXT,
    allowNull: false,
  },
  quantity: {
    type: Sequelize.INTEGER,
    allowNull: false,
  },
}, {
  tableName: TableNames.storages,
  timestamps: false,
})
