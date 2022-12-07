
//* get query string from url
var qStr = window.location.search;

//* split all informaion from query string
var SplitQStr = window.location.search.split('&');

var UserDetails = [];


//*
for(var i=0 ; i<SplitQStr.length ; i++){
    UserDetails[i] = SplitQStr[i].split('=')[1];
}


//* change unicode '%40' to ==>  [ @ ]
var Email = UserDetails[0].substring(0 , UserDetails[0].indexOf('%40')) + '@' + UserDetails[0].substring(UserDetails[0].indexOf('%40')+3) ;

UserDetails[0] = Email;

//* put user details into screen
for(var i=0 ; i<UserDetails.length ; i++){
    document.querySelectorAll('.userDetails')[i].innerText = UserDetails[i];
}
    
//* check browser name is not Chrome show Message

var userAgent = navigator.userAgent;
var browserName;
         
if(userAgent.match(/chrome|chromium/i)){
    browserName = "chrome";
}
else{
    browserName = "not chrome";
    document.getElementById('BrowserName').innerText = "Your Browser not Chrome, Are you want to open Chrome? "
}





