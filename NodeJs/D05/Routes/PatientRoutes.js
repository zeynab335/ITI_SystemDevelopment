const express = require("express");
const router = new express.Router();
const PatientController = require("../Controllers/PatientController");

router.get("/" , PatientController.GetAllPatients );
router.get("/:id" , PatientController.GetPatientData );
router.put("/:id" , PatientController.UpdatePatientData );
router.delete("/:id" , PatientController.DeletePatient );


module.exports = router;