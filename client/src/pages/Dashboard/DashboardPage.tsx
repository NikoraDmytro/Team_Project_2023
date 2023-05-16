import React, { useEffect } from 'react';
import { Navigate, Route, Routes, useNavigate } from 'react-router-dom';
import { SideBar } from '../../components/SideBar';
import routes, { dashboardRoutes } from '../../const/routes';
import { CalendarPage } from '../Calendar';
import { HomePage } from '../Home';
import { UsersPage } from '../Users';
import { ClubsPage } from '../Clubs';
import { SportsmanPage } from '../Sportsman';
import { CoachesPage } from '../Coaches';
import { RefereesPage } from '../Referees';
import { DivisionsPage } from '../Divisions';

const DashboardPage = () => {
  const navigate = useNavigate();

  useEffect(() => {
    if (localStorage.getItem('isLoggedIn') !== 'true') {
      navigate(routes.REGISTRATION);
    }
  });

  return (
    <>
      <SideBar />
      <Routes>
        <Route
          path='/'
          element={<Navigate to={routes.DASHBOARD + dashboardRoutes.HOME} />}
        />
        <Route path={dashboardRoutes.HOME} element={<HomePage />} />
        <Route path={dashboardRoutes.CALENDAR} element={<CalendarPage />} />
        <Route path={dashboardRoutes.USERS} element={<UsersPage />} />
        <Route path={dashboardRoutes.CLUBS} element={<ClubsPage />} />
        <Route path={dashboardRoutes.SPORTSMAN} element={<SportsmanPage />} />
        <Route path={dashboardRoutes.COACHES} element={<CoachesPage />} />
        <Route path={dashboardRoutes.REFEREES} element={<RefereesPage />} />
        <Route path={dashboardRoutes.DIVISIONS} element={<DivisionsPage />} />
      </Routes>
    </>
  );
};

export { DashboardPage };
