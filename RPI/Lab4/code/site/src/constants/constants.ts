export const PAGES_PATH = './public/pages'

export enum Port {
  http = 3000,
  express = 4000,
}

export enum LogPath {
  http = './out/http.txt',
  express = './out/express.txt',
}

export const FILE_PATHS = {
  '/': `${PAGES_PATH}/home`,
  '/first': `${PAGES_PATH}/first`,
  '/second': `${PAGES_PATH}/second`,
}

export enum FileExtension {
  html = 'html',
  css = 'css',
  js = 'js',
}

export enum Route {
  home = '/',
  first = '/first',
  second = '/second',
}

export enum FileRoute {
  indexCss = '/index.css',
  indexJs = '/index.js',
}
