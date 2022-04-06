const express = require('express');
const router = express.Router();

const employeeRouter = require('./employeeRouter');
const departmentRouter = require('./departmentRouter');
const projectRouter = require('./projectRouter');

router.use('/employee', employeeRouter);
router.use('/department', departmentRouter);
router.use('/project', projectRouter);


module.exports = router;
