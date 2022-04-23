import { Form } from 'react-bootstrap'
import React, { useState } from 'react'
import Button from 'react-bootstrap/Button'
import { OrderType, UserType } from '../../../../../constants/types'
import { PizzaDTO } from '../../../../../constants/models'
import { PizzaModal } from '../../../../../common/PizzaModal'
import { FormText } from '../../../../../common/FormText'
import { FormInput } from '../../../../../common/FormInput'
import { useFetch } from '../../../../../hooks/useFetch'
import { createAddOrderRequest } from '../../../../../api/api'

type OrderModalProps = {
  isOrderModalShown: boolean
  onOrderModalClose: () => void
  userData: UserType
  selectedPizza: PizzaDTO | null
}

type OrderState = {
  address: string
  endDate: string
}

const defaultOrderState: OrderState = {
  address: '',
  endDate: '',
}

export const OrderModal = (props: OrderModalProps) => {
  const {
    isOrderModalShown,
    onOrderModalClose,
    userData,
    selectedPizza,
  } = props

  const [startDate] = useState(new Date().toUTCString())
  const [orderState, setOrderState] = useState<OrderState>(defaultOrderState)
  const {
    error, loading, request, clearError,
  } = useFetch()

  const clearForm = () => setOrderState({ ...defaultOrderState })

  const onChange = (propName: string, value: string) => {
    setOrderState({
      ...orderState,
      [propName]: value,
    })
  }

  const onClose = () => {
    clearError()
    clearForm()
    onOrderModalClose()
  }

  const onSubmit = (e: React.SyntheticEvent) => {
    e.preventDefault()
    clearError()

    const createOrderAsync = async () => {
      try {
        const state: OrderType = {
          clientId: userData.client!.id,
          pizzaId: selectedPizza!.id,
          address: orderState.address,
          startDate,
          endDate: orderState.endDate,
        }
        await request(createAddOrderRequest(state))
        return Promise.resolve()
      } catch (e: any) {
        console.log(e.message)
        return Promise.reject()
      }
    }

    createOrderAsync().then(() => {
      clearError()
      clearForm()
      onOrderModalClose()
    })
  }

  return (
    <PizzaModal
      isModalShown={isOrderModalShown}
      onCancel={onClose}
      modalTitle="Order Pizza"
      isButtonsDisabled={loading}
    >
      <Form onSubmit={onSubmit}>
        <FormText label="Client Name" value={userData!.client!.name} />
        <FormText label="Start Date" value={startDate} />
        <FormText label="Selected Pizza" value={selectedPizza!.name} />
        <FormText label="Price" value={`${selectedPizza!.price}$`} />
        <FormText label="Amount of pizza" value="1" />
        <FormInput
          name="address"
          label="Address"
          required
          value={orderState.address}
          onChange={onChange}
        />
        <FormInput
          type="date"
          name="endDate"
          label="End Date"
          required
          value={orderState.endDate}
          onChange={onChange}
        />
        <Button
          className="mt-3"
          variant="outline-primary"
          type="submit"
          disabled={loading || !!error}
        >
          Save
        </Button>
        {error && (
          <>
            <FormText
              label="Error"
              value="Something went wrong..."
            />
            <Button type="submit" className="mt-2" variant="outline-danger" onClick={onSubmit}>
              Try again!
            </Button>
          </>
        )}
      </Form>
    </PizzaModal>
  )
}
