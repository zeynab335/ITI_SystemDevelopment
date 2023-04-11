const express = require("express");
const router = new express.Router();
const DoctorController = require("../Controllers/DoctorController");

router.get("/" , DoctorController.GetAllDoctors );
router.get("/:id" , DoctorController.GetDoctorData );
router.put("/:id" , DoctorController.UpdateDoctorData );
router.delete("/:id" , DoctorController.DeleteDoctor );


module.exports = router;