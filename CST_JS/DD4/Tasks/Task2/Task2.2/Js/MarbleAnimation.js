
onload = function(){
    //* Start Decleration

    var ActiveImg = document.getElementsByName('marble1');

    //* Slide used as variable to start and clear interval
    var Slider;
    var indexOfActiveImg = 0;
    
    //* end Decleration

    // * SlideShow Button Handler
            
    for(var i=0; i<5 ;i++){
        ActiveImg[i].onmousemove = function(){
            clearInterval(Slider);
        }
        

        ActiveImg[i].onmouseleave = function(){       
            Slider = setInterval(
                    function(){

                        // * to make all previous img not active 
                        for(var i=0 ; i<indexOfActiveImg ;i++){
                            ActiveImg[i].src = '../Images/marble1.jpg'
                        }
                         // * circular 
                        if(indexOfActiveImg == 5) {
                            indexOfActiveImg=0;
                            ActiveImg[indexOfActiveImg++].src = '../Images/marble3.jpg';
                        }
                        else ActiveImg[indexOfActiveImg++].src = '../Images/marble3.jpg';
                    
                        
                    }
                            

            , 500 )       
        }
    }      
      


    //* Stop SliderShow Handler
   
    
    }


   







