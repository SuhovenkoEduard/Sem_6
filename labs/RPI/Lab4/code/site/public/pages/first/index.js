const alertButton = document.getElementById('alertButton')
const switchButton = document.getElementById('switchButton')
const homeButton = document.getElementById('homeButton')

alertButton.addEventListener('click', () => {
  alert('FIRST PAGE, ALERT!')
})

switchButton.addEventListener('click', () => {
  history.pushState({}, null, '/second')
  location.reload()
  // const response = await fetch('http://localhost:3000', {
  //   method: 'POST',
  //   body: JSON.stringify({
  //     message: 'Switch page',
  //   }),
  // })
  // const json = await response.text()
  // const data = JSON.parse(json)
  // console.log(data)
})

homeButton.addEventListener('click', () => {
  history.pushState({}, null, '/')
  location.reload()
})
