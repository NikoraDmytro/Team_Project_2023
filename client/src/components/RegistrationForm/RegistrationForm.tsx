import React, { useEffect } from 'react';
import { Formik, Form } from 'formik';
import { Button, Typography } from '@mui/material';
import { FcGoogle } from 'react-icons/fc';
import { InputFormField } from '../InputFormField';
import { useNavigate } from 'react-router-dom';
import { validationSchema } from './helpers/validation';
import routes from '../../const/routes';
import './RegistrationForm.scss';

interface FormValues {
  email: string;
  password: string;
}

const initialValues: FormValues = {
  email: '',
  password: '',
};

const clientId = "<your-client-id>";

function handleCallbackResponse(res: any){
  console.log('Callback response', res);

  fetch("https://localhost:7238/api/auth/login-external",{
    method: "POST", 
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({provider: "Google", idToken: res.credential })
  })
    .then(res => res.json())
    .then(res => console.log(res))
    .catch(error => console.log(error));
}

const RegistrationForm = (): JSX.Element => {
  const navigate = useNavigate();

  useEffect(() => {
    if (localStorage.getItem('isLoggedIn') === 'true') {
      navigate(routes.DASHBOARD);
    }

    google.accounts.id.initialize({
      client_id: clientId,
      callback: handleCallbackResponse
    });

    google.accounts.id.renderButton(
      document.getElementById("signinDiv")!,
      { theme: "outline", size: "large", type: "standard", text: "signin_with" }
    );
  });

  const submitHandler = (values: FormValues) => {
    localStorage.setItem('isLoggedIn', 'true');
    console.log(values);
    navigate(routes.DASHBOARD);
  };

  return (
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
  );
};

export { RegistrationForm };
