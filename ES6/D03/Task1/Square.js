import { Ploygon } from "./Ploygon.js";

export class Square extends Ploygon{
    
    constructor(L){
        super(L , L)
    }

    toString(){
        console.log(this);
        console.log( `Area of Square = ${this.Dim1} ` )
    }


}