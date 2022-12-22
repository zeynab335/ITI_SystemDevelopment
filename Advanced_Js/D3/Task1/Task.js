//* TODO: Create your own object
//*Your constructor takes 3 parameters to define start, end of list and step

function LinkedList(start , end , step){

    //The list should be private and filled with private method
    var List = [];
    //& check in Arrguments if NAN
    if(CheckTypeOfArrguments(start , end , step))
    {
        //? check if lisy is empty or not
        var isEmpty = function(){
            if(List.length === 0 )return 1;
            return 0;
        }

        //& getter and setter for the list 
        this.getList  = function(){
            console.log("%c Array Elements = " , "color:blue");
            List.forEach(function(ele){
                console.log(ele);
            });
            console.log("%c***********************" , "color:blue");

        }

        // & Append or prepend a new value 
        this.Append  = function(ele){
            if(isEmpty && ele === start){
                //* when List is Empty 
                List.push(ele);
            }
                
            else if(((List[List.length-1] + step) === ele) && ele <= end){ 
                //* [2,4] and step = 2 
                //? check if element increase from last element in list with step number 
                List.push(ele);
            }
            else{
                throw new Error("Invalid Number, Please Try Again");
            }
        
        }
        // & Dequeue or pop a value,
    }
}



//& Check type of Arrguments
function CheckTypeOfArrguments(start , end , step){
    var isArrgumentsValid = isFinite(start) &&  isFinite(end) &&  isFinite(step)
    if(!isArrgumentsValid) throw new Error("Please Enter Valid Parameters, it must be a number");
    return 1;
}



var l1 = new LinkedList(2,5,1);
l1.Append(2)
l1.Append(3)
l1.Append(4)

l1.getList()


