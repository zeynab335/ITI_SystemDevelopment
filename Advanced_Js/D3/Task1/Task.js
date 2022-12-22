//*! Note  ==> All Methods of LinkedList Implemented in LinkedListMethods */

//* TODO: Create your own object
//*Your constructor takes 3 parameters to define start, end of list and step

    function LinkedList(start , end , step){

        //The list should be private and filled with private method
        this.List  = [];
        this.start = start ;
        this.end   = end ;
        this.step  = step; 

        
       //& Check Duplication
        this.CheckDuplication = function(ele){
            if(this.List.includes(ele))return 1;
            return 0;
        }
        
        //? check if list is empty or not
        this.isEmpty = function(){
            if(this.List.length === 0 ) return 1;
            return 0;
        }
    }

   
    var L1 = new LinkedList(2,5,1);

    //* Define properties using data descriptor
    //! prevent them from being deleted, iterated or being modified.

    Object.defineProperties( L1 , {
        
        // & Append a new value 
        Append:{
            value: Append.bind(L1),
            configurable : false,
            enumerable : false,  //* false is deafult value
            writable : false
        },
        // & prepend a new value 
        Prepend:{
            value : Prepend.bind(L1),
            configurable : false,
            enumerable : false,  //* false is deafult value
            writable : false
        },
        // & Dequeue a value,
        Dequeue:{
            value : Dequeue.bind(L1),
            configurable : false,
            enumerable : false,  //* false is deafult value
            writable : false
        },
        // & POP a value
        Pop:{
            value : Pop.bind(L1),
            configurable : false,
            enumerable : false,  //* false is deafult value
            writable : false
        },
        getList:{
            value : getList.bind(L1),
            configurable : false,
            enumerable : false,  //* false is deafult value
            writable : false
        }
    })





    //l1.Append(2)
    L1.Prepend(2);
    // L1.Append(2);   //* Throw Error [Because Of Duplication Handling]

    L1.Append(3);

    L1.Append(4)
    L1.getList()    //*  2,3,4

    L1.Dequeue();   //* Dequeue 2 
    L1.Pop();       //* Pop 4

    L1.getList()    //* 3 





