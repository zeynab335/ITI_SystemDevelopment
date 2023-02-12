import { Ploygon } from "./Ploygon.js";

export class Rectangle extends Ploygon{
    
    constructor(d1,d2){
        super(d1, d2)
    }

    toString(){
        console.log( `Area of Rectanle = ${this.Dim1 * this.Dim2} ` )
    }


}