var obj = {
    getSetGen : getSetGen
} 

function getSetGen() {
    //* ['Name', 'Age', 'getSetGen']
    var properties = Object.keys(this);
    var caller = this;

    //* for each prop => create setter , getter method
    for (var i = 0; i < properties.length; i++) {

        var Setter = "set" + properties[i] ; //? setName
        var Getter = "get" + properties[i] ; //? getName

        //* IIFE => Immediate Invoking Function Expression 
        //* [to avoid Clusure problem with blocking scope ]
        caller[Setter] = (function(i){
            //? send parameter Value to set in Properties
            return function(Value){
                caller[properties[i]] = Value
            }
        })(i)

        caller[Getter] = (function(i){
            return function(){
                return caller[properties[i]]
            }
        })(i)
    }
    
}

Employee = {Name:"emp" , Age:15 , Address:''};
console.log(Employee)

obj.getSetGen.call(Employee);

Employee.setName("ddd")
Employee.setAge(10)

console.log(Employee)
console.log(Employee.getName())


