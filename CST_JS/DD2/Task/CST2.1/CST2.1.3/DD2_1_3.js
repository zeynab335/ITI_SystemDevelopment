//? Task 1 Point 1.3 in Day2

/*
    *  Build your own function that takes a single string argument 
    *  returns the largest word in the string.
    *  If there are two or more words 
    * that are the same length,
    * return the first word from the string with that length. 

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





