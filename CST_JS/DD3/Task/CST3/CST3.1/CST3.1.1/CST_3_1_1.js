/* 
    * 1.1.1. Create a parent window that opens a flying child window. 
    * Hint: Start by creating a parent window that opens a child window. 
    * Child window should always be on top view and moves up and down within boundaries of user screen.
    * Parent window should contain a button that stops child window movement.
*/

var WindowTimer ,FlyWin;
//* url of oppening page inside Parent Window
var url = "./CST_Demo.html";

//* create global var to enable close child window 
var FlyWin = window.open(url,"","width=200,height=100");

//& Create FlyingWindow function to display flying window automatically
function FlyingWindow() {

    //? Start Decleration of Parent Window
    var ParentWindowWidth = (window.innerWidth/2);
    var ParentWindowHeight = (window.innerHeight/2);

    //? end Decleration of Parent Window


    //? Start Decleration of Child Window
    var XPos = 0;
    var YPos = 0;
    var change= 0;

    FlyWin.focus();
    //? end Decleration of Child Window


    WindowTimer = setInterval(function(){

        //* to prevent child window from resizing
        FlyWin.resizeTo(300,150);

        //? check if ChildWindow Reach in the end of Parent Page => if yes [will decrease pos of child]
        //* enter when change = 0
        if((!change) && ((ParentWindowWidth>XPos) || (ParentWindowHeight > YPos)) )
        {   
            change = 0;  

            XPos += 50;
            YPos += 50;
            FlyWin.focus();
            FlyWin.moveBy(XPos,YPos);
        }
        else{
            //* enter when XPos > 0 && YPos > 0 
            if(XPos>0 && YPos>0 ){
                change=1;
                XPos -= 50;
                YPos -= 50;
                FlyWin.focus();
                FlyWin.moveBy(-XPos,-YPos);
            }
            //* change [in this case use change to go to case 2 ]
            else{
                XPos = 0;
                YPos = 0;
                change = 0;
            }
            
        }
    },50)

}
FlyingWindow();


function stop(){
    clearInterval(WindowTimer);
    FlyWin.close();
}