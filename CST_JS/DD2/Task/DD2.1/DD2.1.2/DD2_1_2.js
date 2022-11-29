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
    