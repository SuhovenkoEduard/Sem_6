const firstPage = document.getElementById('firstPage')
const secondPage = document.getElementById('secondPage')

firstPage.addEventListener('click', () => {
  history.pushState({}, null, '/first')
  location.reload()
})

secondPage.addEventListener('click', () => {
  history.pushState({}, null, '/second')
  location.reload()
})
