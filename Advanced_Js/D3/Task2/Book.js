
//* Constractor function
function Book(title){
    this.title = title;
    
    //* When initiate any book will increase number of books
    this.CountBooks = Book.prototype.CountBooks++;
} 


Object.defineProperties(Book.prototype,{
    
    //* Create Class Property that counts numbers of created books objects and Class method to retrieve it. 
    CountBooks:{
        value: 0,
        writable:true,
    },
    getNumberOfBooks : {
        value : function(){
            return this.CountBooks;
        }
        ,writable:true
    },
    title:{
        value:'',
        writable:true,
        configurable:false,
        enumerable:false
    },
    numofChapters:{
        value:0,
        writable:true,
        configurable:false,
        enumerable:false
    },
    author:{
        value:'',
        writable:true,
        configurable:false,
        enumerable:false
    },
    numofPages:{
        value:'',
        writable:true,
        configurable:false,
        enumerable:false
    },
    publisher:{
        value:'',
        writable:true,
        configurable:false,
        enumerable:false
    },
    numofCopies:{
        value:0,
        writable:true,
        configurable:false,
        enumerable:false
    }
})


var Book1 = new Book();
Book1.title = "lll"

var Book2 = new Book();
Book2.title = "lll"

