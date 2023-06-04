import axios from 'axios';
import { JudgeCategory } from '../models/JudgeCategory';

const BASE_URL = 'judgeCategories/';

const JudgeCategoryService = {
  getAllJudgeCategories: async (): Promise<JudgeCategory[]> => {
    return await axios.get(BASE_URL + 'all');
  },
};

export default JudgeCategoryService;
