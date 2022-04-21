import express from 'express'
import { CLIENT_ERROR_STATUS_CODE, RoutesPaths } from '../../constants/constants'
import { ClientModel, CommentModel } from '../../models/models'
import { ClientDTO, CommentDTO } from '../../constants/models'

export const commentsRouter = express.Router()

commentsRouter.get(RoutesPaths.getAll, async (req: express.Request, res: express.Response) => {
  try {
    const comments: CommentDTO[] = await CommentModel.findAll({})
    const clients: ClientDTO[] = await ClientModel.findAll({})
    res.json(comments.map(comment => ({
      ...comment,
      clientName: clients.find((client) => client.id === comment.clientId).name,
    })))
  } catch (e: any) {
    res.status(CLIENT_ERROR_STATUS_CODE).json({ message: e.message })
  }
})

commentsRouter.post(RoutesPaths.addOne, async (req: express.Request, res: express.Response) => {
  try {
    const addedCommentData = req.body
    const addedCommentDTO: CommentDTO = await CommentModel.create(addedCommentData)
    const client: ClientDTO = await ClientModel.findOne({ where: { id: addedCommentDTO.clientId } })

    res.json({
      ...addedCommentDTO,
      clientName: client.name,
    })
  } catch (e: any) {
    res.status(CLIENT_ERROR_STATUS_CODE).json({ message: e.message })
  }
})

commentsRouter.delete(RoutesPaths.deleteOne, async (req: express.Request, res: express.Response) => {
  try {
    const { id } = req.body
    await CommentModel.destroy({ id })
    const comments: CommentDTO[] = await CommentModel.findAll({})
    const clients: ClientDTO[] = await ClientModel.findAll({})
    res.json(comments.map(comment => ({
      ...comment,
      clientName: clients.find((client) => client.id === comment.clientId).name,
    })))
  } catch (e: any) {
    res.status(CLIENT_ERROR_STATUS_CODE).json({ message: e.message })
  }
})
