
$(function(){
   
    /*var timer = setInterval(()=>{
        
        //
        
    },1000)*/

    
    var counter ;
    var timer = setInterval(function(){
        var left  = 200;
        $("#img").eq(0).animate({left:"200px"},5000,"easeOutBounce");//easing["linea","swing",.....]
        counter = getComputedStyle($("#img").get(0));
        
        if(left == counter){
            clearInterval(timer);
        }
        else{
            $('#imgSrc').eq(0).text('<img src="12.gif" style="left:"'+ counter['left'] + '/>')
            counter+=10   
        }
        
    },100)
})