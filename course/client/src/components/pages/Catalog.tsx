import React, { useEffect, useState } from 'react'
import classNames from 'classnames'
// import { useNavigate } from 'react-router-dom'
import Modal from 'react-bootstrap/Modal'
import Button from 'react-bootstrap/Button'

import { useAuthUser } from 'react-auth-kit'
import { Form } from 'react-bootstrap'
import { useFetch } from '../../hooks/useFetch'
import { PizzaDTO } from '../../constants/models'
import { createGetCatalogRequest } from '../../api/api'
import { UserType } from '../../constants/types'

import '../../scss/components/pages/catalog.scss'

export const Catalog = () => {
  // const navigate = useNavigate()
  const [pizzas, setPizzas] = useState<PizzaDTO[]>([])
  const [selectedPizza, setSelectedPizza] = useState<PizzaDTO | null>(null)

  const authData = useAuthUser()
  const userData = authData() as UserType

  const {
    loading, request, error,
  } = useFetch()

  useEffect(() => {
    const getData = async () => {
      try {
        const pizzas: PizzaDTO[] = await request(createGetCatalogRequest())
        setPizzas(pizzas)
      } catch (e: any) {
        console.log(e.message)
      }
    }
    getData()
  }, [])

  const [isOrderModalShown, setIsOrderModalShown] = useState(false)

  const toggleIsOrderModalOpen = () => setIsOrderModalShown(!isOrderModalShown)

  const openOrderModal = (pizzaId: number) => {
    setSelectedPizza(pizzas.find((pizza) => pizza.id === pizzaId)!)
    setIsOrderModalShown(true)
  }

  const isClientLogged = !!userData?.client

  return (
    <div className="catalog-container">
      {/* {profileComponent} */}
      <div className="catalog-container__header">Catalog</div>
      {error && (<div className="catalog-container__error">Something went wrong...</div>)}
      {!error && (
        <>
          {loading && (<div className="catalog-container__loading">Loading...</div>)}
          {!loading && (
            <div className="catalog-container__body">
              {pizzas.map((pizza: PizzaDTO, index: number) => (
                <div
                  key={pizza.id}
                  className={classNames('catalog-container__body__card', {
                    'even': index % 2 === 0,
                  })}
                >
                  <div className="catalog-container__body__card__image-container">
                    <img src={pizza.imageUrl} alt="" />
                  </div>
                  <div className="catalog-container__body__card__data">
                    <div className="catalog-container__body__card__data__name">{pizza.name}</div>
                    <div className="catalog-container__body__card__data__description">{pizza.description}</div>
                  </div>
                  {!userData?.client && (
                    <div>You must be logged as client.</div>
                  )}
                  <Button
                    disabled={!isClientLogged}
                    variant="danger"
                    className="catalog-container__body__card__order"
                    onClick={() => openOrderModal(pizza.id)}
                  >
                    Order now
                  </Button>
                </div>
              ))}
              {isClientLogged && selectedPizza && (
                <Modal
                  show={isOrderModalShown}
                  onHide={toggleIsOrderModalOpen}
                  backdrop="static"
                  keyboard={false}
                  centered
                >
                  <Modal.Header closeButton>
                    <Modal.Title>Order pizza</Modal.Title>
                  </Modal.Header>
                  <Modal.Body>
                    <Form.Group className="mb-2">
                      <Form.Label>Client Name</Form.Label>
                      <Form.Text as="div">{userData!.client!.name}</Form.Text>
                    </Form.Group>
                    <Form.Group className="mb-2">
                      <Form.Label>Start Date</Form.Label>
                      <Form.Text as="div">{new Date().toUTCString()}</Form.Text>
                    </Form.Group>
                    <Form.Group className="mb-2">
                      <Form.Label>Selected Pizza</Form.Label>
                      <Form.Text as="div">{selectedPizza!.name}</Form.Text>
                    </Form.Group>
                    <Form.Group className="mb-2">
                      <Form.Label>Amount of pizza</Form.Label>
                      <Form.Text as="div">1</Form.Text>
                    </Form.Group>
                    <Form.Group className="mb-2">
                      <Form.Label>Address</Form.Label>
                      <Form.Control type="text" placeholder="Address" />
                    </Form.Group>
                    <Form.Group className="mb-2">
                      <Form.Label>End Date</Form.Label>
                      <Form.Control type="date" placeholder="End Date" />
                    </Form.Group>
                  </Modal.Body>
                  <Modal.Footer>
                    <Button
                      variant="outline-secondary"
                      onClick={toggleIsOrderModalOpen}
                    >
                      Close
                    </Button>
                    <Button variant="outline-secondary">Order</Button>
                  </Modal.Footer>
                </Modal>
              )}
            </div>
          )}
        </>
      )}
    </div>
  )
}
