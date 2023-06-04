import axios from 'axios';
import { Division } from '../models/Division';

const BASE_URL = 'divisions/';

const DivisionService = {
  getAllDivisions: async (): Promise<Division[]> => {
    return await axios.get(BASE_URL + 'all');
  },
};

export default DivisionService;
