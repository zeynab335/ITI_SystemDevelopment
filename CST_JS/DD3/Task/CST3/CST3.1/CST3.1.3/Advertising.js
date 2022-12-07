

function AutoSmoothScrolling(){
    
    window.resizeTo(500,500);
    var WindowHeight = window.innerHeight;
    var YPos = -50;
    
    var timer = setInterval(function(){
        console.log(YPos , WindowHeight);

        if(YPos <= WindowHeight){
            YPos +=50;
            window.scrollBy(0,YPos);
            console.log(YPos , WindowHeight);

        }
        else{
            console.log("ending");
            clearInterval(timer);
            
            setTimeout(()=>{
                window.close();
            },1000)
        }

    },500)
}

AutoSmoothScrolling();