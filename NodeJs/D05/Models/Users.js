// connect to [mongo db] using third Party mongoose 
// hash password using bcrypt
const bcrypt = require("bcrypt");
const mongoose = require('mongoose');


// 2- create schema
UserSchema = new mongoose.Schema({
    name:String,
    age:Number,
    email:String,
    password:String,
    type:String,
    // doctors: [{ type: mongoose.Schema.Types.ObjectId, ref: 'Doctor' }],
    // patients: [{ type: mongoose.Schema.Types.ObjectId, ref: 'Patient' }]

})

UserSchema.pre('save', function (next) {
    const user = this;
  
    if (!user.isModified('password')) {
      return next();
    }
  
    bcrypt.genSalt(10, (err, salt) => {
      if (err) {
        return next(err);
      }
  
      bcrypt.hash(user.password, salt, (err, hash) => {
        if (err) {
          return next(err);
        }
  
        user.password = hash;
        next();
      });
    });
    
  });
  
// connect schema with collection
module.exports = mongoose.model("Users" , UserSchema);





