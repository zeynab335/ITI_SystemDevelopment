
const socket = io();
const messageContainer = document.querySelector('.message-container')
const Messages = document.querySelector('#Messages')

const WelcomeContainer = document.querySelector('.new-user')

const message = document.querySelector('#message')


let Name = prompt("Enter Ur name");

if(Name){
    socket.emit('new-user',Name);
    appendWelcomeMessage('You')

}

//* send-message
document.querySelector('#btn-submit')?.addEventListener('click',()=>{
    console.log(message.value);
    let messageContent =  message.value;
    appendMessage(messageContent , Name);
    socket.emit('send-message',messageContent);
    message.value = "";
})

//* receive-message
socket.on('receive-message', data => {
    appendMessage(data.message , data.name);
})

socket.on("user-connected",(name)=>{
    appendWelcomeMessage(name);
})


function appendMessage(message , name) {
    console.log(message ,name)
    const messageElement = document.createElement('div')
    if(name == Name){
        messageElement.classList.add("send-message")
    }
    else{
        messageElement.classList.add("receive-message")
    }
    const br = document.createElement("br");

    messageElement.innerText = message
    Messages.append(messageElement)
}

function appendWelcomeMessage(name) {
    const WelcomeMessage = document.createElement('h6')
    WelcomeMessage.innerText = `${name} Connected  ❤ `;
    WelcomeContainer.innerHTML = WelcomeMessage.innerText;
}


