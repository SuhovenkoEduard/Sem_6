import React from 'react'
import { useAuthUser } from 'react-auth-kit'
import { UserType } from '../../constants/types'

export const Profile = () => {
  const authUser = useAuthUser()
  const authedUser = authUser() as UserType

  return (
    <div className="mx-auto my-auto border border-2 p-3 d-grid">
      <div className="border border-2 m-2 p-2 d-grid">
        <div className="mx-auto">Account Info</div>
        <div>
          <span className="mx-2">Email:</span>
          <span className="mx-2">{authedUser.account.email}</span>
        </div>
      </div>
      {authedUser?.client && (
        <div className="border border-2 p-2 m-2 d-grid">
          <div className="mx-auto">Client Info</div>
          <div>
            <span className="mx-2">Name:</span>
            <span className="mx-2">{authedUser.client.name}</span>
          </div>
          <div>
            <span className="mx-2">Phone Number:</span>
            <span className="mx-2">{authedUser.client.phoneNumber}</span>
          </div>
          <div>
            <span className="mx-2">Description:</span>
            <span className="mx-2">{authedUser.client.description}</span>
          </div>
        </div>
      )}
      {authedUser?.courier && (
        <div className="border border-2 m-2 p-2 d-grid">
          <div className="mx-auto">Courier</div>
          <div>
            <div>
              <span className="mx-2">Name:</span>
              <span className="mx-2">{authedUser.courier.name}</span>
            </div>
            <div>
              <span className="mx-2">Salary:</span>
              <span className="mx-2">{`${authedUser.courier.salary} $`}</span>
            </div>
            <div>
              <span className="mx-2">Description:</span>
              <span className="mx-2">{authedUser.courier.description}</span>
            </div>
          </div>
        </div>
      )}
      {authedUser?.manager && (
        <div className="border border-2 m-2 p-2 d-grid">
          <div className="mx-auto">Manager</div>
          <div>
            <div>
              <span className="mx-2">Name:</span>
              <span className="mx-2">{authedUser.manager.name}</span>
            </div>
            <div>
              <span className="mx-2">Salary:</span>
              <span className="mx-2">{`${authedUser.manager.salary} $`}</span>
            </div>
            <div>
              <span className="mx-2">Description:</span>
              <span className="mx-2">{authedUser.manager.description}</span>
            </div>
          </div>
        </div>
      )}
    </div>
  )
}
