import { makeAutoObservable } from 'mobx';
import { User } from '../models/User';
import { UserService } from '../services';
import { RootStore } from './RootStore';
import axios from 'axios';

export default class UserStore {
  search = '';
  users: User[] = [];
  rootStore: RootStore;

  constructor(rootStore: RootStore) {
    makeAutoObservable(this);
    this.rootStore = rootStore;
  }

  get filteredUsers() {
    return this.users.filter(user => {
      const fullName = `${user.firstName} ${user.lastName} ${user.patronymic}`;

      return fullName.toLowerCase().includes(this.search.toLowerCase());
    });
  }

  fetchUsers = async () => {
    try {
      const fetchedUsers = await UserService.getAllUsers();
      this.users = fetchedUsers;
    } catch (e) {
      if (axios.isAxiosError(e)) {
        this.rootStore.snackBarStore.showSnackBar(
          e.response?.data.title,
          'error',
        );
      } else throw e;
    }
  };

  setSearch = (search: string) => {
    this.search = search;
  };
}
