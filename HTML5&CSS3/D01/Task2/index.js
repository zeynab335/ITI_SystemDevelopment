
var red = document.getElementById('red')
var blue = document.getElementById('blue')
var green = document.getElementById('green')


var text = document.getElementById('text')

red.onchange = function(){
    text.style.color = 'rgb(' + red.value + ',' + green.value + ',' + blue.value + ')'
}

blue.onchange = function(){
    text.style.color = 'rgb(' + red.value + ',' + green.value + ',' + blue.value + ')'
}


green.onchange = function(){
    text.style.color = 'rgb(' + red.value + ',' + green.value + ',' + blue.value + ')'
}
