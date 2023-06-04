import http from './index';
import { Belt } from '../models/Belt';

const BASE_URL = 'belts/';

const BeltService = {
  getAllBelts: async (): Promise<Belt[]> => {
    return await http.get(BASE_URL + 'all');
  },
};

export default BeltService;
