let tbody = document.getElementById('tbody');

try{
    fetch("../Client.json").then(
        res =>res.json()).then(data => {
            console.log(data);
            data.forEach(element => {
                
                let fName = document.createElement("td");
                fName.appendChild(document.createTextNode(element.fName));
    
                let lName = document.createElement("td");
                lName.appendChild(document.createTextNode(element.lName));

                let email = document.createElement("td");
                email.appendChild(document.createTextNode(element.email));
    
                let mobile = document.createElement("td");
                mobile.appendChild(document.createTextNode(element.mobile));
    
                let address = document.createElement("td");
                address.appendChild(document.createTextNode(element.address));
    
                let tr = document.createElement("tr")
                tr.appendChild(fName);
                tr.appendChild(lName);
                tr.appendChild(email);
                tr.appendChild(mobile);
                tr.appendChild(address);
    
                tbody.appendChild(tr);
            }); 
               
                    
            
        }
            
    )
}
catch{
    document.querySelector('table').style.display = 'none';
    document.querySelector('.alert').style.display = 'block';


}
