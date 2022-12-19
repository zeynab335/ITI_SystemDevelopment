
//? get Reverse Function Version 1
function getReverseFunctionV1(){

    var Elements = Object.values(arguments);
    document.getElementById('Elements').innerText = "Elements = " +  Elements;

    Elements.reverse();
    document.getElementById('ReversedElements').innerText = "Reversed Elements = " +  Elements; 
}
/*
function getReverseFunctionV2(){
        
    var Elements = Object.entries(arguments);

    for (let i = 0; i < Elements.length; i++) {
        Elements[i] = Elements[i][1]
    }

    //* displat Element in sorted way
    document.getElementById('ElementsV2').innerText = "Elements = " +  Elements;

    Elements.reverse();
    //* displat Element in reversed way
    document.getElementById('ReversedElementsV2').innerText = "Reversed Elements = " +  Elements; 

}
*/


function getReverseFunctionV2(){

   //* when use bind => Element()
   //* can use apply , call => without calling function
   //* [Array.prototype.slice] This method can be used to convert the arguments object by binding this method to the object.
   
   var Elements = Array.prototype.slice.call(arguments);

    //* displat Element in sorted way
    document.getElementById('ElementsV2').innerText = "Elements = " +  Elements;

    Elements.reverse();
    //* displat Element in reversed way
    document.getElementById('ReversedElementsV2').innerText = "Reversed Elements = " +  Elements; 

}

getReverseFunctionV1(5,3,6,1);
getReverseFunctionV2(5,4,10,12);