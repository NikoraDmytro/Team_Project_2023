import React from 'react';
import { Formik, Form} from 'formik';
import { Button, Typography } from '@mui/material';
import { FcGoogle } from 'react-icons/fc';
import { Box } from '@mui/system';
import InputFormField from '../InputFormField/InputFormField';
import './RegistrationForm.css';

interface FormValues {
  email: string;
  password: string;
}

const RegistrationForm: React.FC = () => {
  const validate = (values: FormValues) => {
    const errors: Partial<FormValues> = {};
    const emailRegex = /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$/i;
    if (!values.email) {
      errors.email = 'Email is required';
    } else if (!emailRegex.test(values.email)) {
      errors.email = 'Invalid email address';
    }
    if (!values.password) {
      errors.password = 'Password is required';
    } else if (values.password.length < 8) {
      errors.password = 'Password must be at least 8 characters long';
    }
    return errors;
  };

  return (
    <Formik
      initialValues={{ email: '', password: '' }}
      validate={validate}
      validateOnChange={true}
      validateOnBlur={true}
      validateOnMount={true}
      onSubmit={values=>console.log(values)}
    >
      {({ isValid, errors, touched }) => (
        <Form className="registration-form">
          <Typography variant="h5" gutterBottom>
            Registration
          </Typography>
          <InputFormField label="Email" name="email" type="email" />
          {touched.email && errors.email && (
            <Typography color="error" variant="caption" component="div">
              {errors.email}
            </Typography>
          )}
          <InputFormField label="Password" name="password" type="password"/>
          {touched.password && errors.password && (
            <Typography color="error" variant="caption" component="div">
              {errors.password}
            </Typography>
          )}
          <Button
            type="submit"
            variant="contained"
            color="primary"
            disabled={!isValid}
            className="registration-form__button"
          >
            Register
          </Button>
          <Box component='div' className='additional-buttons'>
            <Button variant="contained" className='google-button'>
              <FcGoogle/>
              Sign in with Google
            </Button>
          <Button>Forgot Password</Button>
          </Box>
        </Form>
      )}
    </Formik>
  );
};

export default RegistrationForm;