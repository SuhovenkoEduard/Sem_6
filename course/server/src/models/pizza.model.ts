import Sequelize from 'sequelize'
import { sequelize } from '../dbConnection/dbConnection'
import { TableNames } from '../constants/types'
import { PizzaSchema } from '../constants/schemas'

export const PizzaModel = sequelize.define(TableNames.pizzas, {
  [PizzaSchema.id]: {
    type: Sequelize.INTEGER,
    primaryKey: true,
    autoIncrement: true,
    unique: true,
    allowNull: false,
  },
  [PizzaSchema.name]: {
    type: Sequelize.STRING,
    allowNull: false,
  },
  [PizzaSchema.description]: {
    type: Sequelize.STRING,
    allowNull: false,
  },
  [PizzaSchema.price]: {
    type: Sequelize.INTEGER,
    allowNull: false,
  },
  [PizzaSchema.imageUrl]: {
    type: Sequelize.STRING,
    allowNull: false,
  },
}, {
  tableName: TableNames.pizzas,
  timestamps: false,
})
