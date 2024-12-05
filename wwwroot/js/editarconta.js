/// Função para abrir o modal 
function openModal() {
    document.getElementById("editProfileModal").style.display = "block";
}

// Função para fechar o modal
function closeModal() {
    document.getElementById("editProfileModal").style.display = "none";
}

// Função para pré-visualizar a imagem de perfil
function previewImage(event) {
    const input = event.target;
    const reader = new FileReader();

    reader.onload = function() {
        const imgElement = document.getElementById('profile-img');
        imgElement.src = reader.result;
    };

    if (input.files && input.files[0]) {
        reader.readAsDataURL(input.files[0]);
    }
}

// Função para salvar as alterações do perfil
function saveProfile() {
    const address = document.getElementById('address').value;
    const phone = document.getElementById('phone').value;
    
    alert('Perfil atualizado com sucesso!');
    console.log('Endereço:', address);
    console.log('Telefone:', phone);

    // Fechar o modal após salvar
    closeModal();
}

// Fechar o modal ao clicar fora dele
window.onclick = function(event) {
    const modal = document.getElementById("editProfileModal");
    if (event.target == modal) {
        modal.style.display = "none";
    }
}
