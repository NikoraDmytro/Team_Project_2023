import React, { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import routes from '../../const/routes';
import { RegistrationForm } from '../../components/RegistrationForm';
import './RegistrationPage.scss';

const clientId = "801059873983-1g644inr6eibjs8mcb5ejm7olt7s994v.apps.googleusercontent.com";

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

const RegistrationPage = (): JSX.Element => {
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

  return (
    <div className='registration-page-wrapper'>
      <RegistrationForm />
      <div id="signinDiv"></div>
    </div>
  );
};

export { RegistrationPage };
