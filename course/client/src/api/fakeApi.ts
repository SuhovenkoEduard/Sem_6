// import { LongAccountData, ShortAccountData } from '../constants/types'
import { ACCOUNTS_DATA } from '../constants/constants'

export const fakeApi = () => {}

export const getAccountData = (shortAccountData: any) => {
  return ACCOUNTS_DATA
    .find((account: any) => account.login === shortAccountData.login
      && account.password === shortAccountData.password)
}

// export const signUpAccount = (longAccountData: LongAccountData) => {
//   ACCOUNTS_DATA.push(longAccountData)
// }

