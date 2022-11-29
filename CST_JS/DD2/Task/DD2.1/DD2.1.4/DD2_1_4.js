//? Task 1 Point 1.4 in Day2

/*
    * get from user Name , PhoneNum , MobileNum , Email
    * validates and displays it with a welcoming message in console
    * Name => should be characters and not a number
    * PhoneNum => should be a number , with length = 8
    * MobileNum => should be numbers , with length = 11
    *   plus MobileNum starts with (010 | 011 | 012)
    * Email => abc@123.com
    * use can use choice either red , blue , green
    
*/

//& getDataFromUser Functions
function getDataFromUser(){
    var Name = prompt("Enter Your Name");
    var PhoneNum = prompt("Enter Your PhoneNum");
    var MobileNum = prompt("Enter Your MobileNum");
    var Email = prompt("Enter Your Email");

    return [
        Name , 
        PhoneNum ,
        MobileNum,
        Email
    ]
}

//& Validation Functions
function Validation(Name , PhoneNum , MobileNum , Email){
    
    // start Decleration 
    
    //* Regular Exp
    var PhoneRegExp      = /^[0-9]{8}$/ ;
    var MobileRegExp     = /^011|010|012*[0-9]{8}$/ ;
    
    //* format of Regular Exp ==> "z.auc@gmai.com"
    var EmailRegExp1     = /^\w+[\+\.\w-]*@[a-zA-Z]+(\.)+[a-zA-Z]{2,4}$/ ;
    
    //* another format of Regular Exp ==> "z@gmai.com"
    var EmailRegExp2 = /^[\w]+@[\w]+[\w]+(\.)[\w]{2,4}$/;
   
    //~ Associative array of errors
    var ArrOfErrors = {
        "Name" : "" ,
        "Email" : "",
        "PhoneNum" : "",
        "MobileNum" : ""
    } ;
    

    var isNameValid      = typeof(Name)==='string';
    var isPhoneNumValid  = isFinite(PhoneNum) && (PhoneRegExp.test(PhoneNum)) ;    
    var isMobileNum      = isFinite(MobileNum) && (MobileRegExp.test(MobileNum)) ;
    var isEmailVaild     = EmailRegExp2.test(Email);

    var isValid = isNameValid && isPhoneNumValid && isMobileNum && isEmailVaild;

    if(isValid) return {isValid:"true"};

    else{   
        if(!isNameValid) ArrOfErrors["Name"]            = "Name Should be a string";
        if(!isEmailVaild) ArrOfErrors["Email"]          = "Email should be in this format abc@email.com ";
        if(!isPhoneNumValid) ArrOfErrors["PhoneNum"]    = "Phone Number should be 8 numbers ";
        if(!isMobileNum) ArrOfErrors["MobileNum"]       = "Mobile Number should be 11 numbers ";
    }
    return ArrOfErrors;
    
}

//& DisplayDataToUser Functions
function DisplayDataToUser(Name , PhoneNum , MobileNum , Email, color){
    document.write(
        `<p class= ${color}> Welcome dear guest </p>` + " "+ Name + "<br>"+
        `<p class= ${color}> Your telephone number is </p>`+ " " + PhoneNum + "<br>"+
        `<p class= ${color}> your mobile number is </p>` + " " + MobileNum + "<br>"+
        `<p class= ${color}> your email address is </p>` + " " + Email + "<br>"
    );
}

//& Register Functions
function Register(){
    //* Get Data from user
   var [Name , PhoneNum,MobileNum,Email ] = getDataFromUser();

    //& invoke validation Functions
    var Data = Validation(Name , PhoneNum , MobileNum , Email);
    console.log(Data.isValid);

    //* display data to user in screen 
    if(Data.isValid){
        console.log("Welcome " + Name + " Phone Number = " + PhoneNum + "MobileNum = " + MobileNum + " Email = " + Email); 
        var color = prompt("What is Color is you Wanted 🟥 🟦 🟩 ")
        DisplayDataToUser(Name , PhoneNum , MobileNum , Email , color);
    }
    else {
        //! display message to user to inform about validation in screen 
        document.write(
            `<p class="red"> Please Enter Valid Data, Try Again </p>`
        )
        //* display message to user to inform about validation in screen 
        for(var ele in Data){
            document.write(
                `<p class="red"> ${Data[ele]} </p><br>`
            )
        }

    }
}

Register();
