// Adiciona o evento de clique na imagem do receptor
document.getElementById("menuReceptor").addEventListener("click", function(event) {
    event.stopPropagation(); // Evita que o clique feche o menu imediatamente
    var menu = document.getElementById("dropdownMenu");
    
    // Verifica se o menu está oculto (usando estilo computado)
    if (window.getComputedStyle(menu).display === "none") {
        menu.style.display = "block";
    } else {
        menu.style.display = "none";
    }
});

// Fecha o menu ao clicar fora dele
window.onclick = function(event) {
    var menu = document.getElementById("dropdownMenu");
    
    // Verifica se o clique foi fora do menu e da imagem
    if (!event.target.matches('#menuReceptor') && menu.style.display === "block") {
        menu.style.display = "none";
    }
};

