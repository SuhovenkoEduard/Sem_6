import React, { useEffect, useState } from 'react'
import classNames from 'classnames'
import Button from 'react-bootstrap/Button'

import { useAuthUser } from 'react-auth-kit'
import { useFetch } from '../../hooks/useFetch'
import { PizzaDTO } from '../../constants/models'
import { createGetCatalogRequest } from '../../api/api'
import { UserType } from '../../constants/types'

import '../../scss/components/pages/catalog.scss'
import { OrderModal } from './roles/OrderModal'

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

  const openOrderModal = (pizzaId: number) => {
    setSelectedPizza(pizzas.find((pizza) => pizza.id === pizzaId)!)
    setIsOrderModalShown(true)
  }

  const onOrderModalClose = () => {
    setIsOrderModalShown(false)
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
                <OrderModal
                  isOrderModalShown={isOrderModalShown}
                  selectedPizza={selectedPizza}
                  userData={userData}
                  onOrderModalClose={onOrderModalClose}
                />
              )}
            </div>
          )}
        </>
      )}
    </div>
  )
}
