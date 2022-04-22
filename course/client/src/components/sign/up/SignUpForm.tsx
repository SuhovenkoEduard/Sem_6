import React, { useState } from 'react'
import { Button, Form } from 'react-bootstrap'
import { AccountType, ClientType } from '../../../constants/types'

import '../../../scss/components/sign/sign-up-form.scss'

type SignUpFormProps = {
  goToHome: () => void
  goToSignIn: () => void
  onSignUp: (clientData: ClientType & AccountType) => Promise<void>
}

export const SignUpForm = (props: SignUpFormProps) => {
  const { goToHome, goToSignIn, onSignUp } = props
  const [name, setName] = useState('')
  const [phoneNumber, setPhoneNumber] = useState<string>('')
  const [description, setDescription] = useState<string>('')
  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')

  const handleSubmit = () => {
    onSignUp({
      name,
      phoneNumber,
      description,
      email,
      password,
    })
  }

  return (
    <div className="sign-up-form-container">
      <Form
        className="sign-up-form"
        onSubmit={handleSubmit}
      >
        <div className="form-header">Sign Up</div>
        <Form.Group className="mb-1" controlId="formName">
          <Form.Label>Name</Form.Label>
          <Form.Control
            placeholder="Name"
            required
            value={name}
            onChange={(e) => setName(e.target.value)}
          />
        </Form.Group>
        <Form.Group className="mb-1" controlId="formPhoneNumber">
          <Form.Label>Phone Number</Form.Label>
          <Form.Control
            placeholder="Phone Number"
            required
            value={phoneNumber}
            onChange={(e) => setPhoneNumber(e.target.value)}
          />
        </Form.Group>
        <Form.Group className="mb-1" controlId="formDescription">
          <Form.Label>Description</Form.Label>
          <Form.Control
            placeholder="Description"
            required
            value={description}
            onChange={(e) => setDescription(e.target.value)}
          />
        </Form.Group>
        <Form.Group className="mb-1" controlId="formEmail">
          <Form.Label>Email address</Form.Label>
          <Form.Control
            required
            value={email}
            placeholder="Email"
            onChange={(e) => setEmail(e.target.value)}
          />
        </Form.Group>
        <Form.Group className="mb-1" controlId="formPassword">
          <Form.Label>Password</Form.Label>
          <Form.Control
            type="password"
            placeholder="Password"
            required
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
        </Form.Group>
        <div className="buttons-container">
          <Button variant="outline-primary" onClick={() => goToSignIn()}>
            Sign In
          </Button>
          <Button variant="outline-secondary" onClick={() => goToHome()}>
            Home
          </Button>
          <Button type="submit" variant="outline-danger">
            Sign Up
          </Button>
        </div>
      </Form>
    </div>
  )
}
