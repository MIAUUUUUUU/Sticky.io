import Account from "./Model/Account";
import { element } from "./Helpers/DOM";

interface UILoginElements {
    formLogin?: HTMLFormElement,
    inputUsername?: HTMLInputElement,
    inputPassword?: HTMLInputElement,
    inputEMail?: HTMLInputElement,
    btnLogin?: HTMLElement,
    errorContainer?: HTMLElement
}

function paragraph(text: string): HTMLParagraphElement {
    var p = document.createElement("p");

    p.innerHTML = text;

    return p;
}

class UI {
    account: Account;

    elements: UILoginElements;

    constructor() {
        // Get all Elements
        this.elements = {
            formLogin: element("#form-register", HTMLFormElement),
            inputUsername: element("#username", HTMLInputElement),
            inputPassword: element("#password", HTMLInputElement),
            inputEMail: element("#email", HTMLInputElement),
            btnLogin: element("#do-register", HTMLElement),
            errorContainer: element("#errors", HTMLElement)
        };

        // Initialize Elements
        this.elements.errorContainer.textContent = this.elements.errorContainer.textContent.trim();

        this.elements.btnLogin.addEventListener("click", (e: Event) => {
            let username = this.elements.inputUsername.value;
            let password = this.elements.inputPassword.value;
            let email = this.elements.inputPassword.value;

            this.account = new Account(username, password, email);

            if (this.isValid) {
                this.elements.formLogin.submit();
            }

            e.preventDefault();
            e.stopPropagation();
        });
    }

    get isValid(): boolean {
        let error: HTMLParagraphElement | null = null;

        this.elements.errorContainer.innerHTML = null;

        if (!this.account.IsValidUsername) {
            error = paragraph("Empty or invalid username!");
        } else if (!this.account.IsValidEMail) {
            error = paragraph("Empty or invalid email address!");
        } else if (!this.account.IsValidPassword) {
            error = paragraph("Empty or invalid password!");
        }

        if (error === null) return true;

        this.elements.errorContainer.appendChild(error);
        return false;
    }
}

var ui = new UI();
