
let closeModal = () => {
    let modal = document.getElementById('modalWindow');
    modal.style.display = 'none';
}
window.onclick = (event) => {
    let modal = document.getElementById('modalWindow');
    if (event.target == modal)
        modal.style.display = 'none';
}