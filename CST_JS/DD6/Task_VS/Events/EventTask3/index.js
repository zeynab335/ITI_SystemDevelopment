var btnSubmit = document.getElementById('btnSubmit');



//* custom event
var timeOut = new Event('timeOut');

document.body.addEventListener('timeOut',function(){
    var TimeOut = document.getElementById('TimeOut');
    TimeOut.innerText  = "Time Out 🔥 , Please Enter Your Data then Submit"
})

//* dispatchEvent => trigger the events
setTimeout(
    function(){
        document.body.dispatchEvent(timeOut);
    }
,10000)