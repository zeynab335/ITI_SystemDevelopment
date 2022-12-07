/* 
    * Create a parent a window that opens a scrollable advertising child window.
*/


function ShowAdvertising(){
    var url = "./Advertising.html";
    var style = "width=500,height=500"
    //* create global var to enable close child window 
    window.open(url,"",style);
}
