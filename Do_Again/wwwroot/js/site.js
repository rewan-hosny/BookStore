const toggleButton = document.getElementsByClassName('toggle-button')[0]
const navbarLinks = document.getElementsByClassName('navbar-links')[0]

toggleButton.addEventListener('click', () => {
  navbarLinks.classList.toggle('active')
})
const toggleButton2 = document.getElementsByClassName('toggle-button1')[0]
const navbarLinks2 = document.getElementsByClassName('navbar-links1')[0]

toggleButton2.addEventListener('click', () => {
    navbarLinks2.classList.toggle('active')
})