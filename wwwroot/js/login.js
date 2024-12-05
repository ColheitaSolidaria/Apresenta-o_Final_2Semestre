// Obter o modal
var modal = document.getElementById("myModal");

// Obter o link que abre o modal
var forgotPasswordLink = document.getElementById("forgot-password");

// Obter o elemento <span> que fecha o modal
var span = document.getElementById("close-modal");

// Quando o usuário clicar no link, abra o modal 
forgotPasswordLink.onclick = function() {
    modal.style.display = "block";
}

// Quando o usuário clicar no <span> (x), feche o modal
span.onclick = function() {
    modal.style.display = "none";
}

// Quando o usuário clicar em qualquer lugar fora do modal, feche-o
window.onclick = function(event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}

// Quando o usuário clicar no botão "Enviar Instruções"
document.getElementById("send-email").onclick = function() {
    var email = document.getElementById("email").value;
    if (email) {
        // Aqui você chamaria sua função para enviar o e-mail
        alert("Instruções enviadas para " + email +"!");
        // Fechar o modal
        modal.style.display = "none";
    } else {
        alert("Por favor, digite um e-mail válido.");
    }
}
