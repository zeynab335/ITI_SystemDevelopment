
/* 
    *2. Create a function that accepts only 2 parameters and 
    * throw exception if number of parameters either less than or exceeds 2 parameters
*/

function checkParameters(){
        
    var length = arguments.length ;
    
    if(length < 2){
        throw new Error("number of parameters less than 2 , it must be 2");;
    }
    else if (length > 2){
        throw new Error("number of parameters greater than 2 , it must be 2 ");;
    }
    else {
        console.log("valid")
    }
  
}
checkParameters(5,3);
//* Error
checkParameters(3);
//* Error
checkParameters(5,4,10,12);