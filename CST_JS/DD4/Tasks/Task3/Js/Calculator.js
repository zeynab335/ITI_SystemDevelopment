
//* Start Decleration 
var Result =0;
var answer = document.getElementById('Answer');
//* end Decleration 


function EnterEqual(){
    Result =  eval(answer.value);   
    answer.value = Result 
}

function EnterNumber(value){
    answer.value += value.trim();
    
}

function EnterOperator(value){
    answer.value += value.trim();
    Result += value.trim();
}

function EnterClear(){
    answer.value = "";    
    Result = 0;    
}

