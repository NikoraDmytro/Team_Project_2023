import ClubsStore from './ClubsStore';
import SnackBarStore from './SnackBarStore';

export class RootStore {
  clubsStore = new ClubsStore(this);
  snackBarStore = new SnackBarStore(this);
}
