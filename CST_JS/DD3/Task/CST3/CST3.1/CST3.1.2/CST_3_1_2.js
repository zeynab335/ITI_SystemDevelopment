/* 
    * Write a script that shows a “typing message” appearing in a new child window.
    * The new window should close after few seconds of displaying your message
*/


function ShowMessage(){
    var url = "./TypingMessage.html";
    var style = "width=500,height=500"
    //* create global var to enable close child window 
    var ChildWin = window.open(url,"",style);

}

