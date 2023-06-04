import axios from 'axios';
import { Coach } from '../models/Coach';

const BASE_URL = process.env.REACT_APP_API_URL + 'coaches/';

const CoachService = {
    getAllCoaches: async () => {
        return await axios.get<Coach[]>(BASE_URL + 'all')
    },

    createCoach: async (coach: any) => {
        return await axios.post(BASE_URL, coach);
    },

    updateCoach: async (membershipCardNum: number, coach: Coach) => {
        return await axios.put(BASE_URL + membershipCardNum, coach);
    },

    deleteCoach: async (id: number) => {
        return await axios.delete(BASE_URL + id);
    }
}

export default CoachService;