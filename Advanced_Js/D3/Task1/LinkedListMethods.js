

//& getter and setter for the list 
function getList(){
    console.log("%c Array Elements = " , "color:blue");
    this.List.forEach(function(ele){
        console.log(ele);
    });
    console.log("%c***********************" , "color:blue");

}

// & Append a new value 
function Append(ele){
    if(this.isEmpty() && ele === this.start){
        //* when List is Empty 
        this.List.push(ele);
    }
        
    else if(((this.List[this.List.length-1] + this.step) === ele) && ele <= this.end && !this.CheckDuplication(ele)){ 
        //* [2,4] and step = 2 
        //? check if element increase from last element in list with step number 
        this.List.push(ele);
    }
    else{
        throw new Error("Invalid Number, Please Try Again");
    }

}

// & prepend a new value 
function Prepend (ele){
    if(this.isEmpty() && ele === this.start){
        //* when List is Empty 
        this.List.unshift(ele);
    }
    // [2,4] step 2  ==> elem = 0                
    else if( (this.List[0]- this.step == ele) && (ele == this.start) && !this.CheckDuplication(ele)){ 
        //? check if element increase from last element in list with step number 
        this.List.unshift(ele);
    }
    else{
        throw new Error("Invalid Number, Please Try Again");
    }

}

// & Dequeue a value,
function Dequeue(){
    if(!this.isEmpty()){
        //* when List is Empty 
        this.List.shift();
    }
    else{
        throw new Error("List Empty");
    }


}

// & POP a value,
function Pop (){
    if(!this.isEmpty()){
        //* when List is Empty 
        this.List.pop();
    }
    else{
        throw new Error("List Empty");
    }


}

