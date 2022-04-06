const { Sequelize } = require("sequelize");
const sequlize = require('../database');

const Department = sequlize.define('Department', {
    Dept_id: {
        type: Sequelize.INTEGER,
        primaryKey: true,
        autoIncrement: true
    },
    Dept_name: {
        type: Sequelize.STRING,
        allowNull: true
    }
},
{
    tableName: 'Department',
    timestamps: false
});

module.exports = Department;