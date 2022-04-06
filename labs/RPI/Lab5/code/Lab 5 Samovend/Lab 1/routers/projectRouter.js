const express = require('express');
const router = express.Router();
const sqlite3 = require('sqlite3').verbose();
const db = new sqlite3.Database('../database.db');

router.get('/', (req, res) => {
  db.all('SELECT * FROM Project', (err, rows) => {
    if (err) {
      res.status(500).send(err);
    } else {
      res.status(200).json(rows);
    }
  });
});

router.get('/:id', (req, res) => {
  const id = req.params.id;
  db.get('SELECT * FROM Project WHERE Project_id = ?', [id], (err, row) => {
    if (err) {
      res.status(500).send(err);
    } else {
      res.status(200).json(row);
    }
  });
});

router.put('/:id', (req, res) => {
  const id = req.params.id;
  const {Project_name} = req.body;
  db.run(`UPDATE Project SET Project_name = ? WHERE Project_id = ?`, [Project_name, id], function (err) {
    if (err) {
      res.status(500).send(err);
    } else {
      res.status(200).json({message: 'Project updated successfully'});
    }
  });
});

router.delete('/:id', (req, res) => {
  const id = req.params.id;
  db.run(`DELETE FROM Project WHERE Project_id = ?`, [id], function (err) {
    if (err) {
      res.status(500).send(err);
    } else {
      res.status(200).json({message: 'Project deleted successfully'});
    }
  });
});

router.post('/', (req, res) => {
  const {Project_name} = req.body;
  db.run(`INSERT INTO Project (Project_name) VALUES (?)`, [Project_name], function (err) {
    if (err) {
      res.status(500).send(err);
    } else {
      res.status(200).json({message: 'Project added successfully'});
    }
  });
});


module.exports = router;
