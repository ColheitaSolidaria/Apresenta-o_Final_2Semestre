let currentSlide = 1;

startSlider();

function startSlider(){
    setInterval(function(){
        nextSlide();
    }, 5000);
}
function nextSlide(){
    currentSlide++;
    if(currentSlide>4){
        currentSlide= 1;
    }
    showSlide(currentSlide);
}
function showSlide(index){
    for(let i=1; i<=4; i++){
        document.getElementById("radio" + i).checked= false;
    }
    document.getElementById("radio" + index).checked= true;
}