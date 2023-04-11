
// connect to [mongo db] using third Party mongoose 
const mongoose = require('mongoose');

// 2- create schema
DoctorSchema = new mongoose.Schema({
    user: { type: mongoose.Schema.Types.ObjectId, ref: 'Users' },
})

// connect schema with collection
module.exports = mongoose.model("Doctors" , DoctorSchema);



