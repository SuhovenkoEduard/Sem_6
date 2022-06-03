import Sequelize from 'sequelize'
import { sequelize } from '../dbConnection/dbConnection'
import { TableNames } from '../constants/types'

export const ProductModel = sequelize.define<any, any>(TableNames.products, {
  id: {
    type: Sequelize.INTEGER,
    primaryKey: true,
    autoIncrement: true,
    unique: true,
    allowNull: false,
  },
  title: {
    type: Sequelize.TEXT,
    allowNull: false,
  },
  price: {
    type: Sequelize.INTEGER,
    allowNull: false,
  },
  period: {
    type: Sequelize.TEXT,
    allowNull: false,
  },
}, {
  tableName: TableNames.products,
  timestamps: false,
})
