import React, { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import routes from '../../const/routes';
import { RegistrationForm } from '../../components/RegistrationForm';
import './RegistrationPage.scss';

const RegistrationPage = (): JSX.Element => {
  const navigate = useNavigate();

  useEffect(() => {
    if (localStorage.getItem('isLoggedIn') === 'true') {
      navigate(routes.DASHBOARD);
    }
  });

  return (
    <div className='registration-page-wrapper'>
      <RegistrationForm />
    </div>
  );
};

export { RegistrationPage };
