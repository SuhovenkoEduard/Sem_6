import request from 'supertest'
import { app } from '../index'

describe('GET api/pizzas', () => {
  it('should return all pizzas', done => {
    request(app)
      .get('/api/pizzas')
      .expect(200)
      .expect('Content-Type', 'application/json; charset=utf-8')
      .end(err => {
        if (err) {
          return done(err)
        }
        done()
      })
  })
})

describe('GET api/pizzas/:id', () => {
  it('should return a single pizza', done => {
    request(app)
      .get('/api/pizzas/2')
      .expect(200)
      .expect('Content-Type', 'application/json; charset=utf-8')
      .end(err => {
        if (err) {
          return done(err)
        }
        done()
      })
  })
})

describe('PUT api/pizzas/', () => {
  it('should update a single pizza', done => {
    request(app)
      .put('/api/pizzas/2')
      .send({
        caloric: Math.floor(Math.random() * 1000),
      })
      .expect(200)
      .expect('Content-Type', 'application/json; charset=utf-8')
      .end(err => {
        if (err) {
          return done(err)
        }
        done()
      })
  })
})
