import React from 'react';
import { Formik, Form } from 'formik';
import { Button, Checkbox, Typography } from '@mui/material';
import { FcGoogle } from 'react-icons/fc';
import { InputFormField } from '../InputFormField';
import { useNavigate } from 'react-router-dom';
import { validationSchema } from './helpers/validation';
import routes from '../../const/routes';
import './RegistrationForm.scss';
import logo from '../../assets/img/taekwondo.png';

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
          <img src={logo} alt='logo' />
          <Typography variant='h5' gutterBottom align='center'>
            ФЕДЕРАЦІЯ ТАЕКВОН-ДО ІТФ УКРАЇНИ
          </Typography>
          <InputFormField label='Пошта' name='email' type='email' />
          <InputFormField label='Пароль' name='password' type='password' />
          {/* <Button className='forgot-password-button'>Forgot password?</Button> */}
          <div className='remember-password'>
            <Checkbox /> Запам'ятати пароль
          </div>
          <Button
            type='submit'
            variant='contained'
            color='primary'
            disabled={!isValid}
            size='large'
            sx={{ width: '60%' }}
          >
            Увійти
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
