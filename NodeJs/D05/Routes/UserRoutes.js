const express = require("express");
const Router = new express.Router();

const UserController = require("../Controllers/UserController");

Router.post("/reg",UserController.AddNewUser);
Router.post("/login",UserController.LoginUser);


module.exports = Router;


