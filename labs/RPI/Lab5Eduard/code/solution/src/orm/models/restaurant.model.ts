import Sequelize from 'sequelize'
import { sequelize } from '../database'
import { RestaurantPropNames, TableNames } from '../../constants/types'

export const RestaurantModel = sequelize.define(TableNames.restaurants, {
  [RestaurantPropNames.id]: {
    type: Sequelize.INTEGER, primaryKey: true, autoIncrement: true,
  },
  [RestaurantPropNames.address]: {
    type: Sequelize.STRING, allowNull: false,
  },
  [RestaurantPropNames.revenue]: {
    type: Sequelize.INTEGER, allowNull: false,
  },
}, {
  tableName: TableNames.restaurants,
  timestamps: false,
})
