let openModal = (btn) => {
    let modal = document.getElementById('modalWindow');
    modal.style.display = 'block';
    let modalMainText = document.getElementById('modalMainText');
    modalMainText.innerHTML = 'Do you really want to delete this obtaining: ' + btn.dataset['findingname'] +
        ' brought by ' + btn.dataset['findername'] + '?';
    let modalTitle = document.getElementById('modalTitle');
    modalTitle.innerHTML = "Deleting Obtaining";
    let deleteLink = document.getElementById('getQueryBtn');
    deleteLink.href = 'Obtainings/Delete/?workerid=' + btn.dataset['workerid'] + '&' +
        'finderid=' + btn.dataset['finderid'] + '&findingid=' + btn.dataset['findingid'];
}
