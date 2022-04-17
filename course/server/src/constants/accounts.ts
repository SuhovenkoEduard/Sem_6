import stringHash from 'string-hash'

export const ACCOUNTS = [
  {
    role: 'client',
    email: 'avatar_dj@mail.ru',
    password: '12345',
    passwordHash: stringHash('12345').toString(),
  },
  {
    role: 'client',
    email: 'indigo@gmail.com',
    password: '1097535489fg',
    passwordHash: stringHash('1097535489fg').toString(),
  },
  {
    role: 'courier',
    email: 'kessler.polly@mraz.org',
    password: '99999fdffff',
    passwordHash: stringHash('99999fdffff').toString(),
  },
  {
    role: 'courier',
    email: 'delphia.gutmann@hotmail.com',
    password: 'jfpwsadkijfsdifh343',
    passwordHash: stringHash('jfpwsadkijfsdifh343').toString(),
  },
  {
    role: 'manager',
    email: 'mireya16@turcotte.com',
    password: '90583040gffgfg5',
    passwordHash: stringHash('90583040gffgfg5').toString(),
  },
  {
    role: 'manager',
    email: 'nayeli.jacobi@yahoo.com',
    password: '54fsd5f4sg6833348422__fds',
    passwordHash: stringHash('54fsd5f4sg6833348422__fds').toString(),
  },
]
