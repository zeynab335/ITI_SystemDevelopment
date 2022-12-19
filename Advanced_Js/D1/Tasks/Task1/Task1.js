//* create linked List obj
var LinkedList = 
{
    data            : []            ,
    Enqueue         : Enqueue       ,
    Insert          : Insert        ,
    Pop             : Pop           ,
    RemoveItem      : RemoveItem    ,
    DequeueItem     : Dequeue       ,
    DisplayList     : DisplayList   ,
    AddNewProperty  : AddNewProperty,
    CheckDuplication: CheckDuplication,     
}


//* check if List Is Empty
function isEmpty(){
    var length = LinkedList.data.length
    if(length !== 0){
        return 0;
    }
    return 1;
}

//* (push an item at the end of the list with the passed value
function Enqueue (value){
    var checkListISEmpty = isEmpty();
    var Data = LinkedList.data;

    if(checkListISEmpty){
        Data.push(value);
    }
    else{
        //* when put <= [this will throw error ]
        if(Data[Data.length-1] < value){
            Data.push(value);
        }
        else{
            throw Error("this value will violate the sequence of array")
        }
    }
}

//* Delete From The Begining of list
function Dequeue (){
    var checkListISEmpty = isEmpty();
    var Data = LinkedList.data;

    if(checkListISEmpty){
        console.log("List is Empty")
    }
    else{
       Data.shift();
    }
}

// * remove an item from the end of the list
function Pop (){
    var checkListISEmpty = isEmpty();
    var Data = LinkedList.data;

    if(checkListISEmpty){
        console.log("List is Empty")
    }
    else{
       Data.pop();
    }
}



/* 
 * Insert an item in a specific place 
 * as long as the value is missing from the sequence  
*/
function Insert (value){
    var Data = LinkedList.data;
    var index , isItemInserted;


    //* if use condition (!Data.includes(value))
    //* in this case will aviod duplication
    //if(!Data.includes(value)){
        for (var i = 0; i < Data.length ; i++) {
            if(Data[i] > value){
                //* will insert after this value
                index = Data.indexOf(Data[i]) ;
                Data.splice(index, 0 ,value)  
                isItemInserted = 1  
                return;
            }
          
            else {
                isItemInserted = 0;
            }

            
        }
        //? after looping in all list that not have value less than this value 
        //? push it in the end of list 
        if(!isItemInserted){
            Data.push(value)
        }
        //* can add undefined when adding new element
        //? 0 => number of elements that you want to delete
    //}      
    
}

function RemoveItem(value){
    var checkListISEmpty = isEmpty();
    var Data = LinkedList.data;

    if(checkListISEmpty){
        console.log("List is Empty")
    }
    else{
        if(Data.includes(value)){
            var index = Data.indexOf(value)

            //* splice can delete elemet by adding index number
            //* otherwise add undefined when adding new element
            //? 1 => number of elements that you want to delete
            Data.splice(index,1)   
        }
        else{
            console.log(" “data not found”")
        }
             
    }
}


//* You can add any property you need.
function AddNewProperty (property , value){
    //* add new property without value
    if(!!!value){
        Object.defineProperty(LinkedList , property ,{})
    }
    //* add new property with value
    else{
        Object.defineProperty(LinkedList , property , {
            value : value
        })

    }    
}


//* Ensure that there is no duplication in your entered values. 
 
function CheckDuplication(){
    var checkListISEmpty = isEmpty();
    var Data = LinkedList.data;

    if(checkListISEmpty){
        console.log("List is Empty")
    }
    else{
      for (var i = 0; i < Data.length; i++) {
        if(Data[i] === Data[i+1]) {
            throw new Error("There is duplication in linked list ")
        }
      }
    }
}

//* Display the content of the list
function DisplayList (){
    var checkListISEmpty = isEmpty();
    var Data = LinkedList.data;

    if(checkListISEmpty){
        console.log("List is Empty")
    }
    else{
      console.log(Data.join(' , '));
    }
}

//* Showing Output In Console
function ShowingOutputInConsole(){

    //? Enqueue
    LinkedList.Enqueue(5);
    LinkedList.Enqueue(7);
    console.log("%c********* Enqeue Items  5 7 ********** " , "color : yellow")
    DisplayList();

    //? Dequeue
    LinkedList.DequeueItem(5);
    console.log("%c********* Dequeue 5  ********** " , "color : yellow")
    DisplayList();

    //? Pop
    LinkedList.Pop();
    console.log("%c********* Pop Last Elemet => 7 ********** " , "color : yellow")
    DisplayList();

    //? Add New Property
    AddNewProperty("prop" , "zzz");
    AddNewProperty("prop2");
    console.log("%c********* add new prop in LinkedList ********** " , "color : yellow")
    console.log(LinkedList);

    //? InsertItems
    Insert(10)
    Insert(4)
    Insert(20)
    Insert(15)
    
    console.log("%c********* Inert Items  10 4 20 15 ********** " , "color : yellow")
    DisplayList();

    //? RemoveItem not found
    console.info("%c********* Remove Item not found => 1 ********** ","color : red" )
    RemoveItem(1)

    //? RemoveItem
    console.info("%c********* Remove Item 10  ********** ","color : yellow" )
    RemoveItem(10)
    DisplayList();

    //? Duplication
    console.info("%c********* Check Duplication  ********** ","color : red" )
    console.log("%c********* Inert Item 4 ********** " , "color : yellow")
    Insert(4)
    DisplayList();
    
    CheckDuplication()
}

ShowingOutputInConsole();