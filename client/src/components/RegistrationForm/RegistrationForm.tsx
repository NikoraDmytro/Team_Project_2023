import React, { useEffect } from 'react';
import { Formik, Form } from 'formik';
import { Button, Checkbox, Typography } from '@mui/material';
import { InputFormField } from '../InputFormField';
import { useNavigate } from 'react-router-dom';
import { validationSchema } from './helpers/validation';
import routes from '../../const/routes';
import './RegistrationForm.scss';
import logo from '../../assets/img/taekwondo.png';
import { AuthService } from '../../services';

interface FormValues {
  email: string;
  password: string;
}

const initialValues: FormValues = {
  email: '',
  password: '',
};

const clientId =
  '801059873983-1g644inr6eibjs8mcb5ejm7olt7s994v.apps.googleusercontent.com';

const RegistrationForm = (): JSX.Element => {
  const navigate = useNavigate();

  useEffect(() => {
    if (localStorage.getItem('isLoggedIn') === 'true') {
      navigate(routes.DASHBOARD);
    }

    google.accounts.id.initialize({
      client_id: clientId,
      callback: handleLoginExternal,
    });

    google.accounts.id.renderButton(document.getElementById('signinDiv')!, {
      theme: 'outline',
      size: 'large',
      type: 'standard',
      text: 'signin_with',
    });
  });

  async function handleLoginExternal(res: any) {
    console.log('Callback response', res);
    await AuthService.loginExternal({
      provider: 'Google',
      idToken: res.credential,
    }).then(x => {
      localStorage.setItem('token', x.token);
      navigate(routes.DASHBOARD);
    });
  }

  const submitHandler = async (values: FormValues) => {
    await AuthService.login(values)
      .then(x => {
        localStorage.setItem('token', x.token);
        navigate(routes.DASHBOARD);
      })
      .catch(error => {
        console.log(error);
      });
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
          <div id='signinDiv'></div>
        </Form>
      )}
    </Formik>
  );
};

export { RegistrationForm };
