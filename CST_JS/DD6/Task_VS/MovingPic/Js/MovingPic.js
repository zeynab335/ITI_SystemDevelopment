//* Using clientHeight property return the height of an element in pixels

//? MAx top   ==> top  = 370px
//? MAx icon1 ==> left = 0px
//? MAx icon2 ==> left = 450px

//* select elements
var icon1 = document.getElementById('icon1');
var icon2 = document.getElementById('icon2');
var Top   = document.getElementById('TOP');


//* Declear Original Pos of images
var OriginalPos_Icon1 = 400;
var OriginalPos_Icon2 = 0;
var OriginalPos_TOP   = 0;

//* Declear Current Pos of images
var CurrentPos_Icon1 = parseInt(getComputedStyle(icon1).left);
var CurrentPos_Icon2 = parseInt(getComputedStyle(icon2).left);
var CurrentPos_Top   = parseInt(getComputedStyle(Top).top);

//* Declear Max Pos of images [Base Cond]
var MaxPos_Icon1 = 0;
var MaxPos_Icon2 = 450;
var MaxPos_TOP   = 350;

//* flags
var flgIcon1 = 0;
var flgIcon2 = 0;
var flgTop = 1;

//* Timers
var Timer;

//* check if current pos reach in the end of pos
   

function MovingIcon1(){
    var Image1 = document.getElementById('Icon1Ele');

    if(CurrentPos_Icon1 > MaxPos_Icon1 && !flgIcon1 && CurrentPos_Icon1>0){
        flgIcon1 = 0;
        CurrentPos_Icon1-=50
        icon1.style.left = CurrentPos_Icon1+'px'
        Image1.innerText = "<img src='icon1.gif style='left= " + CurrentPos_Icon1 +'px/>';     
    }
    else{
        CurrentPos_Icon1+=50
        icon1.style.left = CurrentPos_Icon1+'px'
        Image1.innerText = "<img src='icon1.gif style='left= " + CurrentPos_Icon1 +'px/>';     

        flgIcon1 = 1;
        if(CurrentPos_Icon1 > OriginalPos_Icon1) flgIcon1 = 0;
    }    

    
}

function MovingIcon2(){
    var Image2 = document.getElementById('Icon2Ele');

    if(!flgIcon2 && CurrentPos_Icon2>0){
        flgIcon2 = 0;
        CurrentPos_Icon2-=50

        icon2.style.left = CurrentPos_Icon2+'px'
        Image2.innerText = "<img src='icon2.gif style='left= " + CurrentPos_Icon2 +'px/>';     

    }
    // 0 0 450
    else{
        CurrentPos_Icon2+=50
        icon2.style.left = CurrentPos_Icon2+'px'
        Image2.innerText = "<img src='icon2.gif style='left= " + CurrentPos_Icon2 +'px/>';     
        flgIcon2 = 1;

        if(CurrentPos_Icon2 >= MaxPos_Icon2)flgIcon2 = 0;
    }
    
}

function MovingPicBottom(){

        if(!flgTop){
            flgTop = 0;
            CurrentPos_Top-=50
            Top.style.top = CurrentPos_Top+'px'    
            if(CurrentPos_Top <= 0 ) flgTop=1;
        }
        else{
            CurrentPos_Top+=50
            Top.style.top = CurrentPos_Top+'px'
            flgTop = 1;
            if(CurrentPos_Top >= MaxPos_TOP) flgTop = 0
            
        }
   

}


function MovingPics(){
    Timer = setInterval(function(){
        //* Moving Icon 1
        MovingIcon1();

        //* Moving Icon 2
        MovingIcon2();

        //* Moving Top
        MovingPicBottom();

    },500)
}

var stopMovingFlag = 0;
MovingPics();


//* Stop button
document.getElementById('Stop').onclick =  function (){

    if(this.getAttribute('class')!=='active'){
        MovingPics(CurrentPos_Icon1,CurrentPos_Icon2,CurrentPos_Top);
        this.classList.toggle('active')
    }
    else{
        clearInterval(Timer)
        this.classList.toggle('active')
    }

}

//* Reset button [start pos from original]
document.getElementById('Reset').onclick =  function (){
    clearInterval(Timer);
    var btnStop = document.getElementById('Stop')

    if(!btnStop.classList.contains('active')){
    btnStop.setAttribute('class','active')
   }

    CurrentPos_Icon1 = OriginalPos_Icon1
    CurrentPos_Icon2 = OriginalPos_Icon2
    CurrentPos_Top = OriginalPos_TOP
    flgTop = 1
    MovingPics();
}

