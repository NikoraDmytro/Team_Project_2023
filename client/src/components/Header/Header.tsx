import { Box, AppBar, Toolbar, Typography, Button } from '@mui/material';
import React from 'react';
import { useNavigate } from 'react-router-dom';
import routes, { dashboardRoutes } from '../../const/routes';

const Header = (): JSX.Element => {
  const navigate = useNavigate();
  const clickHandler = () => {
    localStorage.setItem('isLoggedIn', 'false');
    navigate(routes.REGISTRATION);
  };
  return (
    <Box sx={{ flexGrow: 1 }}>
      <AppBar position='static'>
        <Toolbar>
          <Typography
            variant='h4'
            component='div'
            sx={{ flexGrow: 1, cursor: 'pointer' }}
            onClick={() => {
              navigate(routes.DASHBOARD + dashboardRoutes.HOME);
            }}
          >
            Taekwondo
          </Typography>
          <Box sx={{ flexGrow: 1, display: { md: 'flex' } }}>
            <Button
              color='inherit'
              onClick={() => {
                navigate(routes.DASHBOARD + dashboardRoutes.CALENDAR);
              }}
            >
              Calendar
            </Button>
          </Box>
          <Button color='inherit' size='large' onClick={clickHandler}>
            Log out
          </Button>
        </Toolbar>
      </AppBar>
    </Box>
  );
};

export { Header };
