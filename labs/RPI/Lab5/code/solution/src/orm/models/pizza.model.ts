import Sequelize from 'sequelize'
import { sequelize } from '../database'
import { PizzaPropNames, TableNames } from '../../constants/types'

export const PizzaModel = sequelize.define(TableNames.pizzas, {
  [PizzaPropNames.id]: {
    type: Sequelize.INTEGER, primaryKey: true, autoIncrement: true,
  },
  [PizzaPropNames.name]: {
    type: Sequelize.STRING, allowNull: false,
  },
  [PizzaPropNames.caloric]: {
    type: Sequelize.INTEGER, allowNull: false,
  },
}, {
  tableName: TableNames.pizzas,
  timestamps: false,
})
