export type ShortAccountData = {
  login: string
  password: string
}

export type UserType = {
  name: string
  age?: number
}

export type LongAccountData = ShortAccountData & { user: UserType }
