

var InputLabels = ['Name','Email','Phone','ComplainMsg']

//* Add Complain Elements into cookies after clicking on Send Button
$('#btnSend').click(
    function(){
        InputLabels.forEach(function(element) {
            console.log(element)
            var InputValue  = $("#" + element).get(0).value;
            setCookie(element , InputValue )    
        });

        //* Then Will Appear ComplainFormDetails
        $('.ComplainDetails').hide();
        DisplayComplainDetails();
        $('.ComplainFormDetails').fadeIn(1000);

         
    }

)

//* Display Data From Complain 
function DisplayComplainDetails(){
    InputLabels.forEach(function(element) {
        $('.Details #' + element).text(getCookie(element))
    })
}

$('#btnBackToForm').click(
    function(){
        $('.ComplainFormDetails').hide();
        DisplayComplainDetails();
        $('.ComplainDetails').fadeIn(1000);
        
        InputLabels.forEach(function(element) {
            $('#' + element).attr("placeholder" , getCookie(element))
        })
    }
  

)

