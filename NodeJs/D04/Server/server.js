const express = require('express');
const path = require('path');
const http = require('http');
const socket = require('socket.io');
const app = express();
const server =  http.createServer(app);


const io  = socket(server);

const bodyParser = require("body-parser");
app.use(bodyParser.urlencoded({extended:true}));
app.use(bodyParser.json());

// use static files
app.use(express.static(path.join(__dirname,'Static')));

const PORT = 3000 || process.env.PORT;

app.get("/",(req,res)=>{
    res.render('Index.ejs')
})

//* Socket.io 
let users = {};

io.on('connection',socket => {
    console.log("New User Connected ");
    socket.on('new-user', name => {
        name = name;
        console.log(`${name} connected ❤`);
        users[socket.id] = name
        socket.broadcast.emit('user-connected', name)
    })



    socket.on('send-message', message => {
        // send message to all users expect [Sender user]
        console.log(`${users[socket.id]} send Message ❤`);

        socket.broadcast.emit('receive-message', { message: message, name: users[socket.id] })
    })



})


server.listen(PORT , console.log(`server running on port ${PORT}`));
