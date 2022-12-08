//* Formtaing arr from Properties js file
var i=0;
var flag;
var AllFormating = {};

    document.getElementById('btnSubmit').onclick = function(){
        for (var property  in Formating) {
            for (let i = 0; i < Formating[property].length; i++) {
                var propertyValueSelected = document.getElementById(Formating[property][i]);
                if(propertyValueSelected.checked){
                    console.log("yes")
                    AllFormating[property] = Formating[property][i]
                }     
            } 
           
        }

        ApplyFormating()
            
    }


    function ApplyFormating(){
        //* Apply Formating in content
        var content = document.querySelector('.TestContent').firstElementChild;
        var Style=''
        for (var property in AllFormating) {
            Style += (property+':'+ AllFormating[property].replace("'",' ')) + ' ; ';
            console.log(Style)
            content.setAttribute('style', Style);
        }    
            
    }
    



