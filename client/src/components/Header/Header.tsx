import React from 'react';
import { NavLink, useNavigate } from 'react-router-dom';
import routes, { dashboardRoutes } from '../../const/routes';
import './Header.scss';
import logo from '../../assets/navIcons/taekwondo.png';
import calendar from '../../assets/navIcons/calendar.png';
import users from '../../assets/navIcons/users.png';
import clubs from '../../assets/navIcons/clubs.png';
import coaches from '../../assets/navIcons/coaches.png';
import divisions from '../../assets/navIcons/divisions.png';
import referees from '../../assets/navIcons/referees.png';
import sportsman from '../../assets/navIcons/sportsman.png';

const Header = (): JSX.Element => {
  const navigate = useNavigate();
  const clickHandler = () => {
    localStorage.setItem('isLoggedIn', 'false');
    navigate(routes.REGISTRATION);
  };
  return (
    <div className='container'>
      <div className='logo'>
        <img src={logo} alt='logo' />
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
          <img src={users} alt='users-icon' />
          <p>Користувачі</p>
        </NavLink>
        <NavLink
          to={`${routes.DASHBOARD}${dashboardRoutes.CLUBS}`}
          className={({ isActive }) => (isActive ? 'active' : '')}
        >
          <img src={clubs} alt='clubs-icon' />
          <p>Клуби</p>
        </NavLink>
        <NavLink
          to={`${routes.DASHBOARD}${dashboardRoutes.SPORTSMAN}`}
          className={({ isActive }) => (isActive ? 'active' : '')}
        >
          <img src={sportsman} alt='sportsman-icon' />
          <p>Спортсмени</p>
        </NavLink>
        <NavLink
          to={`${routes.DASHBOARD}${dashboardRoutes.COACHES}`}
          className={({ isActive }) => (isActive ? 'active' : '')}
        >
          <img src={coaches} alt='coaches-icon' />
          <p>Тренери</p>
        </NavLink>
        <NavLink
          to={`${routes.DASHBOARD}${dashboardRoutes.REFEREES}`}
          className={({ isActive }) => (isActive ? 'active' : '')}
        >
          <img src={referees} alt='referees-icon' />
          <p>Судді</p>
        </NavLink>
        <NavLink
          to={`${routes.DASHBOARD}${dashboardRoutes.CALENDAR}`}
          className={({ isActive }) => (isActive ? 'active' : '')}
        >
          <img src={calendar} alt='calendar-icon' />
          <p>Календар</p>
        </NavLink>
        <NavLink
          to={`${routes.DASHBOARD}${dashboardRoutes.DIVISIONS}`}
          className={({ isActive }) => (isActive ? 'active' : '')}
        >
          <img src={divisions} alt='divisions-icon' />
          <p>Дивізіони</p>
        </NavLink>
      </div>
      <div className='exit'>
        <p onClick={clickHandler}>Вийти</p>
      </div>
    </div>
  );
};

export { Header };
