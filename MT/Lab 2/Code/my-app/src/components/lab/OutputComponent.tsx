type OutputComponentProps = {
  className: string
  position: {
    list: string,
    hashTable: string
  },
  searchTime: {
    list: string,
    hashTable: string
  }
}

export const OutputComponent = (props: OutputComponentProps) => {
  const { className, position, searchTime } = props
  return (
    <div className={className}>
      Position: {JSON.stringify(position)}
      SearchTime: {JSON.stringify(searchTime)}
    </div>
  )
}
