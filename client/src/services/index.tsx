import axios from 'axios';
import AuthService from './AuthService';
import BeltService from './BeltService';
import ClubService from './ClubService';
import CoachService from './CoachService';
import SportsmanService from './SportsmanService';
import UserService from './UserService';

import {
  catchError,
  getResponseData,
  setConfig,
  showError,
} from './http.config';

const http = axios.create({
  baseURL: process.env.REACT_APP_API_URL,
});

http.interceptors.request.use(setConfig, catchError);

http.interceptors.response.use(getResponseData, showError);

export {
  AuthService,
  BeltService,
  ClubService,
  CoachService,
  SportsmanService,
  UserService,
};

export default http;
