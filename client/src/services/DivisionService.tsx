import http from './index';
import { Division } from '../models/Division';

const BASE_URL = 'divisions/';

const DivisionService = {
  getAllDivisions: async (): Promise<Division[]> => {
    return await http.get(BASE_URL + 'all');
  },
};

export default DivisionService;
