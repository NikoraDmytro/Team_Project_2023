import http from './index';
import { Sportsman } from '../models/Sportsman';

const BASE_URL = 'sportsmen/';

const SportsmanService = {
  getAllSportsmen: async (): Promise<Sportsman[]> => {
    return await http.get(BASE_URL + 'all');
  },

  createSportsman: async (club: Sportsman): Promise<Sportsman> => {
    return await http.post(BASE_URL, club);
  },

  deleteSportsman: async (id: Sportsman): Promise<Sportsman> => {
    return await http.delete(BASE_URL + id);
  },
};

export default SportsmanService;
