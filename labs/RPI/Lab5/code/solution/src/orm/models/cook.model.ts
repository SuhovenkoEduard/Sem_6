import Sequelize from 'sequelize'
import { sequelize } from '../database'
import { CookPropNames, TableNames } from '../../constants/types'

export const CookModel = sequelize.define(TableNames.cooks, {
  [CookPropNames.id]: {
    type: Sequelize.INTEGER, primaryKey: true, autoIncrement: true,
  },
  [CookPropNames.name]: {
    type: Sequelize.STRING, allowNull: false,
  },
  [CookPropNames.age]: {
    type: Sequelize.INTEGER, allowNull: false,
  },
  [CookPropNames.pizzaId]: {
    type: Sequelize.INTEGER, allowNull: false,
  },
  [CookPropNames.restaurantId]: {
    type: Sequelize.INTEGER, allowNull: false,
  },
}, {
  tableName: TableNames.cooks,
  timestamps: false,
})
