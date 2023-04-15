import React from 'react';
import { RegistrationForm } from '../../components/RegistrationForm';

const RegistrationPage = (): JSX.Element => {
  return (
    <div className='registration-page-wrapper'>
      <RegistrationForm />
    </div>
  );
};

export { RegistrationPage };
