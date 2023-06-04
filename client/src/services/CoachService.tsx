import http from './index';
import { Coach } from '../models/Coach';

const BASE_URL = 'coaches/';

const CoachService = {
  getAllCoaches: async (): Promise<Coach[]> => {
    return await http.get(BASE_URL + 'all');
  },

  createCoach: async (coach: any): Promise<Coach> => {
    return await http.post(BASE_URL, coach);
  },

  updateCoach: async (
    membershipCardNum: number,
    coach: Coach,
  ): Promise<Coach> => {
    return await http.put(BASE_URL + membershipCardNum, coach);
  },

  deleteCoach: async (id: number): Promise<Coach> => {
    return await http.delete(BASE_URL + id);
  },
};

export default CoachService;
