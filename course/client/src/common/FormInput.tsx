import React, { ElementType } from 'react'
import { Form } from 'react-bootstrap'

type FormInputProps = {
  name: string
  label: string
  value: string
  onChange: (propName: string, value: string) => void
  type?: string
  placeholder?: string
  inputAs?: ElementType
  required?: boolean
}

export const FormInput = (props: FormInputProps) => {
  const {
    name,
    label,
    value,
    onChange,
    type = 'text',
    placeholder = label,
    inputAs = 'input',
    required = false,
  } = props

  return (
    <Form.Group>
      <Form.Label>{label}</Form.Label>
      <Form.Control
        name={name}
        placeholder={placeholder}
        type={type}
        value={value}
        onChange={(e: React.SyntheticEvent) => onChange(name, (e.target as HTMLInputElement).value)}
        required={required}
        as={inputAs}
      />
    </Form.Group>
  )
}
