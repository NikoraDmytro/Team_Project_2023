import React, { useEffect } from 'react';
import { Outlet, useNavigate} from 'react-router-dom'
import {Header} from './components/Header';

const App = (): JSX.Element => {
  const navigate = useNavigate();
  useEffect(() => {
    if (localStorage.getItem('isLoggedIn') !== 'true') {
      navigate('/register');
    }
  }, [])
  return (
    <>
      <Header />
      <Outlet/>
      </>
  );
}

export {App};
