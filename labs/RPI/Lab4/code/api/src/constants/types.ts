export enum Size {
  small = 'small',
  middle = 'middle',
  large = 'large',
}

export type Pizza = {
  name: string
  size: Size
  hasCheese: boolean
  hasMeat: boolean
}

