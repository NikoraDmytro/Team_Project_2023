import http from './index';
import { LoginModel } from '../models/Auth';
import { SignupModel } from '../models/Auth';
import { ExternalLoginModel } from '../models/Auth';

const BASE_URL = 'auth/';

type Token = {
  token: string;
};

const AuthService = {
  login: async (loginModel: LoginModel): Promise<Token> => {
    return await http.post(BASE_URL + 'login', loginModel);
  },

  signup: async (signupModel: SignupModel): Promise<Token> => {
    return await http.post(BASE_URL + 'signup', signupModel);
  },

  loginExternal: async (
    externalLoginModel: ExternalLoginModel,
  ): Promise<Token> => {
    return await http.post(BASE_URL + 'login-external', externalLoginModel);
  },

  isUserAuthenticated() {
    return localStorage.getItem('token');
  },

  logout() {
    localStorage.removeItem('token');
  },
};

export default AuthService;
