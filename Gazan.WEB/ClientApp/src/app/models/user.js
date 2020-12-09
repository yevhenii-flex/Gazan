"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.User = void 0;
var User = /** @class */ (function () {
    function User(id, email, phoneNumber, password, passwordConfirm, role) {
        this.id = id;
        this.email = email;
        this.phoneNumber = phoneNumber;
        this.password = password;
        this.passwordConfirm = passwordConfirm;
        this.role = role;
    }
    return User;
}());
exports.User = User;
//# sourceMappingURL=user.js.map