
function setUserDetails(){

    //* username
    var userName = document.getElementById('Name')
    userName.innerText = getCookie('usrName');

    //* Gender
    var Gender = document.getElementById('Gender')
    console.log(getCookie('Gender'))
    var src = getCookie('Gender') === 'Male' ?  '../images/1.jpg'  :  '../images/2.jpg';
    Gender.src = src;
    
    //* change Color
    var NumOfVisits = document.getElementById('NumOfVisits');
    NumOfVisits.innerText = getCookie('NumOfVisits');
    userName.style.color  = getCookie('FavColor');
    Gender.style.color    = getCookie('FavColor');
}

setUserDetails();