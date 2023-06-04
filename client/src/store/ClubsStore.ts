import { makeAutoObservable } from 'mobx';
import { Club } from './../models/Club';
import { ClubService } from '../services';
import { RootStore } from './RootStore';
import axios from 'axios';

export default class ClubsStore {
  clubs: Club[] = [];
  cityFilter = '';
  rootStore: RootStore;

  constructor(rootStore: RootStore) {
    makeAutoObservable(this);
    this.rootStore = rootStore;
  }

  get filteredClubs() {
    return this.clubs.filter(
      club => !this.cityFilter || club.city === this.cityFilter,
    );
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

  setCityFilter(city: string) {
    this.cityFilter = city;
  }
}
