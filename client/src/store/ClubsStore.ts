import { makeAutoObservable } from 'mobx';
import { Club } from './../models/Club';
import { ClubService } from '../services';
import { RootStore } from './RootStore';
import axios from 'axios';

export default class ClubsStore {
  clubs: Club[] = [];
  rootStore: RootStore;

  constructor(rootStore: RootStore) {
    makeAutoObservable(this);
    this.rootStore = rootStore;
  }

  fetchClubs = async () => {
    try {
      const fetchedClubs = await ClubService.getAllClubs();
      this.clubs = fetchedClubs;
    } catch (e) {
      if (axios.isAxiosError(e)) {
        this.rootStore.snackBarStore.showSnackBar(
          e.response?.data.title,
          'error',
        );
      } else throw e;
    }
  };
}
