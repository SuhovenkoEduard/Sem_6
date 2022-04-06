const express = require('express');
const router = express.Router();

const Project = require('../models/projectModel');

router.get('/', (req, res) => {
  Project.findAll({}).then(projects => {
    res.json(projects);
  });
});

router.get('/:id', (req, res) => {
  Project.findOne({
    where: {
      Project_id: req.params.id
    }
  }).then(project => {
    res.json(project);
  });
});

router.post('/', (req, res) => {
  Project.create({
    Project_name: req.body.Project_name
  }).then(project => {
    res.json(project);
  });
});

router.put('/:id', (req, res) => {
  Project.update({
    Project_name: req.body.Project_name
  }, {
    where: {
      Project_id: req.params.id
    }
  }).then(project => {
    res.json(project);
  });
})

router.delete('/:id', (req, res) => {
  Project.destroy({
    where: {
      Project_id: req.params.id
    }
  }).then(project => {
    res.json(project);
  });
});

module.exports = router;
