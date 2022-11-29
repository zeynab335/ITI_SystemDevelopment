//? Task2 Point 2.1 in Day2

//&  Sum Funciton
function Sum(num1 , num2 , num3) {
    var sum = num1 + num2 + num3;
    var sumEqusion = num1 + "+" + num2 + "+" + num3 + " = " + sum + "<br>"  ;
    document.write(
        "<p class='red'> Sum of the 3 Values =  </p> " + sumEqusion  + "<br>" 
    )
}

//&  Multiplication Funciton
function Multiplication(num1 , num2 , num3) {
    var multi = num1 * num2 * num3;
    var multiEqusion = num1 + "*" + num2 + "*" + num3 + " = " + multi ;
    document.write(
        "<p class='red'> Multiplication of the 3 Values =  </p> " + multiEqusion + "<br>" 
    )
}

//&  Division Funciton
function Division(num1 , num2 , num3) {
    var devision = num1 / num2 / num3;
    var devisionEqusion = num1 + "/" + num2 + "/" + num3 + " = " + devision ;
    document.write(
        "<p class='red'> Division of the 3 Values =  </p> " + devisionEqusion  + "<br>"   
    )
}


//&  GetElements Funciton
function GetElements(){
    //* Array of Elements
    var Elements = [];
    for(var i=0 ; i<3 ; i++){
        Elements[i] = parseInt(prompt(`Enter Element => ${i+1}`));
    }

    //* invoke Sum Function
    Sum(Elements[0],Elements[1],Elements[2]);
    
    //* invoke Multiplication Function
    Multiplication(Elements[0],Elements[1],Elements[2]);
    
    //* invoke Division Function
    //* can use Destructure Array
    Division(...Elements);

};
GetElements()

