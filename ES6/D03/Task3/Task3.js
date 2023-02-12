// fetch users from Api
// let data = [];

var UsersContainer  = document.querySelector("#Body");

var request = fetch('https://jsonplaceholder.typicode.com/users')
    .then(res => res.json() )
    .then(
        function( data){
            data.forEach(element => {
                console.log(element)
                UsersContainer.innerHTML += `    
                    <tr>
                        <th scope="row">${element.id}</th>
                        <td class="table-active">${element.name}</td>
                        <td>${element.email}</td>
                    </tr>
                `
            })
            
        }
    )





