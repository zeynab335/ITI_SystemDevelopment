
//* Calc Area Fun 
function calcArea (){
    return (this.width *  this.height)
} 

//* Calc Perimeter Fun 
function calcPerimeter (){
    return (this.width +  this.height) * 2
} 


//* Calc Perimeter Fun 
function displayInfo() {
    console.log ("Width = " ,  this.width , "Height = ", this.height)
} 


//*  Constructor method 
var Rectangle = function (w=100 , h=200) {
   
    this.width  = w 
    this.height = h 

    //* CalcArea Method
    this.calcArea = calcArea 

    //* CalcPerimeter Method
    this.calcPerimeter = calcPerimeter

      //* displayInfo Method
      this.displayInfo = displayInfo

}


//* With Default Constractot

var Rec1 = new Rectangle();
console.log("%c Rectangle 1 [100 , 200] " , "color:yellow")
console.log("Area = " , Rec1.calcArea())
console.log("Perimeter = " , Rec1.calcPerimeter())
Rec1.displayInfo();


//* Without Default Constractot
var Rec2 = new Rectangle(20,40);
console.log("%c Rectangle 2 [20 , 40] " , "color:yellow")
console.log("Area = " , Rec2.calcArea())
console.log("Perimeter = " , Rec2.calcPerimeter())
Rec2.displayInfo();




