var btnSubmit = document.querySelector('.btnSubmit');

//* check if user submitted or not
var flag = 0;

//* Submitted Form
btnSubmit.addEventListener("click",function(e){
    var confirm = window.confirm("Are You Want to Submit your Applicant? ");

    if(!confirm){
        e.preventDefault();
        flag = 0;        
    }
    else{
        flag = 1
        var ConfirmationMsg = document.getElementById('ConfirmationMsg')
        ConfirmationMsg.innerText = "Thanks For compeleted this Application Form 😊💕 ";
        ConfirmationMsg.style.backgroundColor = '#52BD8F'
    }
    
})

//* custom event
var timeOut = new Event('timeOut');

document.body.addEventListener('timeOut',function(){
    if(!flag){
        var TimeOut = document.getElementById('TimeOut');
        TimeOut.innerText  = "Time Out 🔥 , Please Enter Your Data then Submit"
    }
    
})

//* dispatchEvent => trigger the events
setTimeout(
    function(){
        document.body.dispatchEvent(timeOut);
    }
,30000)