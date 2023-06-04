import axios from 'axios';
import { User } from '../models/User';

const BASE_URL = process.env.REACT_APP_API_URL + 'users/';

const UserService = {
    getAllUsers: async () => {
        return await axios.get<User[]>(BASE_URL + 'all')
    },

    createUser: async (user: User) => {
        return await axios.post(BASE_URL, user);
    },

    updateUser: async (id: number, user: User) => {
        return await axios.put(BASE_URL + id, user);
    },

    deleteUser: async (id: number) => {
        return await axios.delete(BASE_URL + id);
    }
}

export default UserService;