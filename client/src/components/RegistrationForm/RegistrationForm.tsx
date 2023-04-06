import React from 'react';
import { Formik, Form} from 'formik';
import { Button, Typography } from '@mui/material';
import { FcGoogle } from 'react-icons/fc'
import {InputFormField} from '../InputFormField';
import './RegistrationForm.scss';
import { useNavigate } from 'react-router-dom';
import { validationSchema } from './helpers/validation';

interface FormValues {
  email: string;
  password: string;
}

const RegistrationForm = (): JSX.Element => {
  const navigate = useNavigate();
  const submitHandler = (values: FormValues) => {
    localStorage.setItem('isLoggedIn', 'true');
    console.log(values);
    navigate('/home');
  }
  return (
    <Formik
      initialValues={{ email: '', password: '' }}
      validationSchema={validationSchema}
      validateOnChange={true}
      validateOnBlur={true}
      validateOnMount={true}
      onSubmit={values=>submitHandler(values)}
    >
      {({ isValid }) => (
        <Form className="registration-form">
          <Typography variant="h5" gutterBottom>
            Registration
          </Typography>
          <InputFormField label="Email" name="email" type="email" />
          <InputFormField label="Password" name="password" type="password" />
          <Button className="forgot-password-button">Forgot password?</Button>
          <Button
            type="submit"
            variant="contained"
            color="primary"
            disabled={!isValid}
            size="large"
            sx={{width: '60%'}}
          >
            Register
          </Button>
          <Button variant="contained" className='google-button'>
              <FcGoogle/>
              Sign in with Google
          </Button>
        </Form>
      )}
    </Formik>
  );
};

export {RegistrationForm};