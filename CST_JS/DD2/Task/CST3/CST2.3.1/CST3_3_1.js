//? Task2 Point 2.1 in Day2

//&  SortAsc Funciton
function DisplayElement(...Elements) {
    
    document.write(
        "<p class='red'> u've entered the Values of  </p> " 
        + 
        Elements.join(' , ')
        + "<br>" 
    )    
    
}

//& compare fun => used to parse it to fix when sorting using unicode
function Compare(num1 , num2){
    if(num1>num2) {return 1;}
    else if(num1<num2) {return -1;}
    else {return 0;}
}

function CompareInDesc(num1 , num2) {return num2-num1;}

//&  Sort Funciton
//? if Sort in Asc ==> will send True as Argument
//? if Sort in Desc ==> will send False as Argument

function Sort(SortAsc,...Elements ) {
    var SortedElements = SortAsc 
        //* Sorted Elements in Asc Way
        ? Elements.sort(Compare).join(' , ') 
        //* Sorted Elements in Desc Way
        : Elements.sort(CompareInDesc).join(' , ')
    
    document.write(
        `<p class='red'> u've values being sorted  
            ${ SortAsc ? 'Ascending' : 'Descending' }
        </p> `
        + 
        SortedElements
        + "<br>"
    )    
    
}


//&  GetElements Funciton
function GetElements(){

    //* Array of Elements
    var Elements = [];
    for(var i=0 ; i<5 ; i++){
        Elements[i] = parseInt(prompt(`Enter Element => ${i+1}`));
    }

    //* invoke DisplayElement Function
    DisplayElement(...Elements);
    
    //* invoke Sort Array in Desc Way Function
    //? first Argument => check Desc 
    Sort(false , ...Elements);

    //* invoke Sort Array in Asc Way Function
    //? first Argument => check Desc 
    Sort(true , ...Elements);


};
GetElements()

