/******/ (function(modules) { // webpackBootstrap
/******/ 	// The module cache
/******/ 	var installedModules = {};

/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {

/******/ 		// Check if module is in cache
/******/ 		if(installedModules[moduleId])
/******/ 			return installedModules[moduleId].exports;

/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = installedModules[moduleId] = {
/******/ 			exports: {},
/******/ 			id: moduleId,
/******/ 			loaded: false
/******/ 		};

/******/ 		// Execute the module function
/******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);

/******/ 		// Flag the module as loaded
/******/ 		module.loaded = true;

/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}


/******/ 	// expose the modules object (__webpack_modules__)
/******/ 	__webpack_require__.m = modules;

/******/ 	// expose the module cache
/******/ 	__webpack_require__.c = installedModules;

/******/ 	// __webpack_public_path__
/******/ 	__webpack_require__.p = "";

/******/ 	// Load entry module and return exports
/******/ 	return __webpack_require__(0);
/******/ })
/************************************************************************/
/******/ ([
/* 0 */
/***/ function(module, exports, __webpack_require__) {

	module.exports = __webpack_require__(4);


/***/ },
/* 1 */,
/* 2 */
/***/ function(module, exports) {

	"use strict";
	var Account = (function () {
	    function Account(Username, Password, EMail) {
	        this.Username = Username;
	        this.Password = Password;
	        if (EMail) {
	            this.EMail = EMail;
	        }
	    }
	    Object.defineProperty(Account.prototype, "IsValidUsername", {
	        get: function () {
	            return (this.Username.trim().length > 0);
	        },
	        enumerable: true,
	        configurable: true
	    });
	    Object.defineProperty(Account.prototype, "IsValidPassword", {
	        get: function () {
	            return (this.Password.trim().length > 0);
	        },
	        enumerable: true,
	        configurable: true
	    });
	    Object.defineProperty(Account.prototype, "IsValidEMail", {
	        get: function () {
	            var emailFormat = /[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?/;
	            return (this.EMail.trim().length > 0 && emailFormat.test(this.EMail));
	        },
	        enumerable: true,
	        configurable: true
	    });
	    return Account;
	}());
	Object.defineProperty(exports, "__esModule", { value: true });
	exports.default = Account;


/***/ },
/* 3 */
/***/ function(module, exports) {

	"use strict";
	function element(selector, constructor) {
	    var result = getElement(selector);
	    if (!(result instanceof constructor)) {
	        throw new Error("Selector \"" + selector + "\" didn't return the required element type.");
	    }
	    return result;
	}
	exports.element = element;
	function getElement(selector) {
	    var element = document.querySelector(selector);
	    if (element === null) {
	        throw new Error("Selector \"" + selector + "\" didn't return any element.");
	    }
	    return element;
	}
	exports.getElement = getElement;


/***/ },
/* 4 */
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	var Account_1 = __webpack_require__(2);
	var DOM_1 = __webpack_require__(3);
	function paragraph(text) {
	    var p = document.createElement("p");
	    p.innerHTML = text;
	    return p;
	}
	var UI = (function () {
	    function UI() {
	        var _this = this;
	        // Get all Elements
	        this.elements = {
	            formLogin: DOM_1.element("#form-register", HTMLFormElement),
	            inputUsername: DOM_1.element("#username", HTMLInputElement),
	            inputPassword: DOM_1.element("#password", HTMLInputElement),
	            inputEMail: DOM_1.element("#email", HTMLInputElement),
	            btnLogin: DOM_1.element("#do-register", HTMLElement),
	            errorContainer: DOM_1.element("#errors", HTMLElement)
	        };
	        // Initialize Elements
	        this.elements.errorContainer.textContent = this.elements.errorContainer.textContent.trim();
	        this.elements.btnLogin.addEventListener("click", function (e) {
	            var username = _this.elements.inputUsername.value;
	            var password = _this.elements.inputPassword.value;
	            var email = _this.elements.inputPassword.value;
	            _this.account = new Account_1.default(username, password, email);
	            if (_this.isValid) {
	                _this.elements.formLogin.submit();
	            }
	            e.preventDefault();
	            e.stopPropagation();
	        });
	    }
	    Object.defineProperty(UI.prototype, "isValid", {
	        get: function () {
	            var error = null;
	            this.elements.errorContainer.innerHTML = null;
	            if (!this.account.IsValidUsername) {
	                error = paragraph("Empty or invalid username!");
	            }
	            else if (!this.account.IsValidEMail) {
	                error = paragraph("Empty or invalid email address!");
	            }
	            else if (!this.account.IsValidPassword) {
	                error = paragraph("Empty or invalid password!");
	            }
	            if (error === null)
	                return true;
	            this.elements.errorContainer.appendChild(error);
	            return false;
	        },
	        enumerable: true,
	        configurable: true
	    });
	    return UI;
	}());
	var ui = new UI();


/***/ }
/******/ ]);