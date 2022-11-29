// Task1 in Day2


function CountStringCharacters(){
    var stringFromUsr = prompt("Enter Your string");
    var confirmDiffCharacter = confirm("Case Sensitive or not");
    var Expression =  prompt("Enter Your Character");
    
    var strLen = 0;
    if(!confirmDiffCharacter){
        /// case inSesitive
        var regEx = new RegExp(Expression , 'i');
        
        for(var i in stringFromUsr){
            if(stringFromUsr[i].match(regEx)){
                strLen++;
            }
        }
        
        document.write("length = " + strLen);

    }
    else {
        /// case Sensitive
        var regEx = new RegExp(Expression);
        
        for(var i in stringFromUsr){
            if(stringFromUsr[i].match(regEx)){
                strLen++;
            }
        }
        
        document.write("length = " + strLen);
       

    }
}

//CountStringCharacters();


function palindromeFun() {
    var originStr = prompt("palindrome ");
    var strArr = originStr.split(" ");

    var caseOption = confirm("Case Sensitive or not");
    
    if(caseOption){
    

        for(var i=0 ; i<strArr.length ; i++){
            var str = strArr[i];
            var ReverseArr = str.split("").reverse();
            var strReverse  = ReverseArr.join("");
    
            if(str === strReverse){
                document.write("Match ==> " +  str + " " + strReverse + "<br/>");
            }   
            else {
                document.write("Not Match ==> " +  str +  " "+   strReverse + "<br/>");
            }
        }
        
    }
    else {

        for(var i=0 ; i<strArr.length ; i++){
            var str = strArr[i];
            var ReverseArr = str.split("").reverse();
            var strReverse  = ReverseArr.join("");
            
            if(str.match('i') === strReverse.match('i')){
                document.write("Match ==> " +  str + " " +  strReverse + "<br/>");
            } 
            else {
                document.write("Not Match ==> " +  str +  " "+   strReverse + "<br/>");
            }  
            
        }
        
    }

   
}

palindromeFun();
    

    





//// 1.3 
/*
    *  Build your own function that takes a single string argument 
    *  returns the largest word in the string.
    *  If there are two or more words 
    * that are the same length,
    * return the first word from the string with that 
    length. 

*/
function getLargestLength(stringValue){

    var strArr = stringValue.split(" ");
    var maxLen = strArr[0].length;
    var fsMaxIndx = 0;
    for(var i=0 ; i<strArr.length ; i++){

        if(maxLen < strArr[i].length){
            maxLen = strArr[i].length;
            fsMaxIndx = i;
        }
    }

    document.write("max length = " + maxLen + "<br> Value = " + strArr[fsMaxIndx] + "<br>");
}

getLargestLength("this is javascript a string demo");



// Task 1.4  
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


