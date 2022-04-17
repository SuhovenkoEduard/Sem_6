import React, { useState } from 'react'
import TextField from '@material-ui/core/TextField'
import Button from '@material-ui/core/Button'
import { AccountType, ClientType } from '../../constants/types'

import styles from '../../scss/components/sign/sign-up-form.module.scss'

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

  const handleSubmit = (e: React.SyntheticEvent) => {
    e.preventDefault()
    onSignUp({
      name,
      phoneNumber,
      description,
      email,
      password,
    })
  }

  return (
    <div className={styles.formContainer}>
      <div className={styles.formHeader}>Sign Up</div>
      <form className={styles.signUpForm} onSubmit={handleSubmit}>
        <TextField
          label="Name"
          variant="filled"
          required
          value={name}
          onChange={(e) => setName(e.target.value)}
        />
        <TextField
          label="Phone number"
          variant="filled"
          required
          value={phoneNumber}
          onChange={(e) => setPhoneNumber(e.target.value)}
        />
        <TextField
          label="Description"
          variant="filled"
          required
          value={description}
          onChange={(e) => setDescription(e.target.value)}
        />
        <TextField
          label="Email"
          variant="filled"
          type="email"
          required
          value={email}
          onChange={(e) => setEmail(e.target.value)}
        />
        <TextField
          label="Password"
          variant="filled"
          type="password"
          required
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />
        <div className={styles.buttonsContainer}>
          <Button variant="contained" color="secondary" onClick={() => goToSignIn()}>
            Sign In
          </Button>
          <Button variant="contained" onClick={() => goToHome()}>
            Home
          </Button>
          <Button type="submit" variant="contained" color="primary">
            Sign Up
          </Button>
        </div>
      </form>
    </div>
  )
}
