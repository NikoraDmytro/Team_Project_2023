import axios from 'axios';
import { Sportsman } from '../models/Sportsman';

const BASE_URL = process.env.REACT_APP_API_URL + 'sportsmen/';

const SportsmanService = {
    getAllSportsmen: async () => {
        return await axios.get<Sportsman[]>(BASE_URL + 'all')
    },

    createSportsman: async (club: Sportsman) => {
        return await axios.post(BASE_URL, club);
    },

    deleteSportsman: async (id: Sportsman) => {
        return await axios.delete(BASE_URL + id);
    }
}

export default SportsmanService;