let openModal = (btn) => {
    let modal = document.getElementById('modalWindow');
    modal.style.display = 'block';
    let modalMainText = document.getElementById('modalMainText');
    modalMainText.innerHTML = 'Do you really want to delete this owner: ' + btn.dataset['name'] + ' ' + btn.dataset['surname'] + '?'
    let modalTitle = document.getElementById('modalTitle');
    modalTitle.innerHTML = "Deleting Owner";
    let deleteLink = document.getElementById('getQueryBtn');
    deleteLink.href = 'Owners/Delete/?id=' + btn.dataset['id'];
}
