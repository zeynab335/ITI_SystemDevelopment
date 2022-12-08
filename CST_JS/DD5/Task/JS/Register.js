var btnSubmit    = document.getElementById('btnSubmit');
var usrname , FavColor , Gender ,btnGenderActive;


function SelectGender(){
    var Male  = document.getElementById('Male');
    var Female  = document.getElementById('Female');

    Male.onclick = function(){
        Gender = 'Male'
    }

    Female.onclick = function(){
        Gender = 'Female'
    }
}

function SelectFavColor(){
    var FavColorDropBox = document.getElementById('FavColorDropBox');
    console.log(FavColorDropBox);
    for (var index = 0; index < FavColorDropBox.length; index++) {
        if(FavColorDropBox[index].selected){
            FavColor = FavColorDropBox[index].value;
        };
    }
    
}
SelectGender();

function GetUserDetails(){
    
    //* associative Array to store data of user
    usrname  = document.getElementById('usrName').value;
    var UserDetails = [];

    SelectFavColor();
    UserDetails[0] = usrname
    UserDetails[1] = Gender
    UserDetails[2] = FavColor

    return UserDetails;
}

//& Register Handler
btnSubmit.onclick = function(){
    //* Define Number of visits
    var CountNumOfVisits = 
    hasCookie('NumOfVisits') && hasCookie('usrName')
    ? getCookie('NumOfVisits')
    : 0;

    console.log(CountNumOfVisits)

    var UserDetails = GetUserDetails();

    var Date = new window.Date();
    var ExpireCookieDate = new window.Date(Date.setDate(15));
    setCookie('usrName',UserDetails[0], ExpireCookieDate);
    setCookie('Gender',UserDetails[1], ExpireCookieDate);
    setCookie('FavColor',UserDetails[2], ExpireCookieDate);

    //? Define Number of visits
    setCookie('NumOfVisits',++CountNumOfVisits);
    
    //* open welcome page to user
    setTimeout(function(){
        window.location.assign('./WelcomePage.html');
    },5000)
}
