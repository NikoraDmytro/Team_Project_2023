import http from './index';

import { Club } from '../models/Club';

const BASE_URL = 'clubs/';

const ClubService = {
  getAllClubs: async (): Promise<Club[]> => {
    return await http.get(BASE_URL + 'all');
  },

  createClub: async (club: Club): Promise<Club> => {
    return await http.post(BASE_URL, club);
  },

  updateClub: async (id: number, club: Club): Promise<Club> => {
    return await http.put(BASE_URL + id, club);
  },

  deleteClub: async (id: number): Promise<Club> => {
    return await http.delete(BASE_URL + id);
  },
};

export default ClubService;
