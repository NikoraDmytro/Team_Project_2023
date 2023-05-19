export class LoginModel{
    email!: string;
    password!: string;
}

export class SignupModel{
    email!: string;
    password!: string;
}

export class ExternalLoginModel{
    provider!: string;
    idToken!: string;
}