const Employee = require("../models/employeeModel");

// create class controller which return hbs with data
class EmployeeController {
    // get all employees
    static getAllEmployees(req, res) {
        Employee.findAll({raw: true}).then(employees => {
            res.render("index.hbs", {
                employees: employees
            });
        });
    }

    // get one employee
    static getOneEmployee(req, res) {
        Employee.findOne({
            where: {
                id: req.params.id
            },
            raw: true
        }).then(employee => {
            res.render("index.hbs", {
                employee: employee
            });
        });
    }

    static addEmployee(req, res) {
        res.render("addEmployee.hbs",{});
    }

    // create employee
    static createEmployee(req, res) {
        Employee.create({
            Name: req.body.Name,
            Job_Title: req.body.Job_Title,
            Sallary: req.body.Sallary,
            Dept_id: req.body.Dept_id,
            Project_id: req.body.Project_id
        }).then(() => {
            res.redirect("/");
        });
    }

    // update employee
    static updateEmployee(req, res) {
        Employee.update({
            Name: req.body.Name,
            Job_Title: req.body.Job_Title,
            Sallary: req.body.Sallary,
            Dept_id: req.body.Dept_id,
            Project_id: req.body.Project_id
        }, {
            where: {
                id: req.params.id
            }
        }).then(() => {
            res.redirect("/");
        });
    }

    // delete employee
    static deleteEmployee(req, res) {
        Employee.destroy({
            where: {
                id: req.params.id
            }
        }).then(employee => {
            res.redirect("/");
        });
    }
}

module.exports = EmployeeController;