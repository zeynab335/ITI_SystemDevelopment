
/* 
    *3. Create an adding function that adds n numbers only.
    * Throw exception if the user passed any data type other than “number”
    *  or called your function without passing any parameters.
*/

function checkLengthOfParameters(){
    var length = arguments.length ;
    
    if(length < 1){
        throw new Error("number of parameters less than 1");
    }
    else{
        return 1
    }

}

//& get Numeric Elements 
//* check if Element is Numeric Or Not 
function getNumericElements(){
    var checkLength = checkLengthOfParameters(arguments);

    if(checkLength){
        var Elements = Object.values(arguments);
        var  NumericElements = [];
        //* check if type of elemnts is number => return true , otherwise => throw exception
        Elements.forEach( function(element) {
            var Elements = Object.values(element)
            
            for (let i = 0; i < Elements.length; i++) {
                if(isFinite(Elements[i])){
                    NumericElements.push(Elements[i]);
                }
                //* Throw Error When Parameters not a Number 
                else{
                    throw new Error("Type of Parameters must be numbers only");
                }
            }
            
        });   
        return NumericElements;
    }
}
    

function Add(){
    var Elements = getNumericElements(arguments);
    var sum = 0;

    for (let i = 0; i < Elements.length; i++) {
        sum += Elements[i]
    }
    console.log("Sum = " +sum)
}

Add(1,2);
Add(1);
Add("dd" , 2);
