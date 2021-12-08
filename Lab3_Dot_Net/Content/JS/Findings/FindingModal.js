let openModal = (btn) => {
    let modal = document.getElementById('modalWindow');
    modal.style.display = 'block';
    let modalMainText = document.getElementById('modalMainText');
    modalMainText.innerHTML = 'Do you really want to delete this finding: ' + btn.dataset['name'] + '?'
    let modalTitle = document.getElementById('modalTitle');
    modalTitle.innerHTML = "Deleting Finding";
    let deleteLink = document.getElementById('getQueryBtn');
    deleteLink.href = 'Findings/Delete/?id=' + btn.dataset['id'];
}
