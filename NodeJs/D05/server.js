//*Requires
const express = require('express');
const mongoose = require('mongoose');

const bodyParser = require('body-parser');
const PORT = process.env.PORT||7010;
//* end Requires

const app = express();

//* Middleware 
app.use(bodyParser.urlencoded({extended:true}));
app.use(bodyParser.json());
//* end Middleware

//* connect to db
mongoose.connect("mongodb://127.0.0.1:27017/API_D05" ,{useNewUrlParser:true});

//* Routes
 //#region user Routes
 const UsersRoutes = require("./Routes/UserRoutes");
 app.use("/api/users",UsersRoutes)
//#endregion

 //#region user Routes
 const DoctorRoutes = require("./Routes/DoctorRoutes");
 const PatientRoutes = require("./Routes/PatientRoutes");

 app.use("/api/doctors",DoctorRoutes);
 app.use("/api/patient" , PatientRoutes);
//#endregion

app.listen(PORT, ()=>{console.log("http://localhost:"+PORT)});
