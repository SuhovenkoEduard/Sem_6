import React, { useState } from 'react'
import { Button, Form } from 'react-bootstrap'
import { AccountType } from '../../../constants/types'

import '../../../scss/components/sign/sign-in-form.scss'

type SignInFormProps = {
  goToHome: () => void
  goToSignUp: () => void
  onSignIn: (account: AccountType) => Promise<void>
}

export const SignInForm = (props: SignInFormProps) => {
  const { goToHome, goToSignUp, onSignIn } = props
  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')

  const handleSubmit = (e: React.SyntheticEvent) => {
    e.preventDefault()
    onSignIn({ email, password })
  }

  return (
    <div className="sign-in-form-container">
      <Form
        className="sign-in-form"
        onSubmit={handleSubmit}
      >
        <div className="form-header">Sign In</div>
        <Form.Group className="mb-1" controlId="formBasicEmail">
          <Form.Label>Email address</Form.Label>
          <Form.Control
            required
            value={email}
            placeholder="Email"
            onChange={(e) => setEmail(e.target.value)}
          />
        </Form.Group>
        <Form.Group className="mb-1" controlId="formBasicPassword">
          <Form.Label>Password</Form.Label>
          <Form.Control
            type="password"
            required
            value={password}
            placeholder="Password"
            onChange={(e) => setPassword(e.target.value)}
          />
        </Form.Group>
        <div className="buttons-container">
          <Button variant="outline-primary" color="secondary" onClick={() => goToSignUp()}>
            Sign Up
          </Button>
          <Button variant="outline-secondary" onClick={() => goToHome()}>
            Home
          </Button>
          <Button type="submit" variant="outline-danger" color="primary">
            Sign In
          </Button>
        </div>
      </Form>
    </div>
  )
}
