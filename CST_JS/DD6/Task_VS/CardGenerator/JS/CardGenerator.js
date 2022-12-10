
//* access image 
var btnGenerate = document.getElementById('btnGenerate')

btnGenerate.onclick = function(){
    var CardImages = document.querySelectorAll('.CardImages')
    for ( i=0; i < CardImages.length ; i++) {
        if(CardImages[i].childNodes[1].checked){
            var image = CardImages[i].childNodes[0].firstChild;
            setCookie("cardImgSrc",image.src);

        }
    }
    var MessageText = document.getElementById('MessageText');
    setCookie("cardMessage",MessageText.value);

    window.open('./Card.html');

    
}

