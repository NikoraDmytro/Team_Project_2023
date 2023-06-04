import http from './index';
import { JudgeCategory } from '../models/JudgeCategory';

const BASE_URL = 'judgeCategories/';

const JudgeCategoryService = {
  getAllJudgeCategories: async (): Promise<JudgeCategory[]> => {
    return await http.get(BASE_URL + 'all');
  },
};

export default JudgeCategoryService;
