import axios from 'axios';
import { Competition } from '../models/Competition';

const BASE_URL = process.env.REACT_APP_API_URL + 'competitions/';

const CompetitionService = {
    getAllCompetitions: async () => {
        return await axios.get<Competition[]>(BASE_URL + 'all')
    },

    createCompetition: async (competition: Competition) => {
        return await axios.post(BASE_URL, competition);
    },

    updateCompetition: async (id: number, competition: Competition) => {
        return await axios.put(BASE_URL + id, competition);
    },

    deleteCompetition: async (id: number) => {
        return await axios.delete(BASE_URL + id);
    }
}

export default CompetitionService;