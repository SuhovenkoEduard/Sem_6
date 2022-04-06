const express = require('express');
const router = express.Router();

const Department = require('../models/departmentModel');

router.get('/', (req, res) => {
  Department.findAll({}).then(departments => {
    res.json(departments);
  });
});

router.get('/:id', (req, res) => {
  Department.findOne({
    where: {
      Dept_id: req.params.id
    }
  }).then(department => {
    res.json(department);
  });
});

router.post('/', (req, res) => {
  Department.create({
    Dept_name: req.body.Dept_name
  }).then(department => {
    res.json(department);
  });
});

router.put('/:id', (req, res) => {
  Department.update({
    Dept_name: req.body.Dept_name
  }, {
    where: {
      Dept_id: req.params.id
    }
  }).then(department => {
    res.json(department);
  });
});

router.delete('/:id', (req, res) => {
  Department.destroy({
    where: {
      Dept_id: req.params.id
    }
  }).then(department => {
    res.json(department);
  });
});

module.exports = router;
