/* 
    * 1.1.1. Create a parent window that opens a flying child window. 
    * Hint: Start by creating a parent window that opens a child window. 
    * Child window should always be on top view and moves up and down within boundaries of user screen.
    * Parent window should contain a button that stops child window movement.
*/

//* create global var to enable close child window 

var win = open("./CST_Demo.html","","width=300,height=150");

var flyingWindow = setInterval(()=>{
    
})


function stop(){
    clearInterval(flyingWindow);
    win.close();
}