//* access image 
var header = document.getElementById('header');

//* change position of first image
header.style.alignSelf = 'flex-end';


//* Add New img and set it in the end
var NewImg =  document.createElement('img');
var ImgStyle = 'position:absloute;bottom:0px;left:0px'

NewImg.setAttribute('src','../Images/dom.jpg');
NewImg.setAttribute('style',ImgStyle);

document.body.append(NewImg)