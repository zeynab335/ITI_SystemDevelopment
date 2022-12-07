
//& Validation Functions
onload = function () {
        
    //* Regular Exp
    var EmailRegExp  = /^[\w]+@[\w]+[\w]+(\.)[\w]{2,4}$/;
    var MobileRegExp = /^011|010|012+[0-9]{8}$/ ;
    var isFormValid = true;

    // * Email Validation
    document.getElementById('email').onchange = function(){
       var Error = document.getElementById('EmailError')
        var isEmailVaild     = EmailRegExp.test(this.value);
        if(!isEmailVaild){
            isFormValid = false;
            Error.innerText = "Please Enter Valid Email"
        }
        else{
            Error.innerText = '';
            isFormValid = true;
        }
    }
    
    // * mobile Validation
    document.getElementById('mobile').onchange = function(){
        var Error = document.getElementById('MobileError');
        var isMobileVaild     = isFinite(this.value) && (MobileRegExp.test(this.value))
        
        if(!isMobileVaild){
            isFormValid    = false;
            Error.innerText = "Phone number must be 11 numbers" 
        }
        else{
            Error.innerText = '';
            isFormValid = true;
        }
    }


    // ? check if form is valid or not
    document.querySelector('.btnSubmit').onclick = function(){
        var Error = document.getElementById('isFormValid');
        console.log(isFormValid);
        if(!isFormValid) {
            Error.innerText = "Please Enter Valid Data to be able to submitted"
            //* prevent default handler
            document.RegisterForm.action = "#";
            return false;
        }   
        else {
            Error.innerText = '';
            document.RegisterForm.action = "./WelcomePage.html";
            isFormValid = true;
        }
        
    }  

}

