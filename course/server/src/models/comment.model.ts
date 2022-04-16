import Sequelize from 'sequelize'
import { sequelize } from '../dbConnection/dbConnection'
import { TableNames } from '../constants/types'
import { ClientSchema, CommentSchema } from '../constants/schemas'
import { ClientModel } from './client.model'

export const CommentModel = sequelize.define(TableNames.comments, {
  [CommentSchema.id]: {
    type: Sequelize.INTEGER,
    primaryKey: true,
    autoIncrement: true,
    unique: true,
    allowNull: false,
  },
  [CommentSchema.clientId]: {
    type: Sequelize.INTEGER,
    allowNull: false,
    references: {
      model: ClientModel,
      key: ClientSchema.id,
    },
  },
  [CommentSchema.content]: {
    type: Sequelize.TEXT,
    allowNull: false,
  },
  [CommentSchema.date]: {
    type: Sequelize.TEXT,
    allowNull: false,
  },
}, {
  tableName: TableNames.comments,
  timestamps: false,
})
