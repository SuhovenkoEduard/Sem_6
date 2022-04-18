import React, { useState } from 'react'
import TextField from '@material-ui/core/TextField'
import Button from '@material-ui/core/Button'
import { AccountType } from '../../../constants/types'

import styles from '../../../scss/components/sign/sign-in-form.module.scss'

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
    <div className={styles.formContainer}>
      <div className={styles.formHeader}>Sign In</div>
      <form className={styles.signInForm} onSubmit={handleSubmit}>
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
          <Button variant="contained" color="secondary" onClick={() => goToSignUp()}>
            Sign Up
          </Button>
          <Button variant="contained" onClick={() => goToHome()}>
            Home
          </Button>
          <Button type="submit" variant="contained" color="primary">
            Sign In
          </Button>
        </div>
      </form>
    </div>
  )
}
