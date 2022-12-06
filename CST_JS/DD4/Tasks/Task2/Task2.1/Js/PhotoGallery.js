
onload = function(){
    //* Start Decleration
    var RootPath = "Images/"
    var AllPicSrcs = [
        "1.jpg" ,
        "2.jpg",
        "3.jpg",
        "4.jpg",
        "5.jpg",
        "6.jpg"
    ]
    var ActiveImg = document.getElementById('ActiveImg');
    //* '../http://127.0.0.1:5500/Task2/Task2.1/Images/1.jpg'
    //? slice only this part [1.jpg]
    console.log(ActiveImg.src);
    var indexOfActiveImg = AllPicSrcs.indexOf(ActiveImg.src.slice(ActiveImg.src.indexOf(RootPath)+7 , ActiveImg.src.length ));

    //* Slide used as variable to start and clear interval
    var Slider;
    
    //* end Decleration

    // * Next Button Handler
    document.getElementById('Next').onclick = function(){
        if(indexOfActiveImg !== AllPicSrcs.length-1 ){
            ActiveImg.src = '../'+RootPath + AllPicSrcs[++indexOfActiveImg];
        }
    }

    // * Previous Button Handler
    document.getElementById('Previous').onclick = function(){
        if(indexOfActiveImg !== 0 ){
            ActiveImg.src = '../'+RootPath + AllPicSrcs[--indexOfActiveImg];
        }
    }

     // * SlideShow Button Handler
    document.getElementById('SlideShow').onclick = function(){
        Slider = setInterval(
            function(){
                if(indexOfActiveImg !== AllPicSrcs.length-1 ){
                    ActiveImg.src = '../'+RootPath + AllPicSrcs[++indexOfActiveImg];
                    if(indexOfActiveImg == 5) indexOfActiveImg=-1;
                }
            }
        , 2000 )
    }
    
    //* Stop SliderShow Handler
    document.getElementById('Stop').onclick = function(){
        clearInterval(Slider);
    }

}
   







