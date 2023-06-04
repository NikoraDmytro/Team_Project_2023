import React from 'react';
import { NavLink, useNavigate } from 'react-router-dom';
import routes, { dashboardRoutes } from '../../const/routes';
import './SideBar.scss';
import {
  taekwondoLogo,
  calendarIcon,
  usersIcon,
  clubsIcon,
  coachesIcon,
  divisionsIcon,
  refereesIcon,
  sportsmanIcon,
} from '../../assets/img';
import { AuthService } from '../../services';

const SideBar = (): JSX.Element => {
  const navigate = useNavigate();
  const clickHandler = () => {
    AuthService.logout();
    navigate(routes.REGISTRATION);
  };
  return (
    <div className='container'>
      <div className='logo'>
        <img src={taekwondoLogo} alt='logo' />
        <h1
          onClick={() => {
            navigate(routes.DASHBOARD + dashboardRoutes.HOME);
          }}
        >
          Taekwon-do
        </h1>
      </div>
      <div className='navbar'>
        <NavLink
          to={`${routes.DASHBOARD}${dashboardRoutes.USERS}`}
          className={({ isActive }) => (isActive ? 'active' : '')}
        >
          <img src={usersIcon} alt='users-icon' />
          <p>Користувачі</p>
        </NavLink>
        <NavLink
          to={`${routes.DASHBOARD}${dashboardRoutes.CLUBS}`}
          className={({ isActive }) => (isActive ? 'active' : '')}
        >
          <img src={clubsIcon} alt='clubs-icon' />
          <p>Клуби</p>
        </NavLink>
        <NavLink
          to={`${routes.DASHBOARD}${dashboardRoutes.SPORTSMAN}`}
          className={({ isActive }) => (isActive ? 'active' : '')}
        >
          <img src={sportsmanIcon} alt='sportsman-icon' />
          <p>Спортсмени</p>
        </NavLink>
        <NavLink
          to={`${routes.DASHBOARD}${dashboardRoutes.COACHES}`}
          className={({ isActive }) => (isActive ? 'active' : '')}
        >
          <img src={coachesIcon} alt='coaches-icon' />
          <p>Тренери</p>
        </NavLink>
        <NavLink
          to={`${routes.DASHBOARD}${dashboardRoutes.REFEREES}`}
          className={({ isActive }) => (isActive ? 'active' : '')}
        >
          <img src={refereesIcon} alt='referees-icon' />
          <p>Судді</p>
        </NavLink>
        <NavLink
          to={`${routes.DASHBOARD}${dashboardRoutes.CALENDAR}`}
          className={({ isActive }) => (isActive ? 'active' : '')}
        >
          <img src={calendarIcon} alt='calendar-icon' />
          <p>Календар</p>
        </NavLink>
        <NavLink
          to={`${routes.DASHBOARD}${dashboardRoutes.DIVISIONS}`}
          className={({ isActive }) => (isActive ? 'active' : '')}
        >
          <img src={divisionsIcon} alt='divisions-icon' />
          <p>Дивізіони</p>
        </NavLink>
      </div>
      <div className='exit'>
        <p onClick={clickHandler}>Вийти</p>
      </div>
    </div>
  );
};

export { SideBar };
