import React from 'react';
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

const RegistrationForm = (): JSX.Element => {
  const navigate = useNavigate();

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
          <Button variant='contained' className='google-button'>
            <FcGoogle />
            Sign in with Google
          </Button>
        </Form>
      )}
    </Formik>
  );
};

export { RegistrationForm };
