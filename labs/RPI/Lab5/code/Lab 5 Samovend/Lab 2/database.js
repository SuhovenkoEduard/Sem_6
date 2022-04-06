const Sequelize = require("sequelize");
const sequelize = new Sequelize('sqlite::memory:', {
    host: "localhost",
    dialect: "sqlite",
    pool: {
        max: 5,
        min: 0,
        idle: 10000
    },
    storage: "../database.db"
});

module.exports = sequelize;
