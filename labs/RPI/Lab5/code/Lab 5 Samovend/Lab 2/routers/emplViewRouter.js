const express = require("express");
const router = express.Router();
const EmployeeController = require("../controllers/employeeController");

router.get("/create-employee", EmployeeController.addEmployee)
router.get("/", EmployeeController.getAllEmployees);
router.get("/:id", EmployeeController.getOneEmployee);
router.post("/", EmployeeController.createEmployee);

module.exports = router;