import { DictItem } from './HashTableContainer'
import { Dropdown } from 'antd'
import { ExpandedMenu } from './ExpandedMenu'

type TableRowProps = {
  item: DictItem
}

export const ExpandableTableCell = (props: TableRowProps) => {
  const { item } = props
  return (
    <Dropdown overlay={(item.collisions ? <ExpandedMenu list={item.collisions}/> : <div/>)}>
        <div> {item.collisions[0] ?? 'Nothing'} </div>
    </Dropdown>
  )
}
