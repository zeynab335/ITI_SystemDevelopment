const userModel = require("../Models/Users");
const doctorModel = require("../Models/Doctors");
const patientModel = require("../Models/Patients");

const bcrypt = require("bcrypt");


let AddNewUser= async (req,res) => {
    console.log("add new user");
    // get body of request
    let newUser = req.body;
    // this line is responsible for create collection Users
    let foundUser = await userModel.findOne({email:newUser.email}).exec();//found[true] || notFound[false]

    if(foundUser) return res.status(401).json({message:"User Already Exist !!"});

    let newUSER = await new userModel(newUser);
    await newUSER.save();

    if(newUser.type == "doctor"){
        let doctor = {user:newUSER._id}
        let newDoc = await new doctorModel(doctor);
        await newDoc.save();
    }
    else{
        let patient = {user:newUSER._id}

        let newPatient = await new patientModel(patient);
        await newPatient.save();
    }

   
    return res.status(201).json({message:"User Added Successfully",data:newUSER});
}


let LoginUser = async (req,res)=>{
    //DB
    let logUser = req.body;//From Client
    let foundUser = await userModel.findOne({email:logUser.email}).exec();//From DB [Encrypted]
    if(!foundUser) return res.status(401).json({message:"Invalid Email Or Password"});

    //2)Check Password
    let checkPass = bcrypt.compareSync(logUser.password, foundUser.password);//true | false
    if(!checkPass) return res.status(401).json({message:"Invalid Email Or Password"});

    res.status(200).json({message:"Logged-In Successfully"})

}


module.exports = {
    AddNewUser,
    LoginUser
}
