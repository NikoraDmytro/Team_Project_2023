const routes = {
  REGISTRATION: '/registration',
  DASHBOARD: '/dashboard',
};

export const dashboardRoutes = {
  HOME: '/home',
  CALENDAR: '/calendar',
  COMPETITION: '/calendar/:competitionId/*',
  USERS: '/users',
  CLUBS: '/clubs',
  SPORTSMAN: '/sportsman',
  COACHES: '/coaches',
  REFEREES: '/referees',
  DIVISIONS: '/divisions',
};

export const competitionRoutes = {
  COMPETITORS: '/competitors',
  JUDGINGSTAFF: '/judges',
  DAYANGS: '/dayangs',
  SHUFFLES: '/shuffles',
  SHUFFLE: '/shuffles/:shuffleId',
};

export default routes;
