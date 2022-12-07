
//* Start Decleration 
var Result =0;
var answer = document.getElementById('Answer');

var Numbers = [];
var Operators = [];

var indexOfNumbers = 0;
var indexOfOperators = 0;


//* end Decleration 


function EnterEqual(){

    
    var Regex =/['-'||'*'||'/'||'+']/  

    Numbers = answer.value.split(Regex);    

    for(var i=0 ; i<answer.value.length ; i++){
        switch (answer.value[i]) {
            case '+':
                Operators[indexOfOperators++] = answer.value[i] 
                break;

            case '-':
                Operators[indexOfOperators++] = answer.value[i] 
                break;
            case '*':
                Operators[indexOfOperators++] = answer.value[i] 
                break;
            case '/':
                Operators[indexOfOperators++] = answer.value[i] 
                break;
        }
    }
    console.log(Operators);
    console.log(Numbers)
    Calculation();

}

function EnterNumber(value){
    answer.value += value.trim();
}

function EnterOperator(value){
    answer.value += value.trim();
}

function EnterClear(){
    answer.value = "";    
    Result = 0;   
    Numbers = [];
    Operators = [];
    indexOfNumbers = 0;
    indexOfOperators = 0;
}


function Calculation(){
    Result = parseInt(Numbers[0]);
    var j=0;
    for(var i=1 ; i<Numbers.length ; i++){
        console.log(Result, Numbers[i],Operators[j] , j)
        switch (Operators[j]) {
                case '+':
                    Result += parseInt(Numbers[i]) ;
                    console.log(Result)
                    break;
    
                case '-':
                    Result -= parseInt(Numbers[i]) ;                   
                    break;
                
                case '*':
                    Result *= parseInt(Numbers[i]);                   
                    break;
                case '/':
                   console.log('/')
                    Result /= parseInt(Numbers[i]);                   
        }
        j++;
    }
    answer.value = Result;
}
