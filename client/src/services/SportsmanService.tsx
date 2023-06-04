import axios from 'axios';
import { Sportsman } from '../models/Sportsman';

const BASE_URL = process.env.REACT_APP_API_URL + 'sportsmen/';

const SportsmanService = {
    getAllSportsmen: async () => {
        return await axios.get<Sportsman[]>(BASE_URL + 'all')
    },

    createSportsman: async (sportsman: any) => {
        return await axios.post(BASE_URL, sportsman);
    },

    updateSportsman: async (membershipCardNum: number, sportsman: any) => {
        return await axios.put(BASE_URL + membershipCardNum, sportsman);
    },

    deleteSportsman: async (id: number) => {
        return await axios.delete(BASE_URL + id);
    }
}

export default SportsmanService;