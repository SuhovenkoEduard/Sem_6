import React, { useEffect, useState } from 'react'
import { useAuthUser, useIsAuthenticated } from 'react-auth-kit'
import { Button } from 'react-bootstrap'
import { useFetch } from '../../hooks/useFetch'
import {
  createAddCommentsRequest,
  createDeleteCommentsRequest,
  createGetCommentsRequest,
} from '../../api/api'
import { CommentType, UserType } from '../../constants/types'

import '../../scss/components/pages/comments.scss'

export const Comments = () => {
  const isAuthenticated = useIsAuthenticated()
  const authData = useAuthUser()
  const userData = authData() as UserType
  const [comments, setComments] = useState<CommentType[]>([])
  const {
    loading, request, error,
  } = useFetch()

  const [currentComment, setCurrentComment] = useState<string>('')
  const onChangeComment = ({ target }: React.SyntheticEvent) => {
    const input = target as HTMLInputElement
    setCurrentComment(input.value)
  }
  const addComment = () => {
    const addData = async () => {
      if (currentComment === '') return
      try {
        const comment = {
          clientId: userData.client!.id,
          content: currentComment,
          date: new Date().toUTCString(),
        }
        const addedComment = await request(createAddCommentsRequest(comment))
        setComments([...comments, addedComment])
        setCurrentComment('')
      } catch (e: any) {
        console.log(e.message)
      }
    }
    addData()
  }

  const deleteComment = (id: number) => {
    const deleteData = async () => {
      try {
        const comments = await request(createDeleteCommentsRequest(id))
        setComments(comments)
      } catch (e: any) {
        console.log(e.message)
      }
    }
    deleteData()
  }

  useEffect(() => {
    const getData = async () => {
      try {
        const comments: CommentType[] = await request(createGetCommentsRequest())
        setComments(comments)
      } catch (e: any) {
        console.log(e.message)
      }
    }
    getData()
  }, [])

  return (
    <div className="comments-container">
      {error && <div>{`Error: ${error}`}</div>}
      {loading && <div>Loading...</div>}
      {!loading && !error && (
        <>
          {isAuthenticated() && userData?.client && (
            <div className="comment-input-container">
              <label className="comment-textarea-label" htmlFor="comment-textarea">
                <div>Your comment:</div>
                <textarea
                  name="comment-textarea"
                  value={currentComment}
                  onChange={onChangeComment}
                />
              </label>
              <Button
                className="comment-button"
                variant="outline-primary"
                onClick={addComment}
              >
                Add
              </Button>
            </div>
          )}
          <div className="comments-cards-container">
            <div>Comments section: </div>
            {comments.map((comment) => (
              <div className="comment-card" key={comment.id}>
                <div>{`ClientName: ${comment.clientName}`}</div>
                <div>{`Content: ${comment.content}`}</div>
                <div>{`Date: ${comment.date}`}</div>
                {userData?.client?.id === comment.clientId && (
                  <button
                    type="button"
                    onClick={() => deleteComment(comment.id)}
                  >
                    Delete
                  </button>
                )}
              </div>
            ))}
          </div>
        </>
      )}
    </div>
  )
}
