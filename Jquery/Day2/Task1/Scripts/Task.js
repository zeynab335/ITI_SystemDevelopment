
$(function(){
    var counter = 0;
    var end  = 500;
    var timer = setInterval(()=>{
        if(end == counter){
            clearInterval(timer);
        }
        else{
            counter += 20;
            $('#img').eq(0).css('left', counter)
        }
        $('#imgSrc').eq(0).text('<img src="12.gif" style="left:"'+ counter + 'px"/>')
    },1000)
    


})