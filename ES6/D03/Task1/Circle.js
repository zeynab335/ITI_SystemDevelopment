import { Ploygon } from "./Ploygon.js";

export class Circle extends Ploygon{
    
    constructor(r){
        super(r)
    }

    toString(){
        console.log( `Area of Circle = ${Math.pow( this.Dim1 , 2) * 3.14}  ` )
    }


}