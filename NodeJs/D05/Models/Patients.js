const Users = require("./Users");

// connect to [mongo db] using third Party mongoose 
const mongoose = require('mongoose');

// 2- create schema
PatientSchema = new mongoose.Schema({
    user: { type: mongoose.Schema.Types.ObjectId, ref: 'Users' },
})

// connect schema with collection
module.exports = mongoose.model("Patients" , PatientSchema);