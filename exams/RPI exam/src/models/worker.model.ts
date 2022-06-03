import Sequelize from 'sequelize'
import { sequelize } from '../dbConnection/dbConnection'
import { TableNames } from '../constants/types'
import { PositionModel } from './position.model'
import { CategoryModel } from './category.model'

export const WorkerModel = sequelize.define<any, any>(TableNames.workers, {
  id: {
    type: Sequelize.INTEGER,
    primaryKey: true,
    autoIncrement: true,
    unique: true,
    allowNull: false,
  },
  fullName: {
    type: Sequelize.TEXT,
    allowNull: false,
  },
  positionId: {
    type: Sequelize.INTEGER,
    allowNull: false,
    references: {
      model: PositionModel,
      key: 'id',
    },
  },
  categoryId: {
    type: Sequelize.INTEGER,
    allowNull: false,
    references: {
      model: CategoryModel,
      key: 'id',
    },
  },
}, {
  tableName: TableNames.workers,
  timestamps: false,
})
