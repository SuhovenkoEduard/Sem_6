import React, { useState } from 'react'
import { Input } from 'antd'
import { Button } from 'antd'

import '../../css/inputComponent.css'

type InputComponentProps = {
  className: string
  addString: (s: string) => void
  searchString: (s: string) => void
}

export const InputComponent = (props: InputComponentProps) => {
  const [search, setSearch] = useState('')
  const [add, setAdd] = useState('')

  const onAddChange = (event: React.ChangeEvent) => {
    const target = event.target as HTMLInputElement
    setAdd(target.value)
  }

  const onSearchChange = (event: React.ChangeEvent) => {
    const target = event.target as HTMLInputElement
    setSearch(target.value)
  }

  const { className, addString, searchString } = props
  return (
    <div className={className}>
      <h1 className="inputHeader">Input form</h1>
      <div className="inputLineContainer">
        <Input
          className="searchInput"
          placeholder="Input string to search"
          onChange={onSearchChange}
        />
        <Button
          className="searchButton"
          size="middle"
          onClick={() => searchString(search)}
        >Search</Button>
      </div>
      <div className="inputLineContainer">
        <Input
          className="addInput"
           placeholder="Input string to add"
           onChange={onAddChange}
        />
        <Button
          className="addButton"
          size="middle"
          onClick={() => addString(add)}
        >Add</Button>
      </div>
    </div>
  )
}
