

//* Hide All Details of Media Details Except Active Menu Button



//* Toggle Active Class in Menu List
$(function(){
    var Btns = $(".MenuListButtons button");
    
    for (let i = 0; i < Btns.length; i++) {
        //* to make first Menu List Active
        if(Btns.eq(i).attr('class') =='active') {
            $('.'+Btns[i].id+'Details').eq(0).css('display','flex')
            $('.MenuListDetails').fadeIn(500);
        }

        Btns.eq(i).click(function(){
            if(Btns.eq(i).attr('class')!=='active') {
                //* Hide all items in menu list

                for(var j=0 ; j<Btns.length ; j++)
                {   
                    if(j!== i) {
                        Btns.eq(j).removeClass('active')
                        $('.'+Btns[j].id+'Details').hide();
                    }
                }
                Btns.eq(i).attr('class','active')
                //AboutDetails  ==> dispaly flex 
                $('.'+Btns[i].id+'Details').eq(0).fadeIn(1000).css('display','flex');
            }
            
        })   
    }
   
})



//* Make Gallery Slider
$(function(){

    var arr = [
        "1.jpg",
        "2.jpg",
        "3.jpg",
        "4.jpg",
        "5.jpg",
        "6.jpg",
        "7.jpg",
        "8.jpg"
    ]
    $('#ArrowLeft').click(function(){
        // 1.jpg
        var ImgElement = $('.GalleryContainer img');
        var Img = ImgElement.get(0).src ;
        
        var ActiveImg = Img.slice(Img.length-5 , Img.length);
        var index = arr.indexOf(ActiveImg);
        var ImgFullPath = '../Images/'

        if(index === 0 ){   
            ImgElement.attr('src' , ImgFullPath + arr[7]);
        }
        
        else{
            ImgElement.attr('src' , ImgFullPath + arr[index-1]);
        }
        
    })

    $('#ArrowRight').click(function(){
        // 1.jpg
        var ImgElement = $('.GalleryContainer img');
        var Img = ImgElement.get(0).src ;
        
        var ActiveImg = Img.slice(Img.length-5 , Img.length);
        var index = arr.indexOf(ActiveImg);
        var ImgFullPath = '../Images/'

        if(index === 7 ){   
            ImgElement.attr('src' , ImgFullPath + arr[0]);
        }
        
        else{
            ImgElement.attr('src' , ImgFullPath + arr[index+1]);
        }
        
    })
})

