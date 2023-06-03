import axios from 'axios';
import { Club } from '../models/Club';

const BASE_URL = process.env.REACT_APP_API_URL + 'clubs/';

const ClubService = {
    getAllClubs: async () => {
        return await axios.get<Club[]>(BASE_URL + 'all')
    },

    createClub: async (club: Club) => {
        return await axios.post(BASE_URL, club);
    }
}

export default ClubService;