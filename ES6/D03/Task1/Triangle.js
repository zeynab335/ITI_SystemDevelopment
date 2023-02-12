import { Ploygon } from "./Ploygon.js";

export class Triangle extends Ploygon{
    
    constructor(d1,d2,d3){
        super(d1, d2)
        this.Dim3 = d3
    }

    toString(){
        console.log( `Area of Triangle = ${0.5 * this.Dim3 * this.Dim2} ` )
    }


}