const http = require("http");
const fs = require("fs");
let MainHtml    = fs.readFileSync("../Client/Html/Main.html").toString();
let GetAllDataHtml = fs.readFileSync("../Client/Html/GetAllData.html").toString();
let MainJs      = fs.readFileSync("../Client/Js/Main.js").toString();
let GetAllData  = fs.readFileSync("../Client/Js/GetAllData.js").toString();
let MainCss     = fs.readFileSync("../Client/Css/Main.css").toString();
let FavIcon     = fs.readFileSync("../Client/Icons/favicon.ico");
let profileHtml = fs.readFileSync("../Client/Html/Profile.html").toString();
let Client = fs.readFileSync("Client.json").toString();


//let AllUsersJson = 


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

http.createServer((req , res)=>{
    //*#region Get
    console.log(req.url);

    if(req.method == "GET"){
        switch(req.url){
            // Request Html File
            case "/" :
            case "/Main.html" :
            case "/Client/Main.html":
                res.write(MainHtml);
            break;

            case "/" :
            case "/GetAllData.html" :
            case "/Client/GetAllData.html":
                res.write(GetAllDataHtml);
            break;

            // Request Css File
            case "/Main.css" :
            case "/Client/Main.css":
                res.write(MainCss);
            break;

            // Request Js File
            case "/" :
            case "/Js/Main.js" :
            case "/Client/Js/Main.js":
                res.write(MainJs);            
            break;

            case "/" :
                case "/Js/GetAllData.js" :
                case "/Client/Js/GetAllData.js":
                    res.write(GetAllData);            
            break;

            // Request ICon 
            case '/favicon.ico':
            case '/Client/favicon.ico':
            case '/Client/Icons/favicon.ico':
                res.write(FavIcon);
            break;

            // Request Client json 
            case '/Client.json':
            case '/Client/Client.json':
                //let c = fs.readFileSync("../Client/Client.json").toString()
                //console.log("client" , c , Client);
                res.write(loadJson("Client.json"));
            break;
        }
        res.end();

    }
    //*#endregion
    
    else if(req.method == "POST"){
        req.on("data", (data)=>{
            data.toString().split("&").map((element,index) => {
                let [prop , value ] = element.split("=");
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
    }
}).listen(7000,()=>{console.log("Listining on Port 7000")})
