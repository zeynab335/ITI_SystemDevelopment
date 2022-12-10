var images = [
    'gws.jpg',
    'gws2.jpg',
    'gws3.jpg',
    'gwsf.jpg',
    'gwsf2.png',
    'gwsf3.jpg'
]

var CardGroup1 = document.getElementById('CardGroup1');
var CardGroup2 = document.getElementById('CardGroup2');

for (let i = 0; i < images.length; i++) {

    var cardImages = document.createElement('div');
    cardImages.setAttribute('class','CardImages');
    
    var Label =  document.createElement('label');
    Label.setAttribute('for', 'image'+i);
    
    var NewImg =  document.createElement('img');
    NewImg.setAttribute('src','../Images/'+images[i]);
   
    //* append image into Label
    Label.append(NewImg);
    cardImages.append(Label);

    var radioBtn =  document.createElement('input');

    radioBtn.setAttribute('type','radio');
    radioBtn.setAttribute('name','image');
    radioBtn.setAttribute('id', 'image'+i);

    cardImages.append(radioBtn);


    if(i < images.length/2){
        CardGroup1.append(cardImages);
    }
    else{
        CardGroup2.prepend(cardImages);
    }
    
}


var MessageText = document.getElementById('MessageText');
MessageText.onclick = function(){
    this.style.boxShadow = '0px'
    this.style.color = 'white'
    this.style.paddingLeft = '10px'

}

var image = document.getElementsByTagName('img')
var flag = 0, prevIdx,i;

    for ( i=0; i < image.length ; i++) {
        //var radioBtn = image[i].parentNode.parentNode.childNodes[1]
        image[i].onclick = function(){
            //* loop in all images to delete border in an inactive image
            for(prevIdx=0; prevIdx<image.length ;prevIdx++ ){
                if(prevIdx!==i){
                    image[prevIdx].style.border = "0px"
                }
            }
            this.style.border = '3px solid red';
            prevIdx = i;        
        }
    }


