var CharcterPressed = document.querySelector('.CharcterPressed');

document.addEventListener('onclick',function(event){  
    event.preventDefault();
});

document.addEventListener('contextmenu', function(event){  
    var text = "You Can't show Context Menu 😢";
    CharcterPressed.innerText =  text;
    event.preventDefault();
})
