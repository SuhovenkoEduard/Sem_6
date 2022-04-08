export const createGetAllQuery = (tableName: string) =>
  `SELECT * FROM ${tableName}`

export const createGetByIdQuery = (tableName: string, propNameId: string) =>
  `SELECT * FROM ${tableName} WHERE ${propNameId} = ?`

export const createPutQuery = (tableName: string, propNames: string[], propNameId: string) =>
  `UPDATE ${tableName} 
   SET ${propNames.map(propName => `${propName} = ?`).join(', ')}
   WHERE ${propNameId} = ?`

export const createPostQuery = (tableName: string, propNames: string[]) =>
  `INSERT INTO ${tableName} (${propNames.join(', ')}) VALUES 
   (${new Array<string>(propNames.length).fill('?').join(', ')})`

export const createDeleteQuery = (tableName: string, propNameId: string) =>
  `DELETE FROM ${tableName} WHERE ${propNameId} = ?`
