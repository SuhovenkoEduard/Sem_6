const alertButton = document.getElementById('alertButton')
const switchButton = document.getElementById('switchButton')
const homeButton = document.getElementById('homeButton')

alertButton.addEventListener('click', () => {
  alert('SECOND PAGE, ALERT!')
})

switchButton.addEventListener('click', () => {
  history.pushState({}, null, '/first')
  location.reload()
})

homeButton.addEventListener('click', () => {
  history.pushState({}, null, '/')
  location.reload()
})
