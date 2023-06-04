import http from './index';
import { Coach } from '../models/Coach';

const BASE_URL = 'coaches/';

const CoachService = {
  getAllCoaches: async (): Promise<Coach[]> => {
    return await http.get(BASE_URL + 'all');
  },

  createCoach: async (club: Coach): Promise<Coach> => {
    return await http.post(BASE_URL, club);
  },

  deleteCoach: async (id: number): Promise<Coach> => {
    return await http.delete(BASE_URL + id);
  },
};

export default CoachService;
