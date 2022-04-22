import React, { useEffect, useState } from 'react'
import classNames from 'classnames'
// import { useNavigate } from 'react-router-dom'
import Modal from 'react-bootstrap/Modal'
import Button from 'react-bootstrap/Button'

import { useFetch } from '../../hooks/useFetch'
import { PizzaDTO } from '../../constants/models'
import { createGetCatalogRequest } from '../../api/api'

import '../../scss/components/pages/catalog.scss'

export const Catalog = () => {
  // const navigate = useNavigate()
  const [pizzas, setPizzas] = useState<PizzaDTO[]>([])

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

  const [isOrderModalOpen, setIsOrderModalOpen] = useState(false)

  const toggleIsOrderModalOpen = () => setIsOrderModalOpen(!isOrderModalOpen)

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
                  <button
                    className="catalog-container__body__card__order"
                    type="button"
                    onClick={toggleIsOrderModalOpen}
                  >
                    Order now
                  </button>
                </div>
              ))}
              <Modal
                show={isOrderModalOpen}
                onHide={toggleIsOrderModalOpen}
                backdrop="static"
                keyboard={false}
                // animation={false}
                centered
              >
                <Modal.Header closeButton>
                  <Modal.Title>Modal title</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                  <p>Modal body text goes here.</p>
                </Modal.Body>
                <Modal.Footer>
                  <Button
                    variant="secondary"
                    onClick={toggleIsOrderModalOpen}
                  >
                    Close
                  </Button>
                  <Button variant="primary">Save changes</Button>
                </Modal.Footer>
              </Modal>
            </div>
          )}
        </>
      )}
    </div>
  )
}
