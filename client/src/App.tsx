import { Routes, Route, Navigate } from 'react-router-dom';
import routes from './const/routes';
import { RegistrationPage } from './pages/Registration';
import { DashboardPage } from './pages/Dashboard';

const App = (): JSX.Element => {
  return (
    <>
      <Routes>
        <Route index element={<Navigate to={routes.REGISTRATION} />} />
        <Route path={`${routes.DASHBOARD}/*`} element={<DashboardPage />} />
        <Route path={routes.REGISTRATION} element={<RegistrationPage />} />
      </Routes>
    </>
  );
};

export { App };
