const express = require("Express");
const path = require("path");
const fs = require("fs");

const app = express();


let Client = fs.readFileSync("Client.json").toString();
let profileHtml = fs.readFileSync("../Client/Html/Profile.html").toString();

let userDetails = {}
let AllUsers  = []

function loadJson(fileName){
    if(fs.existsSync(fileName)&& Client.length > 0 ){
        return Client;
    }
    else{
        return null;
    }
  
}

//* Request Html Files
app.get("/",(req,res)=>{
    res.sendFile(path.join(__dirname,"../Client/Html/Main.html"))
})
app.post("/",(req,res)=>{    
    req.on("data", (data)=>{
        data.toString().split("&").map((element,index) => {
            let [prop , value ] = element.split("=");
            
            if(value.includes("%2B")){
                value = value.replace('%2B' , '+20')
            }
            if(value.includes("%40")){
                value = value.replace('%40' , '&')
            }
            
            userDetails[prop] = value;
        });
        JsonData = loadJson("Client.json");
        if(JsonData){
            AllUsers = JSON.parse(JsonData);
        }
        AllUsers.push(userDetails);
        fs.writeFileSync("Client.json" , JSON.stringify(AllUsers) );
    })
    req.on("end" , ()=>{
            
        res.write(profileHtml
        .replace("{clientName}", `${userDetails.fName} ${userDetails.lName}` )
        .replace("{Email}",userDetails.email)
        .replace("{MobileNumber}",userDetails.mobile)
        .replace("{Address}",userDetails.address)
        );
        res.end();
    })

    

})

app.get("/GetAllData.html",(req,res)=>{
    res.sendFile(path.join(__dirname,"../Client/Html/GetAllData.html"))
})

//* Request Css File
app.get("/Main.css",(req,res)=>{
    res.sendFile(path.join(__dirname,"../Client/Css/Main.css"))
})

//* Request Js Files
app.get("/Js/Main.js",(req,res)=>{
    res.sendFile(path.join(__dirname,"../Client/Js/Main.js"))
})
app.get("/Js/GetAllData.js",(req,res)=>{
    res.sendFile(path.join(__dirname,"../Client/Js/GetAllData.js"))
})

app.get("/Client.json",(req,res)=>{
    res.sendFile(path.join(__dirname,"/Client.json"))
})

//* Request ICon 
app.get("/favicon.ico",(req,res)=>{
    res.sendFile(path.join(__dirname,"../Client/Icons/favicon.ico"))
})

app.listen(7001,()=> {console.info("http://www.localhost:7001")})