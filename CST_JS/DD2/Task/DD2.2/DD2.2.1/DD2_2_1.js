//? Task1 Point 1.1 in Day2

//& CountStringCharacters Funcitoon
function CountStringCharacters(){
    var stringFromUsr = prompt("Enter Your string");
    var confirmDiffCharacter = confirm("Case Sensitive or not");
    var Expression =  prompt("Enter Your Character");
    
    var strLen = 0;
    ///* case inSesitive
    if(!confirmDiffCharacter){
        var regEx = new RegExp(Expression , 'i');
        
        for(var i in stringFromUsr){
            if(stringFromUsr[i].match(regEx)){
                strLen++;
            }
        }
        
        document.write("length = " + strLen);

    }
    else {
        ///* case Sensitive
        var regEx = new RegExp(Expression);
        
        for(var i in stringFromUsr){
            if(stringFromUsr[i].match(regEx)){
                strLen++;
            }
        }
        
        document.write("length = " + strLen);
    }
}

CountStringCharacters();


