import React, { useEffect } from 'react';
import { Navigate, Route, Routes, useNavigate } from 'react-router-dom';
import { Header } from '../../components/Header';
import routes, { dashboardRoutes } from '../../const/routes';
import { CalendarPage } from '../Calendar';
import { HomePage } from '../Home';

const DashboardPage = () => {
  const navigate = useNavigate();

  useEffect(() => {
    if (localStorage.getItem('isLoggedIn') !== 'true') {
      navigate(routes.REGISTRATION);
    }
  });

  return (
    <>
      <Header />
      <Routes>
        <Route
          path='/'
          element={<Navigate to={routes.DASHBOARD + dashboardRoutes.HOME} />}
        />
        <Route path={dashboardRoutes.HOME} element={<HomePage />} />
        <Route path={dashboardRoutes.CALENDAR} element={<CalendarPage />} />
      </Routes>
    </>
  );
};

export { DashboardPage };
