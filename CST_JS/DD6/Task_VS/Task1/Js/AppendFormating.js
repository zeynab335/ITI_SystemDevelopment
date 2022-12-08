
//? Append Formating in Html file


//* Formtaing arr from Properties js file
var FormatingDiv        = document.getElementById('Formating');
for (var property  in Formating) {
    
    //* Create Container of Formating Details
    var FormatingDetails    = document.createElement('div');
    var ClassOfFormatingDetails = document.createAttribute('class');
    ClassOfFormatingDetails.value = 'FormatingDetails';
    
    FormatingDetails.setAttributeNode(ClassOfFormatingDetails);

    //? create P element to display name of property
    var Paragraph   = document.createElement('p');
    var ParagraphText  = document.createTextNode(property);
    FormatingDetails.prepend(ParagraphText);


    //? create input element to display name of property
    for (let i = 0; i < Formating[property].length; i++) {
       
        //* Create Container of Form Group
        var formGroup        = document.createElement('div');
        var formGroupClass   = document.createAttribute('class');
        formGroupClass.value = 'FormGroup';
        formGroup.setAttributeNode(formGroupClass);

        //* start Create Radio Btns in Form Group
        var radioBtn    = document.createElement('input');
        //? Start Create Radio Btn Attributes in Form Group
        var inputType   = document.createAttribute('type');
        inputType.value = 'radio';
        
        var inputName   = document.createAttribute('name');
        inputName.value = property;

        var inputClass   = document.createAttribute('class');
        inputClass.value = property;

        var inputID     = document.createAttribute('id');
        inputID.value   = Formating[property][i];

        var inputValue  = document.createAttribute('value');
        inputValue.value   = Formating[property][i];
        //? End Create Radio Btn Attributes in Form Group
        
        //? Append Radio Btns Attributes  in Radio Btns
        radioBtn.setAttributeNode(inputType);
        radioBtn.setAttributeNode(inputName);
        radioBtn.setAttributeNode(inputID);
        radioBtn.setAttributeNode(inputValue);
        radioBtn.setAttributeNode(inputClass);

        //? Append Radio Btns Attributes in formGroup
        formGroup.append(radioBtn);
        
        //* end Create Radio Btns in Form Group

        //? Start Create Radio Btn Lables in Form Group
        var radioBtnLable    = document.createElement('label');
        var LabelFor   = document.createAttribute('for');
        var LableText    = document.createTextNode(Formating[property][i]);

        LabelFor.value = property;
        
        //* Append text into label
        radioBtnLable.append(LableText);

        //? end Create Radio Btn Lables in Form Group

        
        //* Append label into formGroup div
        formGroup.append(radioBtnLable);


        FormatingDetails.append(formGroup);        
    }
    

    
    
    FormatingDiv.append(FormatingDetails);

}