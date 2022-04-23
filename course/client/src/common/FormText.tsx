import React, { ElementType } from 'react'
import { Form } from 'react-bootstrap'

type FormTextProps = {
  label: string
  value: string
  labelClassName?: string
  valueClassName?: string
  textAs?: ElementType
}

export const FormText = (props: FormTextProps) => {
  const {
    label,
    value,
    labelClassName = 'mt-2 mb-0',
    textAs = 'div',
    valueClassName = '',
  } = props

  return (
    <Form.Group>
      <Form.Label className={labelClassName}>{label}</Form.Label>
      <Form.Text className={valueClassName} as={textAs}>{value}</Form.Text>
    </Form.Group>
  )
}
