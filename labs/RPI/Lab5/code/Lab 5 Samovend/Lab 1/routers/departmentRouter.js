const express = require('express');
const router = express.Router();
const sqlite3 = require('sqlite3').verbose();
const db = new sqlite3.Database('../database.db');


router.get('/', (req, res) => {
  db.all('SELECT * FROM Department', (err, rows) => {
    if (err) {
      res.status(500).send(err);
    } else {
      res.status(200).json(rows);
    }
  });
});

router.get('/:id', (req, res) => {
  const id = req.params.id;
  db.get('SELECT * FROM Department WHERE Dept_id = ?', [id], (err, row) => {
    if (err) {
      res.status(500).send(err);
    } else {
      res.status(200).json(row);
    }
  });
});

router.post('/', (req, res) => {
  const {Dept_name} = req.body;
  db.run(`INSERT INTO Department (Dept_name) VALUES (?)`, [Dept_name], function (err) {
    if (err) {
      res.status(500).send(err);
    } else {
      res.status(200).json({message: 'Department added successfully'});
    }
  });
});

router.put('/:id', (req, res) => {
  const id = req.params.id;
  const {Dept_name} = req.body;
  db.run(`UPDATE Department SET Dept_name = ? WHERE Dept_id = ?`, [Dept_name, id], function (err) {
    if (err) {
      res.status(500).send(err);
    } else {
      res.status(200).json({message: 'Department updated successfully'});
    }
  });
});

router.delete('/:id', (req, res) => {
  const id = req.params.id;
  db.run(`DELETE FROM Department WHERE Dept_id = ?`, [id], function (err) {
    if (err) {
      res.status(500).send(err);
    } else {
      res.status(200).json({message: 'Department deleted successfully'});
    }
  });
});


module.exports = router;
