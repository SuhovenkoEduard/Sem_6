import { Menu } from "antd"

type ExpandedMenuProps = {
  list: string[]
}

export const ExpandedMenu = (props: ExpandedMenuProps) => {
  const { list } = props
  return (
    <Menu>
      {list.map((x: string, index: number) => (
        <Menu.Item key={index}>{x}</Menu.Item>
      ))}
    </Menu>
  )
}
