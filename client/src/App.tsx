import { Routes, Route, Navigate } from 'react-router-dom';
import routes from './const/routes';
import { RegistrationPage } from './pages/Registration';
import { DashboardPage } from './pages/Dashboard';
import image from './assets/img/bgimg.jpg'

const App = (): JSX.Element => {
  return (
    <div style={{backgroundImage: `url(${image})`, backgroundSize: 'cover', backgroundRepeat: 'no-repeat'}}>
      <Routes>
        <Route index element={<Navigate to={routes.REGISTRATION} />} />
        <Route path={`${routes.DASHBOARD}/*`} element={<DashboardPage />} />
        <Route path={routes.REGISTRATION} element={<RegistrationPage />} />
      </Routes>
    </div>
  );
};

export { App };
