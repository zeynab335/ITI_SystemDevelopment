function viewHeadings(){
    var headingTitle = prompt("Pleae Enter Your Message");
    for(var i=1 ; i<=6 ; i++){
        document.write(`<h${i}>  ${headingTitle} ${i} </h${i}> <br>`);
    }
}

viewHeadings();




function SumValues(){
    var Sum=0 , num , flageLessZero=0; 
    do{
        num = parseInt(prompt("Enter your num"));

        if(isFinite(num) && num!=0){
            Sum+=num;
        } 
        else flageLessZero=1 ;

    }
    while(Sum<100 && !flageLessZero);


    document.write("Sum Numbers = " + Sum );

}

SumValues();

