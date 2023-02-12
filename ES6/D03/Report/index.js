//#region handler.apply

const handler = {
    apply (target,...argumentsList) {
        return target(...argumentsList[1]) * 10;
    }
};
  
function multiply(...arr) {
    let res = 1;
    arr.forEach(element => {
        res *= element;
    });
    return res;
}
  
const proxy1 = new Proxy(multiply, handler);
console.log(multiply(3,2)); // 6
console.log(proxy1(3,2)); // 60

//#endregion


//#region  definePropery
const handler1 = {

    defineProperty(target, key, descriptor) {
        target[key] = descriptor.value;  
        return true;
    }
  };
  
const obj1 = {};
const proxy2 = new Proxy(obj1, handler1);
  
proxy2._secret = 'easily scared'      
  
//#endregion 


//#region deleteProperty

const obj2 = {
    texture: 'scaly'
};
  
const handler2 = {
    deleteProperty(target, prop) {
      if (prop in target) {
        delete target[prop];
        console.log(`property removed: ${prop}`);
      }
    }
};
  
const proxy3 = new Proxy(obj2, handler2);
delete proxy3.texture;
//#endregion


//#region  GetPropertyOf
const obj3 = {
    prop: 4
};
  
const protoType = {
    prop: 4
};
  
const handler3 = {
    
    getPrototypeOf(target) {
      return protoType;  // return obj or null
    }
};
  
const proxy3_ = new Proxy(obj3, handler3);  

console.log(Object.getPrototypeOf(proxy3_).prop)  // Expected output: 2

//#endregion


//#region  ownKeys
var S = Symbol('secret Prop');

const obj4 = {
    name: "name",
    [S]: 'secret object descc !',
};
  
const handler4 = {
    ownKeys(target) {
      return Reflect.ownKeys(target);
    }
};
  
const proxy4 = new Proxy(obj4, handler4);
  
for (const key of Object.keys(proxy4)) {
    console.log(key);
    // Expected output: "name"
    }

//#endregion
  