var CharcterPressed = document.querySelector('.CharcterPressed');

document.body.onkeydown =  function(event){
    var text = "Unicode of Character is = " + event.keyCode+ " Character is = "  + event.code;
    alert(text);
    CharcterPressed.innerText =  text;
}
