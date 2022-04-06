const request = require('supertest');
const app = require('../index');

describe('GET api/employee', () => {
  it('should return all employees', (done) => {
    request(app)
      .get('/api/employee')
      .expect(200)
      .expect('Content-Type', /json/)
      .end((err, res) => {
        if (err) {
          return done(err);
        }
        done();
      });
  });
});

describe('GET api/employee/:id', () => {
  it('should return a single employee', (done) => {
    request(app)
      .get('/api/employee/1')
      .expect(200)
      .expect('Content-Type', /json/)
      .end((err, res) => {
        if (err) {
          return done(err);
        }
        done();
      });
  });
});

describe('POST api/employee', () => {
  it('should create a new employee', (done) => {
    request(app)
      .post('/api/employee/')
      .send({
        Name: 'test', Job_Title: 'test', Sallary: 60000, Dept_id: 1, Project_id: 1
      })
      .end((err, res) => {
        console.log(res.body);
        if (err) {
          return done(err);
        }
        done();
      });
  });
});

describe('PUT api/employee/:id', () => {
  it('should update a single employee', (done) => {
    request(app)
      .put('/api/employee/3')
      .send({
        Name: 'test', Job_Title: 'test', Sallary: 60000, Dept_id: 1, Project_id: 1
      })
      .expect(200)
      .end((err, res) => {
        console.log(res.body);
        if (err) {
          return done(err);
        }
        done();
      });
  });
});
