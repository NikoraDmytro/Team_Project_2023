import React from 'react';
import { Formik, Form} from 'formik';
import { Button, Typography } from '@mui/material';
import { FcGoogle } from 'react-icons/fc'
import {InputFormField} from '../InputFormField';
import './RegistrationForm.scss';
import { validationSchema } from './helpers/validation';

const RegistrationForm = (): JSX.Element => {
  return (
    <Formik
      initialValues={{ email: '', password: '' }}
      validationSchema={validationSchema}
      validateOnChange={true}
      validateOnBlur={true}
      validateOnMount={true}
      onSubmit={values=>console.log(values)}
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