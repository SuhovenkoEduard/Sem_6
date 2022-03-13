import { Table } from "antd";
import { ExpandableTableCell } from './ExpandableTableCell'

import '../css/hashTableContainer.css'

type HashTableProps = {
  className: string
  data: string[][]
}

export type DictItem = {
  hash: number
  collisions: string[]
  count: number
}

const columns = [
  {
    title: 'Hash',
    dataIndex: 'hash',
    key: 'hash',
  },
  {
    title: 'Collisions',
    dataIndex: 'collisions',
    key: 'collisions',
    render: (text: string, record: DictItem) =>  <ExpandableTableCell item={record} />
  },
  {
    title: 'Count',
    dataIndex: 'count',
    key: 'count',
  }
];

export const HashTableContainer = (props: HashTableProps) => {
  const { className, data } = props
  return (
    <div className={className}>
      <Table
        
        bordered
        dataSource={data.map((lst: string[], index: number) => ({
        hash: index,
        collisions: lst,
        count: lst.length
      }))} columns={columns} />
    </div>
  )
}
