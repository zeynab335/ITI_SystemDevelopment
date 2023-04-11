const PatientModel  = require("../Models/Patients");
const userModel  = require("../Models/Users");


let GetAllPatients = async(req,res)=>{
    let Patients = await PatientModel.find().populate('user');
    return res.status(200).json(Patients);
}


let GetPatientData = async(req,res)=>{
    console.log(req.params.id);
    try{
        let PatientDetails = await PatientModel?.findOne({_id:req.params.id}).populate('user').exec()
        return res.status(200).json(PatientDetails);

    }
    catch{
        return res.status(500).json({message:"User not Exist !!"});
    }
    
}


let UpdatePatientData = async(req,res)=>{
       
        try {
            let updatedData = req.body;
            const findDoc = await PatientModel.findOne({ _id: req.params.id}).exec();
            if(!findDoc){
               return res.status(500).send('Patient not Found');
            }
            // console.log(findDoc.user.toString().substring(10,findDoc.user.length - 2))
            const findUsr = await userModel.findOne({ _id: findDoc.user}).exec();
            
            if(!findUsr){
                return res.status(500).send('User not Found');
            }
            else{
                console.log(findUsr)
                const result =  await userModel.updateOne({ _id: findUsr._id }, { $set: 
                    {
                        name:updatedData.name ,
                        age:updatedData.age,
                        email:updatedData.email,
                        password:findDoc? findUsr.password : updatedData.password ,
                        type:updatedData.type
                    }
                 });
             res.status(200).json({message:"Patient Updated Successfully" , result});

            }
           
          
            
        } catch (err) {
           
            console.error(err);
            res.status(500).send('Error updating user');
       }
    
  
    
}

let DeletePatient = async(req,res)=>{
       
    try {
        const findDoc = await PatientModel.findOne({ _id: req.params.id}).exec();

        const filter = { _id: req.params.id };
       
        const deleteFromUsrDoc    = await userModel.deleteOne(findDoc.user);
        const deleteFromPatientDoc = await PatientModel.deleteOne(filter);

        res.status(200).json({message:"Patient Deleted Successfully" , deleteFromUsrDoc});
        
    } catch (err) {
       
        console.error(err);
        res.status(500).send('Error Deleting user');
   }



}

module.exports = {
    GetAllPatients,
    GetPatientData,
    UpdatePatientData,
    DeletePatient
}