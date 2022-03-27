import React, { useState } from 'react'
import TextField from '@material-ui/core/TextField'
import Button from '@material-ui/core/Button'

import { LongAccountData } from '../../constants/types'

import styles from '../../scss/components/sign/sign-up-form.module.scss'

type SignUpFormProps = {
  goToHome: () => void
  goToSignIn: () => void
  onSignUp: (account: LongAccountData) => void
}

export const SignUpForm = (props: SignUpFormProps) => {
  const { goToHome, goToSignIn, onSignUp } = props
  const [name, setName] = useState('')
  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')

  const handleSubmit = (e: React.SyntheticEvent) => {
    e.preventDefault()
    onSignUp({
      login: email,
      password,
      user: { name },
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
