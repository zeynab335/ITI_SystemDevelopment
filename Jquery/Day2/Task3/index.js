$( function() {

	$("#drag").draggable()

    //* max left of box => 170 *** max top of box => 215  ==> 
    var top = $("#drag").offset().top
    var left = $("#drag").offset().left
    setInterval(function(){

        top = $("#drag").offset().top
        left = $("#drag").offset().left
        
        //* to get position of drag element
        if(((top < 170) && (left < 215) ) ){
            $("#drag").fadeOut(2000)
        }

    })
} );