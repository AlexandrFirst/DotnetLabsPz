let openModal = (btn) => {
    let modal = document.getElementById('modalWindow');
    modal.style.display = 'block';
    let modalMainText = document.getElementById('modalMainText');
    modalMainText.innerHTML = 'Do you really want to delete this worker: ' + btn.dataset['name'] + ' ' + btn.dataset['surname'] + '?'
    let modalTitle = document.getElementById('modalTitle');
    modalTitle.innerHTML = "Deleting Worker";
    let deleteLink = document.getElementById('getQueryBtn');
    deleteLink.href = 'Workers/Delete/?id=' + btn.dataset['id'];
}
