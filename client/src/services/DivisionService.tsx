import axios from 'axios';
import { Division } from '../models/Division';

const BASE_URL = process.env.REACT_APP_API_URL + 'divisions/';

const DivisionService = {
  getAllDivisions: async (): Promise<Division[]> => {
    return await axios.get(BASE_URL + 'all');
  },
};

export default DivisionService;
