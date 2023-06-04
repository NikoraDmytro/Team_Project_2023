import ClubsStore from './ClubsStore';
import SnackBarStore from './SnackBarStore';
import UserStore from './UserStore';

export class RootStore {
  usersStore = new UserStore(this);
  clubsStore = new ClubsStore(this);
  snackBarStore = new SnackBarStore(this);
}
