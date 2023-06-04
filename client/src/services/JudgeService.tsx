import http from './index';
import { Judge } from '../models/Judge';

const BASE_URL = 'judges/';

const JudgeService = {
  getAllJudges: async (): Promise<Judge[]> => {
    return await http.get(BASE_URL + 'all');
  },

  createJudge: async (judge: any) => {
    return await http.post(BASE_URL, judge);
  },

  updateJudge: async (membershipCardNum: number, judge: any) => {
    return await http.put(BASE_URL + membershipCardNum, judge);
  },

  deleteJudge: async (id: number) => {
    return await http.delete(BASE_URL + id);
  },
};

export default JudgeService;
