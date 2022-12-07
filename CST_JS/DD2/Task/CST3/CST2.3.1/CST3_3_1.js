//? Task2 Point 3.1 in Day2
/*
    * Enter the value of a circle’s radius in order to calculate its area as shown in fig
    * Enter another value to calculate its square root and alert the result as shown in fi
    * Enter another the value to calculate its cos value then display the output as shown in Fig
*/


//& Calculate Square Root Function
function CalcSquareRoot(sqrRoot){
    alert(`Square Root of ${sqrRoot} is ${Math.sqrt(sqrRoot)}`) ;
}

//& Calculate Circle's Area Function
function CalcCircleArea(Radius){
    var Area = Math.PI * Math.pow(Radius,2);
    alert( "Total area of the circle is " + Area);
}

//& Calculate Cons Function
function CalcCos(Degree){
    //* Equasion ==>  ( x * pi ) / 180
    return Math.cos(( Degree * Math.PI ) / 180).toFixed(4) ;
}


//&  GetElements Funciton
function GetElements(){

    var Radius = parseInt(prompt("What is the value of Circles radius","types raduis here"));  
    
    //* invoke CalcCircleArea Function
    CalcCircleArea(Radius);
    
    var SquareRoot = parseInt(prompt("What is the value you want to calculate its square root","types your value here"));

    //* invoke CalcSquareRoot Function
    CalcSquareRoot(SquareRoot);

    var Degree = parseInt(prompt("What is the Angle you want to calculate its cons","types your value here"));

    //* invoke CalcCos Function
    var ConsDegree = CalcCos(Degree);
    document.write( "Cos " + Degree + "°" + " is " + ConsDegree );    
};
GetElements();

