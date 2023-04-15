import React from 'react';
import { Navigate, Route, Routes } from 'react-router-dom';
import { Header } from '../../components/Header';
import { dashboardRoutes } from '../../const/routes';
import { CalendarPage } from '../Calendar';
import { HomePage } from '../Home';

const DashboardPage = () => {
  return (
    <>
      <Header />
      <Routes>
        <Route path='/' element={<Navigate to={dashboardRoutes.HOME} />} />
        <Route path={dashboardRoutes.HOME} element={<HomePage />} />
        <Route path={dashboardRoutes.CALENDAR} element={<CalendarPage />} />
      </Routes>
    </>
  );
};

export { DashboardPage };
