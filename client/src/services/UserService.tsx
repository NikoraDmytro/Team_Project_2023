import http from './index';
import { User } from '../models/User';

const BASE_URL = 'users/';

const UserService = {
  getAllUsers: async (): Promise<User[]> => {
    return await http.get(BASE_URL + 'all');
  },

  createUser: async (user: User): Promise<User> => {
    return await http.post(BASE_URL, user);
  },

  updateUser: async (id: number, user: User): Promise<User> => {
    return await http.put(BASE_URL + id, user);
  },

  deleteUser: async (id: number): Promise<User> => {
    return await http.delete(BASE_URL + id);
  },
};

export default UserService;
