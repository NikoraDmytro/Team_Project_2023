import { makeAutoObservable } from 'mobx';
import { Club } from './../models/Club';
import { ClubService } from '../services';
import { RootStore } from './RootStore';
import axios from 'axios';

export default class ClubsStore {
  clubs: Club[] = [];
  search = '';
  cityFilter = '';
  rootStore: RootStore;

  constructor(rootStore: RootStore) {
    this.rootStore = rootStore;
    makeAutoObservable(this);
  }

  get filteredClubs() {
    return this.clubs.filter(
      club =>
        (!this.cityFilter || club.city === this.cityFilter) &&
        club.name.includes(this.search),
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

  setCityFilter = (city: string) => {
    console.log(city, this);
    this.cityFilter = city;
  };

  setSearch = (search: string) => {
    this.search = search;
  };
}
