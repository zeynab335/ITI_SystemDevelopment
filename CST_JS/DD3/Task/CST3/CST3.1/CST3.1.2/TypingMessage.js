

var Timer;
var Message = "Hello Guys, This is Day5 in CST 💖";

//& ShowMessageContent using SetInterval function
function ShowMessageContent(){
    var TypingCharacter = "" ; 
    var MessageContent = Message.split("");
    
    Timer = setInterval(function(){
        
        TypingCharacter = MessageContent.shift();
        
        //? check if no Character in Message 
        if(TypingCharacter !== undefined){
            document.write(TypingCharacter);
        }
        else{
            //* will clear interval when Message content End 
            clearInterval(Timer);
            document.write("<h1> Ending Message </h1>" );
            
            //* will close window after 1 second
            setTimeout(function(){
                window.close();
            },1000)
        }
    },100)
}
ShowMessageContent();

