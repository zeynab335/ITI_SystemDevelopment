let AddNewDataBtn = document.getElementById('AddNewDataBtn')

AddNewDataBtn.addEventListener("click", saveData);


function saveData() {
    let newDepartment = {
        name: document.getElementById('txtName').value,
        location: document.getElementById('txtLocation').value,
        description: document.getElementById('txtDescription').value,
        branches: document.getElementById('txtBranch').value
    }
    console.log(newDepartment)
    fetch('https://localhost:7185/api/Departments',
        {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newDepartment)
        })
        .then(() => {
            location.href = "Index.html"
        })
        .catch((error) => {
            Alert("Error:", error);
        });
}