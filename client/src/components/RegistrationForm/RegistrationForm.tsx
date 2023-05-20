import React, { useEffect } from 'react';
import { Formik, Form } from 'formik';
import { Button, Typography } from '@mui/material';
import { InputFormField } from '../InputFormField';
import { useNavigate } from 'react-router-dom';
import { validationSchema } from './helpers/validation';
import routes from '../../const/routes';
import './RegistrationForm.scss';
import AuthService from '../../services/AuthService';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

interface FormValues {
  email: string;
  password: string;
}

const initialValues: FormValues = {
  email: '',
  password: '',
};

const clientId = "801059873983-1g644inr6eibjs8mcb5ejm7olt7s994v.apps.googleusercontent.com";

function handleLoginExternal(res: any){
  console.log('Callback response', res);
  AuthService.loginExternal({provider: "Google", idToken: res.credential });
}

const RegistrationForm = (): JSX.Element => {
  const navigate = useNavigate();

  const notify = (error: string) => {
    toast.error(error)
  }

  useEffect(() => {
    if (localStorage.getItem('isLoggedIn') === 'true') {
      navigate(routes.DASHBOARD);
    }

    google.accounts.id.initialize({
      client_id: clientId,
      callback: handleLoginExternal
    });

    google.accounts.id.renderButton(
      document.getElementById("signinDiv")!,
      { theme: "outline", size: "large", type: "standard", text: "signin_with" }
    );
  });

  const submitHandler = async (values: FormValues) => {
    await AuthService.login(values)
      .then(x => {
        localStorage.setItem('token', x.data.token);
        navigate(routes.DASHBOARD);
      })
      .catch(error => {
        console.log('error')
        console.log(error);
        notify(error);
      });
  };

  return (
    <>
      <Formik
        initialValues={initialValues}
        validationSchema={validationSchema}
        validateOnMount={true}
        onSubmit={submitHandler}
      >
        {({ isValid }) => (
          <Form className='registration-form'>
            <Typography variant='h5' gutterBottom>
              Registration
            </Typography>
            <InputFormField label='Email' name='email' type='email' />
            <InputFormField label='Password' name='password' type='password' />
            <Button className='forgot-password-button'>Forgot password?</Button>
            <Button
              type='submit'
              variant='contained'
              color='primary'
              disabled={!isValid}
              size='large'
              sx={{ width: '60%' }}
            >
              Register
            </Button>
            <div id="signinDiv"></div>
          </Form>
        )}
      </Formik>
      <ToastContainer />
    </>
  );
};

export { RegistrationForm };