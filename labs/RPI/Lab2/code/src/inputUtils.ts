import { prompts } from 'prompts'

const argsToPrompt: {
  type: 'text' | 'number'
  name: string
} = {
  type: 'text',
  name: 'value',
}

const createFullArgsToPrompt = (message: string) => ({
  ...argsToPrompt,
  message,
})

export const inputString = async (message: string) => {
  return prompts.text(createFullArgsToPrompt(message))
}
