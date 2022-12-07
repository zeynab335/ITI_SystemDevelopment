//? Task 1 Point 1.2 in Day2

function checkPaliderome(strArr , caseSensitivity){
    for(var i=0 ; i<strArr.length ; i++){
        var str = strArr[i];
        var ReverseArr = str.split("").reverse();
        var strReverse  = ReverseArr.join("");
        
        var cond = caseSensitivity ? (str === strReverse) : (str.match('i') === strReverse.match('i'))
        
        if(cond){
            document.write("Match ==> " +  str + " " + strReverse + "<br/>");
        }   
        else {
            document.write("Not Match ==> " +  str +  " "+   strReverse + "<br/>");
        }
    }
}

//& palindromeFun Function
function palindromeFun() {
    var originStr = prompt("palindrome ");
    var strArr = originStr.split(" ");

    var caseOption = confirm("Case Sensitive or not");
    
    //* Case SEnsitive
    checkPaliderome(strArr , caseOption) ;

   
}

palindromeFun();
    