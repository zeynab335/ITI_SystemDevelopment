//? Task1 Point 1.1 in Day2

function checkSenstivity(stringFromUsr,Sensitive,Expression){
    var strLen = 0;
    var regEx = Sensitive 
    //* case inSesitive
    ? new RegExp(Expression)
    //* case inSesitive
    : new RegExp(Expression , 'i')

    for(var i in stringFromUsr){
        if(stringFromUsr[i].match(regEx)){
            strLen++;
        }
    }
    
    document.write("length = " + strLen);
}


//& CountStringCharacters Funcitoon
function CountStringCharacters(){
    var stringFromUsr = prompt("Enter Your string");
    var Sensitive = confirm("Case Sensitive or not");
    var Expression =  prompt("Enter Your Character");
    
    //& invoke checkSenstivity function
    checkSenstivity(stringFromUsr,Sensitive,Expression)

}

CountStringCharacters();
