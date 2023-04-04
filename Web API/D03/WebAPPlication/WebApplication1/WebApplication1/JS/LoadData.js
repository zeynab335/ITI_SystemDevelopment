let tbodyRef = document.getElementById('TBody');
let AddBtn = document.getElementById('AddBtn');
AddBtn.addEventListener("click", addBtn);
start();

function start() {
    fetch('https://localhost:7185/api/Departments').then((Departments => {
        return Departments.json();
    })).then(Departments => {
       
        for (let dept of Departments) {
            console.log(dept
                )
            let id = document.createElement("td");
            id.appendChild(document.createTextNode(dept.id));

            let Name = document.createElement("td");
            Name.appendChild(document.createTextNode(dept.name));

            let Location = document.createElement("td");
            Location.appendChild(document.createTextNode(dept.location));

            let Description = document.createElement("td");
            Description.appendChild(document.createTextNode(dept.description));

            let tr = document.createElement("tr")
            tr.appendChild(id);
            tr.appendChild(Name);
            tr.appendChild(Location);
            tr.appendChild(Description);

            tbodyRef.appendChild(tr);
                
        }
    });
}

function deleteBtn() {
    fetch('https://localhost:7185/api/Departments/' + this.value,
        {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            },
            body: null
        })
        .then(res => {
            let row = document.getElementById(this.rowNum);
            row.parentNode.removeChild(row);
        })
        .catch((error) => {
            Alert("Error:", error);
        });
}

function addBtn() {
    location.href = "add.html";
}