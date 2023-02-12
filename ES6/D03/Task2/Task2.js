// create dynamic Obj
let obj = {
    name: "",
    address : "",
    age : 10
}

let Handler = {
    set(target , prop , value ){
        // name Prop 
        if(prop == 'name' && typeof( value) == 'string' && value.length == 10){
            target[prop] = value;
        }

        // address prop
        else if(prop == 'address' && typeof(value) == 'string'){
            target[prop] = value;
        }

        // age
        else if(prop == 'age' && typeof(value) == 'number' && (value >= 25 && value <= 60  )){
            target[prop] = value;
        }
        else {
            throw "obj not have this Property"
        }
    }
}
var proxy = new Proxy(obj , Handler); 
// proxy.x = 10; // error
proxy.age = 25; // {name: '', address: '', age: 25}
proxy.name = "stringname"  // {name: 'stringname', address: '', age: 25}