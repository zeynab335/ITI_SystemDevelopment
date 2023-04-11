const DoctorModel  = require("../Models/Doctors");
const userModel  = require("../Models/Users");


let GetAllDoctors = async(req,res)=>{
    let Doctors = await DoctorModel.find().populate('user');
    return res.status(200).json(Doctors);
}


let GetDoctorData = async(req,res)=>{
    console.log(req.params.id);
    try{
        let doctorDetails = await DoctorModel?.findOne({_id:req.params.id}).populate('user').exec()
        return res.status(200).json(doctorDetails);

    }
    catch{
        return res.status(500).json({message:"User not Exist !!"});
    }
    
}


let UpdateDoctorData = async(req,res)=>{
       
        try {
            let updatedData = req.body;
            const findDoc = await DoctorModel.findOne({ _id: req.params.id}).exec();
            if(!findDoc){
               return res.status(500).send('Doctor not Found');
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
             res.status(200).json({message:"Doctor Updated Successfully" , result});

            }
           
          
            
        } catch (err) {
           
            console.error(err);
            res.status(500).send('Error updating user');
       }
    
  
    
}

let DeleteDoctor = async(req,res)=>{
       
    try {
        let updatedData = req.body;
        const findDoc = await DoctorModel.findOne({ _id: req.params.id}).exec();

        const filter = { _id: req.params.id };
       
        const deleteFromUsrDoc    = await userModel.deleteOne(findDoc.user);
        const deleteFromDoctorDoc = await DoctorModel.deleteOne(filter);

        res.status(200).json({message:"Doctor Deleted Successfully" , deleteFromDoctorDoc});
        
    } catch (err) {
       
        console.error(err);
        res.status(500).send('Error Deleting user');
   }



}

module.exports = {
    GetAllDoctors,
    GetDoctorData,
    UpdateDoctorData,
    DeleteDoctor
}