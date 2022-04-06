const express = require("express");
const router = express.Router();
const Employee = require("../models/employeeModel");

router.get("/", (req, res) => {
    Employee.findAll({ 
    }).then(employees => {
        res.json(employees);
    });
});

router.get("/:id", (req, res) => {
    Employee.findOne({
        where: {
            id: req.params.id
        }
    }).then(employee => {
        res.json(employee);
    });
});

router.post("/", (req, res) => {
    Employee.create({
        Name: req.body.Name,
        Job_Title: req.body.Job_Title,
        Sallary: req.body.Sallary,
        Dept_id: req.body.Dept_id,
        Project_id: req.body.Project_id
    }).then(employee => {
        console.log(employee);
        res.json(employee);
    });
});

router.put("/:id", (req, res) => {
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
    }).then(employee => {
        res.json(employee);
    });
});

router.delete("/:id", (req, res) => {
    Employee.destroy({
        where: {
            id: req.params.id
        }
    }).then(employee => {
        res.json(employee);
    });
});




module.exports = router;