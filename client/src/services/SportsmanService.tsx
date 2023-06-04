import http from './index';
import { Sportsman } from '../models/Sportsman';

const BASE_URL = 'sportsmen/';

const SportsmanService = {
  getAllSportsmen: async (): Promise<Sportsman[]> => {
    return await http.get(BASE_URL + 'all');
  },

  createSportsman: async (sportsman: any): Promise<Sportsman> => {
    return await http.post(BASE_URL, sportsman);
  },

  updateSportsman: async (
    membershipCardNum: number,
    sportsman: any,
  ): Promise<Sportsman> => {
    return await http.put(BASE_URL + membershipCardNum, sportsman);
  },

  deleteSportsman: async (id: number): Promise<Sportsman> => {
    return await http.delete(BASE_URL + id);
  },
};

export default SportsmanService;
