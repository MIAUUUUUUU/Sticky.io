class Account {
    private Username: string;
    private Password: string;

    constructor(Username: string, Password: string) {
        this.Username = Username;
        this.Password = Password;
    }

    get IsValidUsername(): boolean {
        return (this.Username.trim().length === 0);
    }

    get IsValidPassword(): boolean {
        return (this.Password.trim().length === 0);
    }
}

export default Account;
