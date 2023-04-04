var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var Account = /** @class */ (function () {
    function Account(Acc_no, Balance) {
        if (Acc_no === void 0) { Acc_no = 1; }
        if (Balance === void 0) { Balance = 1000; }
        this.Acc_no = Acc_no;
        this.Balance = Balance;
    }
    Account.prototype.debitAmount = function () {
    };
    Account.prototype.CreditAmount = function () {
    };
    Account.prototype.getBalance = function () {
    };
    return Account;
}());
var Saving_Account = /** @class */ (function (_super) {
    __extends(Saving_Account, _super);
    function Saving_Account(Acc_no, Balance, minBlnc) {
        var _this = _super.call(this, Acc_no, Balance) || this;
        _this.Min_Balance = minBlnc;
        return _this;
    }
    Saving_Account.prototype.addCustomer = function () {
        throw new Error("Method not implemented.");
    };
    Saving_Account.prototype.removeCustomer = function () {
        throw new Error("Method not implemented.");
    };
    return Saving_Account;
}(Account));
var Current_Account = /** @class */ (function (_super) {
    __extends(Current_Account, _super);
    function Current_Account(Acc_no, Balance, IntrstRte) {
        if (Acc_no === void 0) { Acc_no = 0; }
        if (Balance === void 0) { Balance = 1000; }
        var _this = _super.call(this, Acc_no, Balance) || this;
        _this.Interest_rate = IntrstRte;
        return _this;
    }
    Current_Account.prototype.addCustomer = function () {
        throw new Error("Method not implemented.");
    };
    Current_Account.prototype.removeCustomer = function () {
        throw new Error("Method not implemented.");
    };
    return Current_Account;
}(Account));
var CA = new Current_Account();
