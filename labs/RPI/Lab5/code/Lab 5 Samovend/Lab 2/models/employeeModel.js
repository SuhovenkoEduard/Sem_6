const {Sequelize} = require('sequelize');
const sequlize = require('../database');
const Employee = sequlize.define('Employee', {
  id: {
    type: Sequelize.INTEGER, primaryKey: true, autoIncrement: true
  }, Name: {
    type: Sequelize.STRING, allowNull: false
    
  },
  
  Job_Title: {
    type: Sequelize.STRING, allowNull: false
  },
  
  Sallary: {
    type: Sequelize.INTEGER, allowNull: false
  },
  
  Dept_id: {
    type: Sequelize.INTEGER, allowNull: false, references: {
      model: 'Department', key: 'Dept_id'
    }
  },
  
  Project_id: {
    type: Sequelize.INTEGER, allowNull: false, references: {
      model: 'Project', key: 'Project_id'
    }
    
  }
}, {
  tableName: 'Employee', timestamps: false
});

module.exports = Employee;
