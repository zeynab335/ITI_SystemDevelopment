
//* Constractor function
//height, width, length, material, content
function Box(height, width, length, material){
    
    //** The content property contains an array books 
    //* Private memeber 
    this.Content = [];
    this.height = height;
    this.width  = width ;
    this.length = length;
    this.material = material;
    this.NumOfBox = 0;

    this.addBook = function(){
        var ArrOfBooks = Array.prototype.slice.call(arguments)
        
        for(var i=0 ; i<ArrOfBooks.length ; i++){
            this.Content.push(ArrOfBooks[i])
        }

        //* Add Books in Box inside array to calculate Value of All Books in All Boxs
        var index = this.BoxDetails.length; //* to get last index
        this.BoxDetails[index]= {
            BoxObj : this,
            NumOfBox : this.Content.length
        };
    }

    //& Count # of books inside box 
    this.CountNumberOFBooks = function(){
        console.log(this.Content.length  + " Books");
    }

    this.deleteBook = function(bookTitle){
        var indexOfBook = this.Content.indexOf(bookTitle)
        this.Content.splice(indexOfBook);
        
        //decrease number of books in  BoxDetails in Prototype of constractor fun
        this.BoxDetails.forEach(
            (function(Box){
            console.log()
            if(Box.BoxObj == this){
                Box.NumOfBox --;
            }
            }).bind(this)
        )
    }
} 

//* To Define All Boxs Details 
//& Plus to Define valueOf Method
Object.defineProperties(Box.prototype,{
    BoxDetails:{
        //* BoxObj: {}
        //* NumOfBox : 0
        value:[],
        writable:true
    },
    valueOf : 
        {value : 
            function(){
                var NumberOFBooksInBox = 0;
                this.BoxDetails.forEach(Box => {
                    NumberOFBooksInBox += Box.NumOfBox
                });
                console.log("Number OF Books In All Boxs = " + NumberOFBooksInBox)
            }
        }
})


//& Use .toString() to display the box instance’s dimensions and how books are stored in it. 
Box.prototype.toString = function(){
    console.log("Width of Box = " , this.width)
    console.log("Height of Box = " , this.height)
    
    //* how books are stored in it. 
    //* Display Books Title
    var BooksTitle = [];
    for (var i = 0; i < this.Content.length; i++) {
        BooksTitle.push(this.Content[i].title)
    }
    console.log("Books in Box = " , BooksTitle.join(' , '))
}

var Book1 = new Book("Book1");
var Book2 = new Book("Book2");
var Book3 = new Book("Book3");
var Book4 = new Book("Book4");


var Box1 = new Box(200,200,5,"M.Box1");

Box1.addBook(Book1,Book2,Book3,Book4)


var Box2 = new Box(500,500,5,"M.Box2");
Box2.addBook(Book1,Book2)

console.log("%c ********** Desplay Box Details in Box1 ***********" , "color:yellow")
Box1.toString(); //* Width of Box =  200  //* Height of Box =  200


console.log("%c ********** Desplay Box Details in Box2 ***********" , "color:yellow")
Box2.toString(); //* Width of Box =  500  //* Height of Box =  500


console.log("%c ********** Count Number OF Books in Each Box ***********" , "color:yellow")
Box1.CountNumberOFBooks() //*  3 Books
Box2.CountNumberOFBooks()   //*  2 Books

console.log("%c ********** Count Number OF All Books in All Boxs ***********" , "color:yellow")
Box.prototype.valueOf();

console.log("%c ********** Delete Book1 & Book2 ***********" , "color:yellow")
Box1.deleteBook('Book1');
Box1.deleteBook('Book2');

Box.prototype.valueOf()





