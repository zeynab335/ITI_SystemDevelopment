var video = document.getElementById('video');
var timer ;


//* Timer 
timer = setInterval(() => {

    //* put end time & Current time
    var endMinute = Math.floor(video.duration / 60) + ':' ;
    var endSeconds = (video.duration % 60).toFixed(0);

    document.getElementById('vEndTime').innerText = endMinute+endSeconds

    var Minute = Math.floor(video.currentTime / 60) ;
    var Seconds = (video.currentTime % 60).toFixed(0);
    var time  = '';
    if(Seconds == 0 && Minute == 0) time = '00.00'
    else{
        if(Minute < 10) time = '0' + Minute + ':'
        else time = Minute + ':'
    
        if(Seconds < 10) time += '0' + Seconds
        else time += Seconds 
    }
   
    
    document.getElementById('vCurrentTime').innerText = time


    //* put video volume
    document.getElementById('VolumeRange').value = video.volume * 100
 
},1000);


//* put current time of video [on change range input of video ]
document.getElementById('vRange').onchange = function(){
    document.getElementById('vRange').setAttribute('value', document.getElementById('vRange').value)
    video.currentTime = document.getElementById('vRange').value;
}

//* play video 
document.getElementById('vPlay').onclick = function(){
    video.play();
}

//* pause video 
document.getElementById('vPause').onclick = function(){
    clearInterval(timer)    
    video.pause();
}


//* forward video 
document.getElementById('vForward').onclick = function(){
    video.currentTime += 5;
}

//* backward video 
document.getElementById('vBackword').onclick = function(){
    video.currentTime -= 5;
}

//* forward video 
document.getElementById('vStartAgain').onclick = function(){
    video.currentTime = 0;
    document.getElementById('vRange').value = video.currentTime
    document.getElementById('vCurrentTime').innerText = video.currentTime
    video.play()

}

//* backward video 
document.getElementById('vEnd').onclick = function(){
    video.currentTime  = video.duration - 10;
    document.getElementById('vRange').value = video.currentTime
    document.getElementById('vCurrentTime').innerText = video.currentTime
}


//* Speed
document.getElementById('vSpeedRange').onchange = function(){
    video.playbackRate = parseInt(this.value)
    document.getElementById('vRange').value = video.currentTime

}



//* Volume
document.getElementById('VolumeRange').onchange = function(){
    var volume_value = this.value
    video.volume = volume_value / 100    ;
}

//* mute
document.getElementById('vMute').onclick = function(){
    video.volume = 0    ;
    document.getElementById('VolumeRange').value = 0
    

}