import http from './index';
import { Competition } from '../models/Competition';

const BASE_URL = 'competitions/';

const CompetitionService = {
  getAllCompetitions: async (): Promise<Competition[]> => {
    return await http.get(BASE_URL + 'all');
  },

  createCompetition: async (competition: Competition) => {
    return await http.post(BASE_URL, competition);
  },

  updateCompetition: async (id: number, competition: Competition) => {
    return await http.put(BASE_URL + id, competition);
  },

  deleteCompetition: async (id: number) => {
    return await http.delete(BASE_URL + id);
  },
};

export default CompetitionService;
