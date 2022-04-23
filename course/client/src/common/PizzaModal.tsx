import React from 'react'
import Modal from 'react-bootstrap/Modal'
import Button from 'react-bootstrap/Button'

type PizzaModalProps = {
  isModalShown: boolean
  onCancel: () => void
  onSave?: () => void
  modalTitle: string
  children: React.ReactChild | React.ReactChild[]
  isButtonsDisabled?: boolean
}

const getDefaultSaveButton = (onSave: () => void, disabled: boolean) => (
  <Button variant="outline-primary" onClick={onSave} disabled={disabled}>
    Save
  </Button>
)

export const PizzaModal = (props: PizzaModalProps) => {
  const {
    isModalShown,
    onCancel,
    onSave,
    modalTitle,
    children,
    isButtonsDisabled = false,
  } = props

  return (
    <Modal
      show={isModalShown}
      onHide={onCancel}
      backdrop="static"
      keyboard={false}
      centered
    >
      <Modal.Header closeButton>
        <Modal.Title>{modalTitle}</Modal.Title>
      </Modal.Header>
      <Modal.Body>{children}</Modal.Body>
      <Modal.Footer>
        <Button
          variant="outline-secondary"
          onClick={onCancel}
          disabled={isButtonsDisabled}
        >
          Cancel
        </Button>
        {onSave && getDefaultSaveButton(onSave, isButtonsDisabled)}
      </Modal.Footer>
    </Modal>
  )
}
