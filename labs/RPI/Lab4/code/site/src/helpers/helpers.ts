import { FileExtension } from '../constants/constants'

export const getFilePathByExtension = (pagesPath: string, extension: FileExtension) => `${pagesPath}/index.${extension}`
