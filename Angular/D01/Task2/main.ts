class Account{
    
    constructor(public Acc_no=1,public Balance=1000){}
    debitAmount(){

    }
    CreditAmount(){

    }
    getBalance(){

    }
}
interface IAccount{
    Date_of_opening
    addCustomer();
    removeCustomer();
}
class Saving_Account extends Account implements IAccount{
    Min_Balance;
    constructor(Acc_no ,Balance ,minBlnc?){
        super(Acc_no,Balance)
        this.Min_Balance=minBlnc

    }
    Date_of_opening: any;
    addCustomer() {
        throw new Error("Method not implemented.");
    }
    removeCustomer() {
        throw new Error("Method not implemented.");
    }

}
class Current_Account extends Account implements IAccount{
    Interest_rate;
    constructor(Acc_no ,Balance ,IntrstRte?){
        super(Acc_no,Balance)
        this.Interest_rate=IntrstRte
    }
    Date_of_opening: any;
    addCustomer() {
        throw new Error("Method not implemented.");
    }
    removeCustomer() {
        throw new Error("Method not implemented.");
    }
}