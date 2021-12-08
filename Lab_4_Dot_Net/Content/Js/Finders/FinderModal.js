let openModal = (btn) => {
    let modal = document.getElementById('modalWindow');
    modal.style.display = 'block';
    let modalMainText = document.getElementById('modalMainText');
    modalMainText.innerHTML = 'Do you really want to delete this finder: ' + btn.dataset['name'] + ' ' + btn.dataset['surname'] + '?'
    let modalTitle = document.getElementById('modalTitle');
    modalTitle.innerHTML = "Deleting Finder";
    let deleteLink = document.getElementById('getQueryBtn');
    deleteLink.href = 'Finders/Delete/?id=' + btn.dataset['id'];
}
