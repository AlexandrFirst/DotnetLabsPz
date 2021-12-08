let openModal = (btn) => {
    let modal = document.getElementById('modalWindow');
    modal.style.display = 'block';
    let modalMainText = document.getElementById('modalMainText');
    modalMainText.innerHTML = 'Do you really want to delete this extradiction: ' +
        btn.dataset['findingname'] + ' extradicted by ' + btn.dataset['ownername'] + '?';
    let modalTitle = document.getElementById('modalTitle');
    modalTitle.innerHTML = "Deleting Extradiction";
    let deleteLink = document.getElementById('getQueryBtn');
    deleteLink.href = 'Extradictions/Delete/?workerid=' + btn.dataset['workerid'] +
        '&ownerid=' + btn.dataset['ownerid'] + '&findingid=' + btn.dataset['findingid'];
}
