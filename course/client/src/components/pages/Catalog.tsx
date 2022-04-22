import React, { useEffect, useState } from 'react'
import classNames from 'classnames'
// import { useNavigate } from 'react-router-dom'
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

  return (
    <div className="catalog-container">
      {/* {profileComponent} */}
      <div className="catalog-container__header">Catalog</div>
      {error && (<div className="catalog-container__error">Something went wrong...</div>)}
      {!error && (
        <>
          {loading && (<div className="catalog-container__loading">Loading...</div>)}
          <div className="catalog-container__body">
            {!loading && pizzas.map((pizza: PizzaDTO, index: number) => (
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
                >
                  Order now
                </button>
              </div>
            ))}
          </div>
        </>
      )}
    </div>
  )
}
