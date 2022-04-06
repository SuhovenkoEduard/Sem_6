const express = require('express');
const router = express.Router();
const sqlite3 = require('sqlite3').verbose();
const db = new sqlite3.Database('../database.db');

router.get('/', (req, res) => {
  db.all('SELECT * FROM Employee', (err, rows) => {
    if (err) {
      res.status(500).send(err);
    } else {
      res.status(200).json(rows);
    }
  });
});

router.get('/:id', (req, res) => {
  const id = req.params.id;
  db.get('SELECT * FROM Employee WHERE id = ?', [id], (err, row) => {
    if (err) {
      res.status(500).send(err);
    } else {
      res.status(200).json(row);
    }
  });
});

router.put('/:id', (req, res) => {
  const id = req.params.id;
  const {Name, Job_Title, Phone_no, Sallary} = req.body;
  db.run(`UPDATE Employee SET Name = ?, Job_Title = ?, Phone_no = ?, Sallary = ? WHERE id = ?`, [Name, Job_Title, Phone_no, Sallary, id], function (err) {
    if (err) {
      res.status(500).send(err);
    } else {
      res.status(200).json({message: 'Employee updated successfully'});
    }
  });
});

router.post('/', (req, res) => {
  const {Name, Job_Title, Phone_no, Sallary, Dept_id, Project_id} = req.body;
  db.run(`INSERT INTO Employee (Name, Job_Title, Phone_no, Sallary) VALUES (?, ?, ?, ?, ?, ?)`, [Name, Job_Title, Phone_no, Sallary, Dept_id, Project_id], function (err) {
    if (err) {
      res.status(500).send(err);
    } else {
      res.status(200).json({message: 'Employee added successfully'});
    }
  });
});

router.delete('/:id', (req, res) => {
  const id = req.params.id;
  db.run(`DELETE FROM Employee WHERE id = ?`, [id], function (err) {
    if (err) {
      res.status(500).send(err);
    } else {
      res.status(200).json({message: 'Employee deleted successfully'});
    }
  });
});


module.exports = router;
