const {Sequelize} = require('sequelize');
const sequlize = require('../database');

const Project = sequlize.define('Project', {
  Project_id: {
    type: Sequelize.INTEGER, primaryKey: true, autoIncrement: true
  }, Project_name: {
    type: Sequelize.STRING, allowNull: true
  }
}, {
  tableName: 'Project', timestamps: false
});

module.exports = Project;
