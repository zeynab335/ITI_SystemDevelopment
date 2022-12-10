//* get Card Details
var CardDetails = allCookieList();

//* Create Dom 
var CardContent = document.getElementById('CardContent');

var CardImg  = document.createElement('img'); 
CardImg.setAttribute('src',CardDetails.cardImgSrc);
CardContent.append(CardImg)


var MessageText  = document.createElement('h1'); 
MessageText.innerText = CardDetails.cardMessage;
CardContent.append(MessageText);


var btnClosePreview =  document.getElementById('btnClosePreview');
btnClosePreview.onclick = function(){
    window.close()
}   




