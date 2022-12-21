

//* Hide All Details of Media Details Except Active Menu Button



//* Toggle Active Class in Menu List
$(function(){
    var Btns = $(".MenuListButtons button");
    for (let i = 0; i < Btns.length; i++) {

        Btns.eq(i).click(function(){
            if(Btns.eq(i).attr('class')!=='active') {
                                    //* Hide all items in menu list

                for(var j=0 ; j<Btns.length ; j++)
                {   
                    if(j!== i) {
                        Btns.eq(j).removeClass('active')
                        $('.'+Btns[j].id+'Details').eq(0).css('display','none')
                    }
                }
                Btns.eq(i).attr('class','active')
                //AboutDetails  ==> dispaly flex 
                $('.'+Btns[i].id+'Details').eq(0).css('display','flex')
            }
            
        })   
    }
   
})
