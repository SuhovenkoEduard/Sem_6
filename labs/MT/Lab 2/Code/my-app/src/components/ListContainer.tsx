import { List } from 'antd'

type ListContainerProps = {
  items: string[]
  className: string
}

export const ListContainer = (props: ListContainerProps) => {
  const { items, className } = props

  return (
    <List
      className={className}
      header={<div>List:</div>}
      dataSource={items}
      bordered
      renderItem={(line: string, index: number) => (<List.Item key={index}>{line}</List.Item>)}
    />
  )
}
