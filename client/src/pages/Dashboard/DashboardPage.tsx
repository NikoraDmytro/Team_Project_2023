import React, { useEffect } from 'react';
import { Navigate, Route, Routes, useNavigate } from 'react-router-dom';
import { SideBar } from '../../components/SideBar';
import routes, { competitionRoutes, dashboardRoutes } from '../../const/routes';
import { CalendarPage } from '../Calendar';
import { HomePage } from '../Home';
import { UsersPage } from '../Users';
import { ClubsPage } from '../Clubs';
import { SportsmanPage } from '../Sportsman';
import { CoachesPage } from '../Coaches';
import { RefereesPage } from '../Referees';
import { DivisionsPage } from '../Divisions';
import { Competition } from '../Competition';
import { JudgingStaff } from '../Competition/components/JudgingStaff';
import { Competitors } from '../Competition/components/Competitors/Competitors';
import { Dayangs } from '../Competition/components/Dayangs';
import { Shuffles } from '../Competition/components/Shuffles';

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
        <Route path={dashboardRoutes.COMPETITION} element={<Competition />}>
          <Route
            path={dashboardRoutes.COMPETITION + competitionRoutes.COMPETITORS}
            element={<Competitors />}
          />
          <Route
            path={dashboardRoutes.COMPETITION + competitionRoutes.JUDGINGSTAFF}
            element={<JudgingStaff />}
          />
          <Route
            path={dashboardRoutes.COMPETITION + competitionRoutes.DAYANGS}
            element={<Dayangs />}
          />
          <Route
            path={dashboardRoutes.COMPETITION + competitionRoutes.SHUFFLES}
            element={<Shuffles />}
          />
        </Route>

        <Route path={competitionRoutes.SHUFFLE} element={<div>SHUFFLE</div>} />
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
