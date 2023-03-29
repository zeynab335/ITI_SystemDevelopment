function Sum(arr){
    let sum = 0;
    arr.forEach(num => {
        sum +=  parseInt(num);
    });
    return sum;
}
function Subtract(arr){
    let sub = arr[0];
   for(var i=1 ; i<arr.length ; i++){
    sub -= arr[i];
   }
    return sub;
}
function Multibly(arr){
    let multibly = 1;
    arr.forEach(num => {
        multibly *=  parseInt(num);
    });
    return multibly;
}

function Div(arr){
    console.log("division")
    let division = 1;
    try{
        arr.forEach(num => {
            division /=  parseInt(num);
        });
        console.log(division);

    }
    catch{
        division = "can't apply this operation";
    }
    finally{
        return division
    };

}

var fs = require("fs");
var http = require("http");

http.createServer((req,res)=>{
    //logic
    if(req.url != "/favicon.ico"){
        //console.log(req.url);
        let url  = req.url.split('/');
        let numbers = url.splice(2);

        let operation = url[1];

        switch(operation){
            case "add" || "Add" || "ADD":
                fs.appendFile("File.txt" , `Add Numbers ${Sum(numbers)} \n`, ()=>{})
                break;

            case "minus" || "Minus":
                fs.appendFile("File.txt" , `Subtract Numbers ${Subtract(numbers)} \n`,()=>{})

                break;
            
            case "Multibly" || "multibly" || '*': 
                fs.appendFile("File.txt" , `Multibly Numbers ${Multibly(numbers)} \n `,()=>{})

                break;
            
            case "divide" : 
                console.log("div")
                fs.appendFile("File.txt" , `Division Numbers ${Div(numbers)} \n`,()=>{})

                break;

            default:
                console.log("default");
                break;
        }
      
        res.end();
    }
}).listen(7000)