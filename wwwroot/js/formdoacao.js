// Adiciona o evento de clique na imagem do receptor
document.getElementById("menuReceptor").addEventListener("click", function() {
    var menu = document.getElementById("dropdownMenu");
    if (menu.style.display === "block") {
        menu.style.display = "none";
    } else {
        menu.style.display = "block";
    }
});

// Fecha o menu ao clicar fora dele
window.onclick = function(event) {
    if (!event.target.matches('#menuReceptor')) {
        var dropdowns = document.getElementsByClassName("dropdown-menu");
        for (var i = 0; i < dropdowns.length; i++) {
            var openDropdown = dropdowns[i];
            if (openDropdown.style.display === "block") {
                openDropdown.style.display = "none";
            }
        }
    }
}


