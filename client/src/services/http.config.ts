import { AxiosError, AxiosRequestConfig, AxiosResponse } from 'axios';

export const setConfig = (config: AxiosRequestConfig): AxiosRequestConfig => {
  const token = localStorage.getItem('token');

  if (token) {
    config.headers['Authorization'] = `Bearer ${token}`;
  }
  return config;
};

export const catchError = (error: AxiosError): Promise<string> =>
  Promise.reject(error);

export const getResponseWithHeader = (response: AxiosResponse): AxiosResponse =>
  response;

export const getResponseData = (response: AxiosResponse): AxiosResponse =>
  response.data;

export const showError = (error: AxiosError): Promise<string> => {
  switch (error.response?.status) {
    case 404:
      console.error('Error 404');
      break;

    case 403:
      console.error('Error 403 Forbidden');
      break;

    case 401:
      console.error('Error 401 Unauthorized');
      break;

    case 500:
      console.error('Internal Server Error');
      break;

    case undefined:
      console.error("Couldn't reach the api server");
  }

  return Promise.reject(error);
};
