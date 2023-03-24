import React from 'react';
import { Formik, Form } from 'formik';
import { Button, Typography } from '@mui/material';
import { FcGoogle } from 'react-icons/fc';
import { Box } from '@mui/system';
import InputFormField from '../InputFormField/InputFormField';
import './RegistrationForm.css';


const RegistrationForm = () => {
  return (
    <Formik initialValues={{ email: '', password: '' }}
      onSubmit={(values) => console.log(values)}>
      {({ isSubmitting }) => (
        <Form className="registration-form">
          <Typography variant="h5" gutterBottom>
            Registration
          </Typography>
          <InputFormField label="Email" name="email" type="email" />
          <InputFormField label="Password" name="password" type="password"/>
          <Button
            type="submit"
            variant="contained"
            color="primary"
            disabled={isSubmitting}
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