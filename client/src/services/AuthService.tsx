import axios from 'axios';
import {LoginModel} from '../models/Auth'
import {SignupModel} from '../models/Auth';
import { ExternalLoginModel} from '../models/Auth';

const BASE_URL = "https://localhost:7238/api/auth/"

const AuthService = {
    login: async (loginModel: LoginModel) => {
        return await axios.post(BASE_URL + "login", loginModel);
    },
      
    signup: async (signupModel: SignupModel) => {
        return await axios.post(BASE_URL + "signup", signupModel);
    },

    loginExternal: async (externalLoginModel: ExternalLoginModel) => {
        return await axios.post(BASE_URL + "login-external", externalLoginModel);
    },

    isUserAuthenticated() {
        return localStorage.getItem('token');
    },

    logout() {
        localStorage.removeItem('token');
    }
}

export default AuthService;