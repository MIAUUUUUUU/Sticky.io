class Account {
    private Username: string;
    private Password: string;
    private EMail: string;

    constructor(Username: string, Password: string, EMail?: string) {
        this.Username = Username;
        this.Password = Password;
        if (EMail) {
            this.EMail = EMail;
        }
    }

    get IsValidUsername(): boolean {
        return (this.Username.trim().length > 0);
    }

    get IsValidPassword(): boolean {
        return (this.Password.trim().length > 0);
    }

    get IsValidEMail(): boolean {
        const emailFormat = /[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?/;

        return (this.EMail.trim().length > 0 && emailFormat.test(this.EMail));
    }
}

export default Account;
