import React, { useState } from 'react'
import './App.css';
import { HashTableContainer } from './components/HashTableContainer'
import { InputComponent } from './components/lab/InputComponent'
import { ListContainer } from './components/ListContainer'
import { HashTable } from './components/lab/HashTable'
import { OutputComponent } from './components/lab/OutputComponent';


function App() {
  const [hashTable] = useState(new HashTable())
  const [list, setList] = useState<string[]>([])

  const [result, setResult] = useState({
    position: {
      list: 'undefined',
      hashTable: 'hashTable'
    },
    searchTime: {
      list: 'undefined',
      hashTable: 'undefined'
    }
  })

  const addString = (s: string) => {
    hashTable.addString(s)
    setList([...list, s])
  }

  const searchString = (s: string) => {
    const listIndex = list.indexOf(s)
    const hashTableIndex = hashTable.indexOf(s)
    setResult({
      ...result,
      position: {
        list: listIndex.toString(),
        hashTable: hashTableIndex.toString()
      }
    })
  }

  return (
    <div className="App">
      <div className="outputContainer">
        <ListContainer className="listContainer" items={list} />
        <HashTableContainer className="hashTableContainer" data={hashTable.data} />
      </div>
      <InputComponent
        className="inputComponent"
        addString={addString}
        searchString={searchString}
      />
      <OutputComponent
        className="outputComponent"
        position={result.position}
        searchTime={result.searchTime}
      />
    </div>
  );
}

export default App;
