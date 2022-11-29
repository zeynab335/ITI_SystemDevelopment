//? Task 1 Point 1.2 in Day2

//& palindromeFun Function
function palindromeFun() {
    var originStr = prompt("palindrome ");
    var strArr = originStr.split(" ");

    var caseOption = confirm("Case Sensitive or not");
    
    //* Case SEnsitive
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
        //* Case inSEnsitive
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





