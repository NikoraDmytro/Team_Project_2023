import {LoginModel} from '../models/Auth'
import {SignupModel} from '../models/Auth';
import { ExternalLoginModel} from '../models/Auth';

const AuthService = {
    login: async (loginModel: LoginModel) => {
        await fetch("https://localhost:7238/api/auth/login", {
            method: "POST",
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(loginModel)
        })
        .then(res => res.json())
        .then(res => console.log(res))
        .catch(error => console.log(error));
    },
      
    signup: async (signupModel: SignupModel) => {
        await fetch("https://localhost:7238/api/auth/signup", {
            method: "POST",
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(signupModel)
        })
        .then(res => res.json())
        .then(res => console.log(res))
        .catch(error => console.log(error));
    },

    loginExternal: async (externalLoginModel: ExternalLoginModel) => {
        await fetch("https://localhost:7238/api/auth/login-external",{
            method: "POST", 
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(externalLoginModel)
        })
        .then(res => {
            res.json();
            localStorage.setItem('isLoggedIn', 'true');
        })
        .then(res => console.log(res))
        .catch(error => console.log(error));
    }
}

export default AuthService;