/*
    * getCookie (cookieName)
    ? Retrieves a cookie value based on a cookie name.
    
    * setCookie (cookieName,cookieValue[,expiryDate])
    ? Sets a cookie based on a cookie name, cookie value, and expiration date.
    
    *  deleteCookie (cookieName):
    ? Deletes a cookie based on a cookie name.
    
    * allCookieList ():
    ? returns a list of all stored cookies
    
    * hasCookie (cookieName)
    ? Check whether a cookie exists or not
*/



//? getCookie (cookieName)
function setCookie (cookieName,cookieValue,expiryDate){
    //* when user not send expireDate ==> make session cookie
    var SessionDate = new window.Date();
    
    //* when user send expireDate ==> make Presistant cookie
    var PresistantDate = expiryDate;
    var Date = expiryDate!== undefined ?  PresistantDate : SessionDate;

    var ExpireDate = ";expires=" + Date;
    document.cookie = cookieName + "=" + cookieValue + ExpireDate

}

//? getCookie (cookieName)
function getCookie(cookieName){
    
    var CookieValue;
    var indexOfCookieName=0  ,StartIdx=0 ,  EndIndex;
    var isExist = hasCookie(cookieName);

    if(isExist){
        indexOfCookieName = document.cookie.indexOf(cookieName);
        
        StartIdx = indexOfCookieName + cookieName.length+1;
        
        CookieValue = document.cookie.slice(StartIdx);

        //* substring from first index of CookieValue into => index of [;]
        //* check if there is  ';' or space [last cookie]
        EndIndex = CookieValue.search(';')>=0 ? CookieValue.indexOf(';') : CookieValue.length
        CookieValue = CookieValue.substring(0,EndIndex);
        

    }
    return CookieValue;
}

//? allCookieList ()
function allCookieList(){
    var CookieList = [];
    var FieldDate = [];
    
    //* Split all cookie names in this
    var CookieDetails = document.cookie.split('; ');
    
    for (let index = 0; index < CookieDetails.length; index++) {
        FieldDate[index] = CookieDetails[index].split('=');
        
        CookieList[FieldDate[index][0]] = FieldDate[index][1];
    }

    
    //* [usrName : 'zeze mahmo'] ==>  associative array
    //? as [cookieName : 'cookieValue']
    return CookieList;
}

//?  deleteCookie (cookieName)
function deleteCookie (cookieName){
    var date = new window.Date();
    document.cookie = cookieName + "= " + ";expires=" + date.setYear(2000);

}


//? hasCookie (cookieName)
function hasCookie (cookieName){
    var isExist = document.cookie.search(cookieName);
    if(isExist >= 0){
        return 1;
    }
    return 0;
}