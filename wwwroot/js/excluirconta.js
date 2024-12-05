// Exibir o modal ao clicar em "Excluir conta"
document.getElementById('excluirConta').addEventListener('click', function(event) {
    event.preventDefault(); // Previne o comportamento padrão do link
    document.getElementById('modal').style.display = 'flex'; // Exibe o modal
});

// Esconde o modal ao clicar em "Cancelar"
document.getElementById('cancelar').addEventListener('click', function() {
    document.getElementById('modal').style.display = 'none';
});

// Ação de confirmação ao excluir a conta
document.getElementById('confirmar').addEventListener('click', function() {
    alert('Conta excluída com sucesso!'); // Mensagem de confirmação
    document.getElementById('modal').style.display = 'none';
});
